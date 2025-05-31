using Microsoft.Win32;
using MttoAdic_ERP.Helpers;
using MttoAdic_ERP.Servicios;
using Syncfusion.Windows.Forms;
using System.Data;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace MttoAdic_ERP.Forms.Almacen
{
    public partial class frmAgrValeUrea : MetroForm
    {
        private string SQL = string.Empty;
        string dominio_Api = "mantenimientoadic2.ddns.net";
        string token = string.Empty;
        csConexionSQL Conex_Saaadic;
        public csConexionSQL conexValesUrea;
        public csConexionSQL ConexValesUrea { set { this.conexValesUrea = value; } }

        private DataTable dtDespachadores = new DataTable();
        private DataTable dtOperadores = new DataTable();
        private DataTable dtUnidades = new DataTable();
        private string Despachador = string.Empty;
        private string Operador = string.Empty;
        private string Unidad = string.Empty;
        private string mensajeError = "";

        public frmAgrValeUrea()
        {
            InitializeComponent();
        }

        private void frmAgrValeUrea_Load(object sender, EventArgs e)
        {
            Conex_Saaadic = new csConexionSQL("saaadic30ga.ddns.net", "dbMttoUni", "xhodaraoz", "XmaiN16xDt@@MA");
            CargarDespachadores();
            CargarOperadores();
            CargarUnidades();
        }

        private DataTable CargaDespachador()
        {
            DataTable dtDespachador = new DataTable();

            try
            {
                SQL = "SELECT cCveEmp ,cNomEmp FROM dbUrea.dbo.tbDespachador";

                dtDespachador = conexValesUrea.select(SQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("CargaDespachador " + ex.Message);
            }

            return dtDespachador;
        }

        private DataTable CargaOperador()
        {
            DataTable dtOperador = new DataTable();

            try
            {
                SQL = "SELECT cCvePer, cNomPer " +
                    "  FROM dbRelacionesLaborales.dbo.tbPersonal " +
                    "  WHERE (cCvePer LIKE 'c%' OR " +
                    "         cCvePer LIKE 'p%' OR " +
                    "         cCvePer LIKE 'n%' OR " +
                    "         cCvePer LIKE 'l%') AND " +
                    "         (nEdoPer = 1)";

                dtOperador = conexValesUrea.select(SQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("CargaDespachador " + ex.Message);
            }

            return dtOperador;
        }

        private DataTable CargaUnidad()
        {
            DataTable dtUnidad = new DataTable();

            try
            {
                SQL = "SELECT e.cCveUni " +
                    "  FROM dbMttoUni.dbo.tbEcoUni AS e " +
                    "       INNER JOIN dbMttoUni.dbo.tbHisUni AS h ON e.nIdEcoUni = h.nIdEcoUni " +
                    "  WHERE (e.nEdoEco = 1) AND (h.nEdoHis = 1) AND " +
                    "        (e.cCveUni NOT LIKE 'E%') AND " +
                    "        (e.cCveUni NOT LIKE '%b%') AND " +
                    "        (h.nCveSrv IN (1, 2, 3, 4, 7, 9))";

                dtUnidad = Conex_Saaadic.select(SQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("CargaUnidad " + ex.Message);
            }

            return dtUnidad;
        }

        private void CargarOperadores()
        {
            try
            {
                dtOperadores = CargaOperador(); // Tu método original

                // Llena el ComboBox con todos los nombres al inicio
                cboOperador.Items.Clear();

                foreach (DataRow row in dtOperadores.Rows)
                {
                    cboOperador.Items.Add(row["cNomPer"].ToString()!);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar operadores: " + ex.Message);
            }
        }

        private void CargarDespachadores()
        {
            try
            {
                dtDespachadores = CargaDespachador(); // Tu método original

                // Llena el ComboBox con todos los nombres al inicio
                cboDespachador.Items.Clear();

                foreach (DataRow row in dtDespachadores.Rows)
                {
                    cboDespachador.Items.Add(row["cNomEmp"].ToString()!);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar despachadores: " + ex.Message);
            }
        }

        private void CargarUnidades()
        {
            try
            {
                dtUnidades = CargaUnidad(); // Tu método original

                // Llena el ComboBox con todos los nombres al inicio
                cboUnidad.Items.Clear();

                foreach (DataRow row in dtUnidades.Rows)
                {
                    cboUnidad.Items.Add(row["cCveUni"].ToString()!);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar unidades: " + ex.Message);
            }
        }

        private void cboDespachador_TextUpdate(object sender, EventArgs e)
        {
            try
            {
                string texto = cboDespachador.Text.Trim().ToLower();

                if (dtDespachadores == null || dtDespachadores.Rows.Count == 0)
                    return;

                string currentText = cboDespachador.Text;
                int selStart = cboDespachador.SelectionStart;

                cboDespachador.BeginUpdate();
                cboDespachador.Items.Clear();

                var matches = dtDespachadores.AsEnumerable()
                    .Where(row => row["cNomEmp"].ToString()!.ToLower().Contains(texto))
                    .Select(row => row["cNomEmp"].ToString())
                    .Distinct()
                    .ToList();

                if (matches.Any())
                {
                    cboDespachador.Items.AddRange(matches.ToArray());

                    // Solo abrir dropdown si hay ítems y aún no está abierto
                    if (cboDespachador.Items.Count > 0 && !cboDespachador.DroppedDown)
                        cboDespachador.DroppedDown = true;
                }
                else
                {
                    if (cboDespachador.DroppedDown)
                        cboDespachador.DroppedDown = false;
                }

                // Restaurar el texto y validar la posición del cursor
                cboDespachador.Text = currentText;
                cboDespachador.SelectionStart = Math.Min(selStart, cboDespachador.Text.Length);
                cboDespachador.SelectionLength = 0;
            }
            catch (ArgumentOutOfRangeException)
            {
                // Prevenir caída en caso de cambios rápidos
            }
            finally
            {
                cboDespachador.EndUpdate();
            }
        }

        private void cboDespachador_Leave(object sender, EventArgs e)
        {
            string nombre = cboDespachador.Text.Trim();

            var encontrado = dtDespachadores.AsEnumerable()
                .FirstOrDefault(row => row["cNomEmp"].ToString()!.Equals(nombre, StringComparison.OrdinalIgnoreCase));

            if (encontrado != null)
            {
                Despachador = encontrado["cCveEmp"].ToString()!;
            }
            else
            {
                cboDespachador.Text = string.Empty;

                // Restaurar el listado completo de despachadores
                RestablecerComboDespachadores();
            }
        }

        private void RestablecerComboDespachadores()
        {
            if (dtDespachadores == null || dtDespachadores.Rows.Count == 0)
                return;

            cboDespachador.BeginUpdate();
            cboDespachador.Items.Clear();

            var todos = dtDespachadores.AsEnumerable()
                .Select(row => row["cNomEmp"].ToString())
                .Distinct()
                .ToList();

            if (todos.Any())
                cboDespachador.Items.AddRange(todos.ToArray());

            cboDespachador.EndUpdate();
        }

        private void cargaImagenPb(PictureBox pb)
        {
            // Crear un cuadro de diálogo para seleccionar una imagen
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.Title = "Seleccionar una imagen";
            openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            // Si el usuario selecciona una imagen y da clic en "Aceptar"
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Cargar la imagen en el PictureBox
                pb.Image = Image.FromFile(openFileDialog.FileName);
                pb.SizeMode = PictureBoxSizeMode.StretchImage; // Ajusta la imagen al tamaño del PictureBox
                pb.Tag = openFileDialog.FileName; // Guardamos la ruta en el Tag
            }
        }

        private void pbFotoUnidad_Click(object sender, EventArgs e)
        {
            cargaImagenPb(pbFotoUnidad);
        }

        private void pbFotoKilometraje_Click(object sender, EventArgs e)
        {
            cargaImagenPb(pbFotoKilometraje);
        }

        private void pbFotoTAC_Click(object sender, EventArgs e)
        {
            cargaImagenPb(pbFotoTAC);
        }

        private void pbFotoCL_Click(object sender, EventArgs e)
        {
            cargaImagenPb(pbFotoCL);
        }

        private void pbFotoTDC_Click(object sender, EventArgs e)
        {
            cargaImagenPb(pbFotoTDC);
        }

        private void cboOperador_TextUpdate(object sender, EventArgs e)
        {
            try
            {
                string texto = cboOperador.Text.Trim().ToLower();

                if (dtOperadores == null || dtOperadores.Rows.Count == 0)
                    return;

                string currentText = cboOperador.Text;
                int selStart = cboOperador.SelectionStart;

                cboOperador.BeginUpdate();
                cboOperador.Items.Clear();

                var matches = dtOperadores.AsEnumerable()
                    .Where(row => row["cNomPer"].ToString()!.ToLower().Contains(texto))
                    .Select(row => row["cNomPer"].ToString())
                    .Distinct()
                    .ToList();

                if (matches.Any())
                {
                    cboOperador.Items.AddRange(matches.ToArray());

                    // Solo abrir dropdown si hay ítems y aún no está abierto
                    if (cboOperador.Items.Count > 0 && !cboOperador.DroppedDown)
                        cboOperador.DroppedDown = true;
                }
                else
                {
                    if (cboOperador.DroppedDown)
                        cboOperador.DroppedDown = false;
                }

                // Restaurar el texto y validar la posición del cursor
                cboOperador.Text = currentText;
                cboOperador.SelectionStart = Math.Min(selStart, cboOperador.Text.Length);
                cboOperador.SelectionLength = 0;
            }
            catch (ArgumentOutOfRangeException)
            {
                // Prevenir caída en caso de cambios rápidos
            }
            finally
            {
                cboOperador.EndUpdate();
            }
        }

        private void cboOperador_Leave(object sender, EventArgs e)
        {
            string nombre = cboOperador.Text.Trim();

            var encontrado = dtOperadores.AsEnumerable()
                .FirstOrDefault(row => row["cNomPer"].ToString()!.Equals(nombre, StringComparison.OrdinalIgnoreCase));

            if (encontrado != null)
            {
                Operador = encontrado["cCvePer"].ToString()!;
            }
            else
            {
                cboOperador.Text = string.Empty;

                // Restaurar el listado completo de despachadores
                RestablecerComboOperadores();
            }
        }

        private void RestablecerComboOperadores()
        {
            if (dtOperadores == null || dtOperadores.Rows.Count == 0)
                return;

            cboOperador.BeginUpdate();
            cboOperador.Items.Clear();

            var todos = dtOperadores.AsEnumerable()
                .Select(row => row["cNomPer"].ToString())
                .Distinct()
                .ToList();

            if (todos.Any())
                cboOperador.Items.AddRange(todos.ToArray());

            cboOperador.EndUpdate();
        }

        private void cboUnidad_TextUpdate(object sender, EventArgs e)
        {
            try
            {
                string texto = cboUnidad.Text.Trim().ToLower();

                if (dtUnidades == null || dtUnidades.Rows.Count == 0)
                    return;

                string currentText = cboUnidad.Text;
                int selStart = cboUnidad.SelectionStart;

                cboUnidad.BeginUpdate();
                cboUnidad.Items.Clear();

                var matches = dtUnidades.AsEnumerable()
                    .Where(row => row["cCveUni"].ToString()!.ToLower().Contains(texto))
                    .Select(row => row["cCveUni"].ToString())
                    .Distinct()
                    .ToList();

                if (matches.Any())
                {
                    cboUnidad.Items.AddRange(matches.ToArray());

                    // Solo abrir dropdown si hay ítems y aún no está abierto
                    if (cboUnidad.Items.Count > 0 && !cboUnidad.DroppedDown)
                        cboUnidad.DroppedDown = true;
                }
                else
                {
                    if (cboUnidad.DroppedDown)
                        cboUnidad.DroppedDown = false;
                }

                // Restaurar el texto y validar la posición del cursor
                cboUnidad.Text = currentText;
                cboUnidad.SelectionStart = Math.Min(selStart, cboUnidad.Text.Length);
                cboUnidad.SelectionLength = 0;
            }
            catch (ArgumentOutOfRangeException)
            {
                // Prevenir caída en caso de cambios rápidos
            }
            finally
            {
                cboUnidad.EndUpdate();
            }
        }

        private void cboUnidad_Leave(object sender, EventArgs e)
        {
            string nombre = cboUnidad.Text.Trim();

            var encontrado = dtUnidades.AsEnumerable()
                .FirstOrDefault(row => row["cCveUni"].ToString().Equals(nombre, StringComparison.OrdinalIgnoreCase));

            if (encontrado != null)
            {
                Unidad = encontrado["cCveUni"].ToString()!;
            }
            else
            {
                cboUnidad.Text = string.Empty;

                // Restaurar el listado completo de despachadores
                RestablecerComboUnidades();
            }
        }

        private void RestablecerComboUnidades()
        {
            if (dtUnidades == null || dtUnidades.Rows.Count == 0)
                return;

            cboUnidad.BeginUpdate();
            cboUnidad.Items.Clear();

            var todos = dtUnidades.AsEnumerable()
                .Select(row => row["cCveUni"].ToString())
                .Distinct()
                .ToList();

            if (todos.Any())
                cboUnidad.Items.AddRange(todos.ToArray());

            cboUnidad.EndUpdate();
        }

        private void bloquearControles()
        {
            cboDespachador.Enabled = false;
            cboOperador.Enabled = false;
            cboUnidad.Enabled = false;
            txtKilometraje.Enabled = false;
            txtLitDesp.Enabled = false;
            txtNumPas.Enabled = false;
            rtxObservaciones.Enabled = false;
            pbFotoUnidad.Enabled = false;
            pbFotoKilometraje.Enabled = false;
            pbFotoTAC.Enabled = false;
            pbFotoCL.Enabled = false;
            pbFotoTDC.Enabled = false;
            btnGrabar.Enabled = false;
        }

        private void HabilitarControles()
        {
            cboDespachador.Enabled = true;
            cboOperador.Enabled = true;
            cboUnidad.Enabled = true;
            txtKilometraje.Enabled = true;
            txtLitDesp.Enabled = true;
            txtNumPas.Enabled = true;
            rtxObservaciones.Enabled = true;
            pbFotoUnidad.Enabled = true;
            pbFotoKilometraje.Enabled = true;
            pbFotoTAC.Enabled = true;
            pbFotoCL.Enabled = true;
            pbFotoTDC.Enabled = true;
            btnGrabar.Enabled = true;
        }

        private void LimpiarFormulario()
        {
            cboDespachador.SelectedIndex = -1;
            cboOperador.SelectedIndex = -1;
            cboUnidad.SelectedIndex = -1;
            txtKilometraje.Text = "";
            txtLitDesp.Text = "";
            txtNumPas.Text = "";
            rtxObservaciones.Text = "";

            if (pbFotoUnidad.Image != null)
            {
                pbFotoUnidad.Image.Dispose();
                pbFotoUnidad.Image = null;
            }

            if (pbFotoKilometraje.Image != null)
            {
                pbFotoKilometraje.Image.Dispose();
                pbFotoKilometraje.Image = null;
            }

            if (pbFotoTAC.Image != null)
            {
                pbFotoTAC.Image.Dispose();
                pbFotoTAC.Image = null;
            }

            if (pbFotoCL.Image != null)
            {
                pbFotoCL.Image.Dispose();
                pbFotoCL.Image = null;
            }

            if (pbFotoTDC.Image != null)
            {
                pbFotoTDC.Image.Dispose();
                pbFotoTDC.Image = null;
            }
        }

        public async Task<bool> ObtenerTokenAsync(string usuario, string password)
        {
            try
            {
                var httpClient = ServicioApi.Client;
                var content = new StringContent(JsonSerializer.Serialize(new { usuario, password }), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("https://" + dominio_Api + "/api_ureap/login", content);

                if (response.IsSuccessStatusCode)
                {
                    var result = JsonSerializer.Deserialize<Dictionary<string, string>>(await response.Content.ReadAsStringAsync());
                    if (result.ContainsKey("token"))
                    {
                        token = result["token"];
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> SincronizarConServidorAsync(string cCveEmp, string cCveOpe, string cCveUni, string nKilometraje, string nLitrosDespachados, string nNumPase, string Observaciones,
                                                            string pbFotoUnidad, string pbFotoKilometraje, string pbFotoTAC, string pbFotoCL, string pbFotoTDC)
        {
            try
            {
                bool ObtieneToken = await ObtenerTokenAsync("xhodaraoz", "XmaiN16xDt@@MA");


                if (ObtieneToken)
                {

                    var httpClient = ServicioApi.Client;
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    var formData = new MultipartFormDataContent();

                    // Agregar campos de texto
                    formData.Add(new StringContent(cCveUni), "cCveUni");
                    formData.Add(new StringContent(cCveOpe), "cCveOpe");
                    formData.Add(new StringContent(nKilometraje), "nKilometraje");
                    formData.Add(new StringContent(nLitrosDespachados), "nLitrosDespachados");
                    formData.Add(new StringContent(cCveEmp), "cCveEmp");
                    formData.Add(new StringContent(nNumPase), "nNumPase");
                    formData.Add(new StringContent(Observaciones), "Observaciones");

                    // Agregar imágenes como archivos, las comprime antes de enviarlas al servidor
                    formData.Add(new StreamContent(ImagenHelper.ComprimirImagen(pbFotoUnidad)), "cFoto_Unidad", Path.GetFileName(pbFotoUnidad));
                    formData.Add(new StreamContent(ImagenHelper.ComprimirImagen(pbFotoKilometraje)), "cFoto_Kilometraje", Path.GetFileName(pbFotoKilometraje));
                    formData.Add(new StreamContent(ImagenHelper.ComprimirImagen(pbFotoTAC)), "cFoto_Tablero_Antes_Carga", Path.GetFileName(pbFotoTAC));
                    formData.Add(new StreamContent(ImagenHelper.ComprimirImagen(pbFotoCL)), "cFoto_Cuenta_Litros", Path.GetFileName(pbFotoCL));
                    formData.Add(new StreamContent(ImagenHelper.ComprimirImagen(pbFotoTDC)), "cFoto_Tablero_Despues_Carga", Path.GetFileName(pbFotoTDC));


                    var response = await httpClient.PostAsync("https://" + dominio_Api + "/api_ureap/insDespUrea", formData);

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
                    {
                        string error = await response.Content.ReadAsStringAsync();
                        mensajeError = error;
                        return false;
                    }
                    else
                    {
                        string error = await response.Content.ReadAsStringAsync();
                        mensajeError = error;
                        return false;
                    }
                }
                else
                {
                    mensajeError = "No se pudo sincronizar el registro. Intenta más tarde.";
                    return false;
                }
            }
            catch (TaskCanceledException ex) when (!ex.CancellationToken.IsCancellationRequested)
            {
                // Esto significa que fue por timeout
                mensajeError = "Tiempo de espera agotado";
                return false;
            }
            catch (Exception ex)
            {
                mensajeError = ex.ToString();
                return false;
            }
        }

        public async Task<bool> ActualizarInventarioUreaAsync(string Unidad, decimal LtosDespachados, string Despachador)
        {
            int id = 1;
            try
            {
                bool ObtieneToken = await ObtenerTokenAsync("xhodaraoz", "XmaiN16xDt@@MA");

                if (ObtieneToken)
                {
                    var httpClient = ServicioApi.Client;
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    var jsonData = new
                    {
                        LitrosDespachados = LtosDespachados
                    };

                    var content = new StringContent(JsonSerializer.Serialize(jsonData), Encoding.UTF8, "application/json");

                    var response = await httpClient.PutAsync("https://" + dominio_Api + $"/api_ureap/actualiza_invurea/{id}", content);

                    if (response.IsSuccessStatusCode)
                    {
                        //await App.Current.MainPage.DisplayAlert("Éxito", "Inventario de urea actualizado.", "OK");
                        await EnviarNotificacionDespachoAsync(Unidad, LtosDespachados, Despachador);
                        return true;
                    }
                    else
                    {
                        string error = await response.Content.ReadAsStringAsync();
                        mensajeError = "No se actualizo el inventario";
                        return false;
                    }
                }
                else
                {
                    mensajeError = "No se pudo sincronizar el registro. Intenta más tarde.";
                    return false;
                }
            }
            catch (TaskCanceledException ex) when (!ex.CancellationToken.IsCancellationRequested)
            {
                mensajeError = "Tiempo de espera agotado";
                return false;
            }
            catch (Exception ex)
            {
                mensajeError = ex.ToString();
                return false;
            }
        }

        public async Task EnviarNotificacionDespachoAsync(string Unidad, decimal LitrosDespachados, string Usuario)
        {
            var url = "http://pruebasdesarrollo.ddns.net:5182/api/UreaDespacho/notify";

            var datos = new
            {
                Unidad,
                LitrosDespachados,
                CostoPorLitro = 20,
                Usuario
            };

            try
            {
                var httpClient = ServicioApi.Client;

                var json = JsonSerializer.Serialize(datos);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    // Éxito: puedes mostrar un mensaje al usuario si deseas
                    //var respuestaContenido = await response.Content.ReadAsStringAsync();
                    //Console.WriteLine("Éxito: " + respuestaContenido);
                }
                else
                {
                    // Error del servidor o en la solicitud
                    //var error = await response.Content.ReadAsStringAsync();
                    //Console.WriteLine($"Error: {response.StatusCode} - {error}");
                }
            }
            catch (Exception ex)
            {
                // Error de conexión u otro tipo de excepción
                //Console.WriteLine("Excepción: " + ex.Message);
            }
        }

        private async void btnGrabar_Click(object sender, EventArgs e)
        {
            string fotoUnidad = pbFotoUnidad.Tag?.ToString()!;
            string fotoKilometraje = pbFotoKilometraje.Tag?.ToString()!;
            string fotoTAC = pbFotoTAC.Tag?.ToString()!;
            string fotoCL = pbFotoCL.Tag?.ToString()!;
            string fotoTDC = pbFotoTDC.Tag?.ToString()!;

            // 1. Validar en el hilo de UI
            if (cboDespachador.SelectedIndex == -1 || cboOperador.SelectedIndex == -1 || cboUnidad.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtKilometraje.Text) || txtKilometraje.Text == "0" ||
                string.IsNullOrWhiteSpace(txtLitDesp.Text) || txtLitDesp.Text == "0" ||
                string.IsNullOrEmpty(fotoUnidad) || string.IsNullOrEmpty(fotoKilometraje) || string.IsNullOrEmpty(fotoTAC) ||
                string.IsNullOrEmpty(fotoCL) || string.IsNullOrEmpty(fotoTDC))
            {
                MessageBox.Show("Faltan datos");
                return;
            }

            string Kilometraje = txtKilometraje.Text;
            string LitrosDespachados = txtLitDesp.Text;
            string NumeroPase = "0";
            string Observaciones = "Sin Observaciones";
            if (!string.IsNullOrWhiteSpace(txtNumPas.Text))
            {
                NumeroPase = txtNumPas.Text;
            }

            if (!string.IsNullOrWhiteSpace(rtxObservaciones.Text))
            {
                Observaciones = rtxObservaciones.Text;
            }

            bloquearControles();
            bool exito = false;
            bool registroSubido = false;
            bool inventarioActualizado = false;

            try
            {
                exito = await Task.Run(async () =>
                {
                    registroSubido = await SincronizarConServidorAsync(Despachador, Operador, Unidad, Kilometraje, LitrosDespachados, NumeroPase, Observaciones, fotoUnidad, fotoKilometraje, fotoTAC, fotoCL, fotoTDC);
                    if (registroSubido)
                    {
                        inventarioActualizado = await ActualizarInventarioUreaAsync(Unidad, Convert.ToDecimal(LitrosDespachados), Despachador);
                    }

                    return inventarioActualizado;
                });

                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al guardar: {ex.Message}");
            }
            finally
            {
                HabilitarControles();
            }

            if (exito)
            {
                MessageBox.Show("Éxito", "Registro sincronizado correctamente.");
            }
            else
            {
                if (registroSubido == false)
                {
                    MessageBox.Show(mensajeError);
                }

                if (inventarioActualizado == false)
                {
                    MessageBox.Show(mensajeError);
                }


            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
