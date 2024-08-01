using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using ClinicaSantiago.DB;
using ClinicaSantiago.Comunes;

namespace ClinicaSantiago
{
    public partial class Login : Form
    {
        SqlConnection sqlCon = new SqlConnection(ConexionBD.ConString);

        public Login()
        {
            InitializeComponent();
            loginbtn.Focus();
        }

        // Manejador del evento de clic en el botón de inicio de sesión
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(usuariotxt.Text) || string.IsNullOrWhiteSpace(contrasenatxt.Text))
            {
                MessageBox.Show("Introduzca el nombre de usuario y la contraseña.");
                usuariotxt.Focus(); // Enfocar el cuadro de texto del usuario si falta alguno
                return; // Detener la ejecución si faltan datos
            }

            try
            {
                sqlCon = MetodosComunes.OpenConnectionString(sqlCon);
                string query = $@"SELECT * FROM VistaInfoUsuario 
                                  WHERE NombreUsuario='{usuariotxt.Text.Trim()}' 
                                  AND Contrasena='{contrasenatxt.Text.Trim()}'";

                using (SqlDataAdapter sda = new SqlDataAdapter(query, sqlCon))
                {
                    DataTable dataTable = new DataTable();
                    sda.Fill(dataTable);
                    if (dataTable.Rows.Count
 > 0)
                    {
                        this.Hide();
                        MenuPrincipal form = new MenuPrincipal();
                        form.Show();
                        MetodosComunes.GetInfoUsuario(dataTable);
                    }
                    else
                    {
                        MessageBox.Show("Nombre de usuario o contraseña incorrectos.");
                        usuariotxt.Focus(); 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al iniciar sesión: {ex.Message}");
            }
            finally
            {
                sqlCon.Close(); // Asegurarse de cerrar la conexión en todos los casos
            }
        }


        // Manejador del evento de clic en el enlace para crear usuario
        private void crearusuariolinklbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(usuariotxt.Text) || string.IsNullOrWhiteSpace(contrasenatxt.Text))
            {
                MessageBox.Show("Introduzca el nombre de usuario y la contraseña.");
                usuariotxt.Focus();
                return;
            }

            try
            {
               // Insercion de datos de usuario creado
                sqlCon = MetodosComunes.OpenConnectionString(sqlCon);
                string query = @"INSERT INTO Usuario (NombreUsuario, Contrasena, TipoUsuario, FechaAgregado, AgregadoPor) 
                                VALUES (@NombreUsuario, @Contraseña, @TipoUsuario, @FechaAgregado, @AgregadoPor)";
                using (SqlCommand command = new SqlCommand(query, sqlCon))
                {
                    command.Parameters.AddWithValue("@NombreUsuario", usuariotxt.Text.Trim());
                    command.Parameters.AddWithValue("@Contraseña", contrasenatxt.Text.Trim()); // Corrección en el nombre del parámetro
                    command.Parameters.AddWithValue("@TipoUsuario", 1); // Asumiendo que 1 es el tipo de usuario estándar
                    command.Parameters.AddWithValue("@FechaAgregado", DateTime.Now);
                    command.Parameters.AddWithValue("@AgregadoPor", Global.InfoUsuario.IDUsuario); // Asumiendo que Global.InfoUsuario está disponible
                    command.ExecuteNonQuery();
                }
                MessageBox.Show("Registro exitoso. Ahora inicia sesión.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear usuario: {ex.Message}");
            }
            finally
            {
                sqlCon.Close(); // Asegurarse de cerrar la conexión
            }
        }
    }
}