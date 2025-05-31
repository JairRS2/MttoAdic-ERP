using MetadataExtractor;
using MetadataExtractor.Formats.Exif;
using SkiaSharp;

namespace MttoAdic_ERP.Helpers
{
    public static class ImagenHelper
    {
        public static Stream ComprimirImagen(string rutaImagen, int calidad = 70, int maxWidth = 1024, int maxHeight = 1024)
        {
            var bitmap = CorregirOrientacion(rutaImagen);

            // Redimensionar si es necesario
            int width = bitmap.Width;
            int height = bitmap.Height;
            if (width > maxWidth || height > maxHeight)
            {
                float ratioX = (float)maxWidth / width;
                float ratioY = (float)maxHeight / height;
                float ratio = Math.Min(ratioX, ratioY);
                width = (int)(width * ratio);
                height = (int)(height * ratio);
                bitmap = bitmap.Resize(new SKImageInfo(width, height), SKFilterQuality.Medium);
            }

            using var image = SKImage.FromBitmap(bitmap);
            var outputStream = new MemoryStream();
            image.Encode(SKEncodedImageFormat.Jpeg, calidad).SaveTo(outputStream);
            outputStream.Seek(0, SeekOrigin.Begin);
            return outputStream;
        }

        private static SKBitmap CorregirOrientacion(string rutaImagen)
        {
            var directories = ImageMetadataReader.ReadMetadata(rutaImagen);
            var exif = directories.OfType<ExifIfd0Directory>().FirstOrDefault();

            int orientation = 1; // Valor por defecto (sin rotación)
            if (exif != null && exif.TryGetInt32(ExifDirectoryBase.TagOrientation, out int value))
            {
                orientation = value;
            }

            using var input = File.OpenRead(rutaImagen);
            var original = SKBitmap.Decode(input);

            Func<SKBitmap, SKBitmap> transform = orientation switch
            {
                1 => bmp => bmp,
                2 => bmp => FlipHorizontal(bmp),
                3 => bmp => Rotate180(bmp),
                4 => bmp => FlipVertical(bmp),
                5 => bmp => Transpose(bmp),
                6 => bmp => Rotate90(bmp),
                7 => bmp => Transverse(bmp),
                8 => bmp => Rotate270(bmp),
                _ => bmp => bmp
            };

            return transform(original);
        }

        private static SKBitmap Rotate90(SKBitmap source)
        {
            var rotated = new SKBitmap(source.Height, source.Width);
            using var canvas = new SKCanvas(rotated);
            canvas.Translate(source.Height, 0);
            canvas.RotateDegrees(90);
            canvas.DrawBitmap(source, 0, 0);
            return rotated;
        }

        private static SKBitmap Rotate180(SKBitmap source)
        {
            var rotated = new SKBitmap(source.Width, source.Height);
            using var canvas = new SKCanvas(rotated);
            canvas.Translate(source.Width, source.Height);
            canvas.RotateDegrees(180);
            canvas.DrawBitmap(source, 0, 0);
            return rotated;
        }

        private static SKBitmap Rotate270(SKBitmap source)
        {
            var rotated = new SKBitmap(source.Height, source.Width);
            using var canvas = new SKCanvas(rotated);
            canvas.Translate(0, source.Width);
            canvas.RotateDegrees(270);
            canvas.DrawBitmap(source, 0, 0);
            return rotated;
        }

        private static SKBitmap FlipHorizontal(SKBitmap source)
        {
            var flipped = new SKBitmap(source.Width, source.Height);
            using var canvas = new SKCanvas(flipped);
            canvas.Scale(-1, 1);
            canvas.Translate(-source.Width, 0);
            canvas.DrawBitmap(source, 0, 0);
            return flipped;
        }

        private static SKBitmap FlipVertical(SKBitmap source)
        {
            var flipped = new SKBitmap(source.Width, source.Height);
            using var canvas = new SKCanvas(flipped);
            canvas.Scale(1, -1);
            canvas.Translate(0, -source.Height);
            canvas.DrawBitmap(source, 0, 0);
            return flipped;
        }

        private static SKBitmap Transpose(SKBitmap source)
        {
            return Rotate90(FlipHorizontal(source));
        }

        private static SKBitmap Transverse(SKBitmap source)
        {
            return Rotate270(FlipHorizontal(source));
        }
    }
}
