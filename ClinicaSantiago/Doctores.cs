using ClinicaSantiago.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using ClinicaSantiago.Comunes;

namespace ClinicaSantiago
{
    public partial class Doctores : Form
    {
        SqlConnection sqlCon = new SqlConnection(ConexionBD.ConString);

        public Doctores()
        {
            InitializeComponent();
            usuariodoctortxt.Visible = false;
            contrasenadoctortxt.Visible = false;
            permisologinchk.Checked = true;
            Doctores_Load();
        }

        private void guardarbtn_Click(object sender, EventArgs e)
        {
            if (nombredoctortxt.Text.Trim() == "" || anosexpetxt.Text.Trim() == "" || edaddoctortxt.Text.Trim() == "" || contactodoctortxt.Text.Trim() == "" || direcciontxt.Text.Trim() == "")
            {
                MessageBox.Show("Completa todos los campos.");
            }
            else
            {
                // ... (validaciones iniciales)

                using (SqlConnection conn = new SqlConnection(ConexionBD.ConString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        string query = "";
                        int userLoginId = 0;
                        bool hasError = false;
                        if (permisologinchk.Checked)
                        {
                            if (usuariodoctortxt.Text.Trim() == "" || contrasenadoctortxt.Text.Trim() == "")
                            {
                                MessageBox.Show("Completa los campos de nombre de usuario y contraseña.");
                                hasError = true;
                            }
                            else
                            {
                                // ... (código para insertar usuario si es necesario)

                                query = @"INSERT INTO Usuario (NombreUsuario,Contrasena,TipoUsuario,FechaAgregado,AgregadoPor) VALUES (@NombreUsuario,@Contrasena,@TipoUsuario,@FechaAgregado,@AgregadoPor);
                                        SELECT SCOPE_IDENTITY();";

                                SqlCommand command = new SqlCommand(query, conn, transaction);
                                command = new SqlCommand(query, conn, transaction);
                                command.Parameters.AddWithValue("@NombreUsuario", usuariodoctortxt.Text.Trim());
                                command.Parameters.AddWithValue("@Contrasena", contrasenadoctortxt.Text.Trim());
                                command.Parameters.AddWithValue("@TipoUsuario", 2); //iD 2 significa doctor
                                command.Parameters.AddWithValue("@FechaAgregado", DateTime.Now);
                                command.Parameters.AddWithValue("@AgregadoPor", Global.InfoUsuario.IDUsuario);

                                userLoginId = Convert.ToInt32(command.ExecuteScalar());
                            }
                        }
                        if (!hasError)
                        {

                            // Insertar un nuevo doctor en la tabla 'Doctor'


                            query = @"INSERT INTO Doctor (NombreDoctor,FechaNacimiento,AnosExperiencia,Contacto,Direccion,IDUsuarioDoc,FechaAgregado,AgregadorPor) VALUES (@NombreDoctor,@FechaNacimiento,@AnosExperiencia,@Contacto,@Direccion,@IDUsuarioDoc,@FechaAgregado,@AgregadorPor)";
                            SqlCommand command1 = new SqlCommand(query, conn, transaction);
                            command1.Parameters.AddWithValue("@NombreDoctor", nombredoctortxt.Text.Trim());
                            command1.Parameters.AddWithValue("@FechaNacimiento", edaddoctortxt.Text.Trim());
                            command1.Parameters.AddWithValue("@AnosExperiencia", anosexpetxt.Text.Trim());
                            command1.Parameters.AddWithValue("@Contacto", contactodoctortxt.Text.Trim());
                            command1.Parameters.AddWithValue("@Direccion", direcciontxt.Text.Trim());
                            command1.Parameters.AddWithValue("@IDUsuarioDoc", userLoginId);
                            command1.Parameters.AddWithValue("@FechaAgregado", DateTime.Now);
                            command1.Parameters.AddWithValue("@AgregadorPor", Global.InfoUsuario.IDUsuario);
                            command1.ExecuteNonQuery();
                            transaction.Commit();

                            MessageBox.Show("El doctor se ha creado correctamente.");
                            Doctores_Load();
                            Reset();
                        }
                        else
                        {
                            transaction.Rollback();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        transaction.Rollback();
                    }
                    finally
                    {
                        conn.Close();
                    }
                }

            }
        }

        private void Doctores_Load()
        {
            sqlCon = MetodosComunes.OpenConnectionString(sqlCon);
            string query = "SELECT * FROM VistaDoctor"; // Cargar los doctores
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlCon);
            SqlCommandBuilder scb = new SqlCommandBuilder(sda);
            var dataSet = new DataSet();
            sda.Fill(dataSet);
            doctoresdgv.DataSource = dataSet.Tables[0];
            sqlCon.Close();

            doctoresdgv.Columns[0].Visible = false;
        }

        private void Reset()
        {
            IDDoctortxt.Text = 0.ToString();
            LoginIDDoctortxt.Text = 0.ToString();
            nombredoctortxt.Text = "";
            anosexpetxt.Text = "";
            edaddoctortxt.Text = "";
            contactodoctortxt.Text = "";
            direcciontxt.Text = "";
            usuariodoctortxt.Text = "";
            contrasenadoctortxt.Text = "";
        }

        private void editarbtn_Click(object sender, EventArgs e)
        {
            // Validar si se seleccionó un doctor
            if (string.IsNullOrWhiteSpace(IDDoctortxt.Text) || IDDoctortxt.Text == "0")
            {
                MessageBox.Show("Seleccione un Doctor");
                return; // Salir si no se seleccionó ningún doctor
            }

            // Validar que los campos obligatorios estén llenos
            if (string.IsNullOrWhiteSpace(nombredoctortxt.Text) ||
                string.IsNullOrWhiteSpace(anosexpetxt.Text) ||
                string.IsNullOrWhiteSpace(edaddoctortxt.Text) ||
                contactodoctortxt.Text == "Category" || // Asumiendo que "Category" es un valor por defecto
                string.IsNullOrWhiteSpace(direcciontxt.Text))
            {
                MessageBox.Show("Complete todos los campos");
                return; // Salir si algún campo obligatorio está vacío
            }

            using (SqlConnection conn = new SqlConnection(ConexionBD.ConString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction(); // Iniciar una transacción

                try
                {
                    bool hasError = false;
                    string query;

                    if (permisologinchk.Checked)
                    {
                        // Actualizar credenciales de usuario si "Permiso de Login" está marcado
                        if (string.IsNullOrWhiteSpace(usuariodoctortxt.Text) ||
                            string.IsNullOrWhiteSpace(contrasenadoctortxt.Text))
                        {
                            MessageBox.Show("Complete con nombre de usuario y contraseña.");
                            hasError = true;
                        }
                        else
                        {
                            // Consulta SQL para actualizar credenciales de usuario
                            query = @"
                        UPDATE Usuario 
                        SET NombreUsuario = @NombreUsuario, 
                            Contrasena = @Contrasena,
                            FechaActualizado = @FechaActualizado,
                            ActualizadoPor = @ActualizadoPor
                        WHERE IDUsuario = @IDUsuario";

                            using (SqlCommand command = new SqlCommand(query, conn, transaction))
                            {
                                // Asignar valores a los parámetros de la consulta
                                command.Parameters.AddWithValue("@IDUsuario", IDDoctortxt.Text.Trim());
                                command.Parameters.AddWithValue("@NombreUsuario", usuariodoctortxt.Text.Trim());
                                command.Parameters.AddWithValue("@Contrasena", contrasenadoctortxt.Text.Trim());
                                command.Parameters.AddWithValue("@FechaActualizado", DateTime.Now);
                                command.Parameters.AddWithValue("@ActualizadoPor", Global.InfoUsuario.IDUsuario);
                                command.ExecuteNonQuery(); // Ejecutar la consulta
                            }
                        }
                    }
                    else  // Si "Permiso de Login" NO está marcado
                    {
                        // Eliminar el usuario asociado si el ID es válido
                        if (string.IsNullOrWhiteSpace(IDDoctortxt.Text) || IDDoctortxt.Text == "0")
                        {
                            MessageBox.Show("ID de usuario inválido.");
                            hasError = true;
                        }
                        else
                        {
                            // Consulta SQL para eliminar el usuario
                            query = "DELETE FROM Usuario WHERE IDUsuario = @IDUsuario";
                            using (SqlCommand command = new SqlCommand(query, conn, transaction))
                            {
                                command.Parameters.AddWithValue("@IDUsuario", IDDoctortxt.Text.Trim());
                                command.ExecuteNonQuery(); // Ejecutar la consulta
                            }
                        }
                    }

                    // Actualizar informacion del doctor si no hay errores
                    if (!hasError)
                    {
                        // Consulta SQL para actualizar información del doctor
                        query = @"
                        UPDATE Doctor 
                        SET NombreDoctor = @NombreDoctor, 
                            FechaNacimiento = @FechaNacimiento, 
                            AnosExperiencia = @AnosExperiencia, 
                            Contacto = @Contacto, 
                            Direccion = @Direccion,
                            FechaActualizacion = @FechaActualizacion,
                            ActualizadoPor = @ActualizadoPor 
                        WHERE IDDoctor = @IDDoctor";

                        using (SqlCommand command1 = new SqlCommand(query, conn, transaction))
                        {
                            // Asignar valores a los parámetros de la consulta
                            command1.Parameters.AddWithValue("@IDDoctor", IDDoctortxt.Text.Trim());
                            command1.ExecuteNonQuery(); // Ejecutar la consulta
                        }

                        transaction.Commit(); // Confirmar la transacción si todo salió bien
                        MessageBox.Show("El Doctor ha sido actualizado correctamente.");
                        Doctores_Load(); // Actualizar la lista de doctores (asumiendo que tienes este método)
                        Reset();    
                    }
                    else
                    {
                        transaction.Rollback(); // Revertir la transacción si hubo errores
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    transaction.Rollback(); // Revertir la transacción en caso de error
                }
            }
        }


        private void eliminarbtn_Click(object sender, EventArgs e)
        {
            // Validar que se haya seleccionado un doctor
            if (string.IsNullOrWhiteSpace(IDDoctortxt.Text) || Convert.ToInt32(IDDoctortxt.Text) == 0)
            {
                MessageBox.Show("Seleccione un doctor.");
                return;
            }

            // Verificar si el doctor tiene diagnósticos asociados
            using (SqlConnection conn = new SqlConnection(ConexionBD.ConString))
            {
                conn.Open();
                // Consulta para obtener diagnósticos del doctor usando parámetros
                string query = "SELECT COUNT(*) FROM Diagnostico WHERE IDDoctor = @IDDoctor";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@IDDoctor", Convert.ToInt32(IDDoctortxt.Text));
                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("El doctor tiene diagnosticos asociados. No puede borrarlo.");
                        return; // Salir si el doctor tiene diagnósticos
                    }
                }
            }

            // Eliminar al doctor si no tiene diagnósticos
            using (SqlConnection conn = new SqlConnection(ConexionBD.ConString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Eliminar al doctor usando parámetros
                    string query = "DELETE FROM Doctor WHERE IDDoctor = @IDDoctor";
                    using (SqlCommand command = new SqlCommand(query, conn, transaction))
                    {
                        command.Parameters.AddWithValue("@IDDoctor", Convert.ToInt32(IDDoctortxt.Text));
                        command.ExecuteNonQuery();
                    }

                    // Eliminar el usuario asociado usando parametros
                    query = "DELETE FROM Usuario WHERE IDUsuario = @IDUsuario";
                    using (SqlCommand command = new SqlCommand(query, conn, transaction))
                    {
                        command.Parameters.AddWithValue("@IDUsuario", LoginIDDoctortxt.Text.Trim());
                        command.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show("Doctor Borrado Exitosamente.");
                    Doctores_Load();
                    Reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    transaction.Rollback();
                }
            }
        }



        private void doctorDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (doctoresdgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null && !string.IsNullOrWhiteSpace(doctoresdgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
            {
                doctoresdgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = new DataGridViewCellStyle { ForeColor = Color.Black };
            }
            else
            {
                doctoresdgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = doctoresdgv.DefaultCellStyle;
            }
        }

        private void permisologinchk_CheckedChanged(object sender, EventArgs e)
        {
            HideShowUsernamePassword();
        }

        private void HideShowUsernamePassword()
        {
            usuariodoctortxt.Visible = permisologinchk.Checked;
            contrasenadoctortxt.Visible = permisologinchk.Checked;
        }

        private void doctoresdgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                IDDoctortxt.Text = doctoresdgv.Rows[e.RowIndex].Cells["IDDoctor"].Value.ToString();
                LoginIDDoctortxt.Text = doctoresdgv.Rows[e.RowIndex].Cells["IDUsuarioDoc"].Value.ToString();
                nombredoctortxt.Text = doctoresdgv.Rows[e.RowIndex].Cells["NombreDoctor"].Value.ToString();
                edaddoctortxt.Text = doctoresdgv.Rows[e.RowIndex].Cells["FechaNacimiento"].Value.ToString();
                anosexpetxt.Text = doctoresdgv.Rows[e.RowIndex].Cells["AnosExperiencia"].Value.ToString();
                contactodoctortxt.Text = doctoresdgv.Rows[e.RowIndex].Cells["Contacto"].Value.ToString();
                direcciontxt.Text = doctoresdgv.Rows[e.RowIndex].Cells["Direccion"].Value.ToString();

                int loginUserId = Convert.ToInt32(doctoresdgv.Rows[e.RowIndex].Cells["IDUsuarioDoc"].Value.ToString());
                permisologinchk.Checked = loginUserId > 0 ? true : false;
                HideShowUsernamePassword();
                usuariodoctortxt.Text = doctoresdgv.Rows[e.RowIndex].Cells["NombreUsuario"].Value.ToString();
                contrasenadoctortxt.Text = doctoresdgv.Rows[e.RowIndex].Cells["Contrasena"].Value.ToString();
            }
            else
            {
                permisologinchk.Checked = false;
                usuariodoctortxt.Text = "";
                contrasenadoctortxt.Text = "";
            }
        }
    }
}