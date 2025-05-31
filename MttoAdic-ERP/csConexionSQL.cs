namespace MttoAdic_ERP
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms; // Necesario para MessageBox.Show

    public class csConexionSQL
    {
        string cadena = "";
        SqlConnection conexion;
        DataTable datos = new DataTable();
        SqlDataAdapter adaptador = new SqlDataAdapter();
        SqlCommand comando = new SqlCommand(); // Este comando se usa en select, ejecSql

        public csConexionSQL(string srv, string bd, string user, string pwd)
        {
            cadena = "Data Source=" + srv + ";Initial Catalog=" + bd + ";Persist Security Info=True;User ID=" + user + ";Password=" + pwd;
            conexion = new SqlConnection(cadena);
            comando.Connection = conexion; // Asignar la conexión al comando de una vez
        }

        public SqlConnection getConexion()
        {
            try
            {
                if (conexion.State == ConnectionState.Closed)
                {
                    conexion.Open();
                }
                // comando.Connection = conexion; // Ya se asignó en el constructor
            }
            catch (SqlException ex)
            {
                // Un mejor manejo de errores sería lanzar una excepción más descriptiva
                MessageBox.Show("Error al abrir la conexión SQL: " + ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception("No se pudo establecer la conexión a la base de datos.");
            }
            return conexion;
        }

        public void cerrarconex()
        {
            if (conexion.State == ConnectionState.Open)
                conexion.Close();
        }

        public DataTable select(string SQLsentencia)
        {
            datos = new DataTable();
            comando.CommandText = SQLsentencia;
            comando.CommandTimeout = 300;

            // Limpiar parámetros antiguos para evitar conflictos
            comando.Parameters.Clear();

            adaptador.SelectCommand = comando; // Esto es correcto

            try
            {
                if (conexion.State == ConnectionState.Closed)
                    getConexion(); // Abre la conexión si está cerrada
                adaptador.Fill(datos);
            }
            catch (SqlException ex)
            {
                cerrarconex();
                MessageBox.Show("Error de base de datos en SELECT: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception("Error al ejecutar la consulta SELECT.");
            }
            catch (Exception ex)
            {
                cerrarconex();
                MessageBox.Show("Error general en SELECT: " + ex.Message, "Error General", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception("Error inesperado al ejecutar la consulta SELECT.");
            }
            return datos;
        }

        // --- Nuevo método para el login ---
        public (bool IsValid, int NivelUsuario, string ClaveEmpleado, string cUsuario) ValidarCredenciales(string username, string password)
        {
            try
            {

                string query = $"SELECT nNivelUsuario, cClaveEmpleado , cUsuario FROM tbUsuarios WHERE cClaveEmpleado = '{username}' AND cClaveUsuario = '{password}'";

                DataTable resultado = select(query); // Utiliza tu método select

                if (resultado != null && resultado.Rows.Count > 0)
                {
                    // Se encontraron credenciales válidas
                    DataRow row = resultado.Rows[0];
                    int nivelUsuario = Convert.ToInt32(row["nNivelUsuario"]);
                    string claveEmpleado = row["cClaveEmpleado"].ToString();
                    string cUsuario = row["cUsuario"].ToString();
                    return (true, nivelUsuario, claveEmpleado, cUsuario);
                }
                else
                {
                    // No se encontraron coincidencias
                    return (false, 0, null, null);
                }
            }
            catch (Exception ex)
            {
                // Los errores de conexión/consulta ya deberían ser manejados por 'select'
                // pero si hay un error aquí (ej. en la conversión de tipos), lo capturamos.
                MessageBox.Show("Error al validar credenciales: " + ex.Message, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (false, 0, null, null);
            }
            finally
            {
                cerrarconex(); // Asegúrate de cerrar la conexión después de usarla
            }
        }
        // --- Fin del nuevo método para el login ---


        public T Select<T>(string SqlSentencia)
        {
            T Valor = default(T);

            DataTable d = select(SqlSentencia);

            if (d.Rows.Count > 0)
                Valor = (T)Convert.ChangeType(d.Rows[0][0], typeof(T), null);

            return Valor;
        }

        public bool ejecSql(string SQLsentencia)
        {
            comando.CommandText = SQLsentencia;
            comando.Parameters.Clear(); // Limpiar parámetros antiguos

            try
            {
                getConexion(); // Asegura que la conexión esté abierta

                int nFilasAfec = comando.ExecuteNonQuery(); // Ejecuta la consulta
                return true;
            }
            catch (Exception ex)
            {
                cerrarconex();
                MessageBox.Show("Error al ejecutar sentencia SQL: " + ex.Message + "\n\nDetalles:\n" + ex.ToString(), "Excepción SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                cerrarconex(); // Asegúrate de cerrar la conexión
            }
        }

        public int ejecSql(string SQLsentencia, int cero) // No es ideal tener un 'cero' como parámetro
        {
            int nFilasAfec = 0;
            comando.CommandText = SQLsentencia;
            comando.Parameters.Clear(); // Limpiar parámetros antiguos

            try
            {
                getConexion();

                nFilasAfec = comando.ExecuteNonQuery(); // Ejecuta la consulta
                return nFilasAfec;
            }
            catch (Exception ex)
            {
                cerrarconex();
                MessageBox.Show("Error al ejecutar sentencia SQL (con retorno int): " + ex.Message, "Excepción SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception("Error al ejecutar la consulta con retorno int.", ex); // Relanza la excepción con detalles
            }
            finally
            {
                cerrarconex(); // Asegúrate de cerrar la conexión
            }
        }

        public List<T> ConsultarList<T>(string Query)
        {
            try
            {
                List<T> lista = new List<T>();
                Type tipo = typeof(T);
                foreach (DataRow dr in this.select(Query).Rows)
                {
                    T objeto = (T)tipo.GetConstructor(new Type[] { }).Invoke(new object[] { });
                    foreach (System.Reflection.PropertyInfo p in tipo.GetProperties())
                    {
                        if (dr.Table.Columns.Contains(p.Name) && dr[p.Name] != DBNull.Value) // Verificar si la columna existe y no es DBNull
                        {
                            Type pt = p.PropertyType;

                            if (pt.IsGenericType && pt.GetGenericTypeDefinition() == typeof(Nullable<>)) // Manejar Nullable<T>
                            {
                                pt = Nullable.GetUnderlyingType(pt);
                            }

                            if (pt.IsEnum)
                                p.SetValue(objeto, Enum.Parse(pt, dr[p.Name].ToString()), null); // Parsear a Enum desde string
                            else
                                p.SetValue(objeto, Convert.ChangeType(dr[p.Name], pt, null), null);
                        }
                    }
                    lista.Add(objeto);
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar lista: " + ex.Message, "Error de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception("Error en ConsultarList<T>.", ex); // Relanza con el detalle
            }
        }

        public T Consultar<T>(string SqlSentencia)
        {
            Type Tipo = typeof(T);

            DataTable Tabla = this.select(SqlSentencia);

            if (Tabla.Rows.Count == 0)
                throw new Exception("La consulta no devolvió ningún resultado.");
            else if (Tabla.Rows.Count > 1)
                throw new Exception("La consulta devuelve más de un registro.");
            else
                try
                {
                    // Asegúrate de que el valor no sea DBNull antes de convertir
                    if (Tabla.Rows[0][0] == DBNull.Value)
                    {
                        return default(T); // Si es nulo en BD y el tipo T permite nulos
                    }
                    return (T)Convert.ChangeType(Tabla.Rows[0][0], Tipo, null);
                }
                catch (FormatException fEx)
                {
                    throw new Exception("La consulta no devuelve un tipo de valor compatible con el tipo especificado.", fEx);
                }
                catch (InvalidCastException icEx)
                {
                    throw new Exception("Error de conversión de tipo en la consulta.", icEx);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error inesperado en Consultar<T>.", ex);
                }
                finally
                {
                    cerrarconex(); // Asegúrate de cerrar la conexión
                }
        }
    }
}