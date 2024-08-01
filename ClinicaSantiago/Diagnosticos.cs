using ClinicaSantiago.Comunes;
using ClinicaSantiago.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaSantiago
{
    public partial class Diagnosticos : Form
    {
        SqlConnection sqlCon = new SqlConnection(ConexionBD.ConString);

        public Diagnosticos()
        {
            InitializeComponent();
            CargarPacientes();
        }

        private void CargarPacientes()
        {
            using (SqlConnection conn = new SqlConnection(ConexionBD.ConString))
            {
                try
                {
                    string query = "select IDPaciente, Nombre from Paciente";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    conn.Open(); // Abrir la conexión después de crear el adaptador
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Paciente");

                    pacientecbx.DisplayMember = "Nombre";
                    pacientecbx.ValueMember = "IDPaciente";
                    pacientecbx.DataSource = ds.Tables["Paciente"];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los pacientes: " + ex.Message); // Mensaje de error más específico
                }
            }
        }

        private void pacientecbx_SelectedValueChanged(object sender, EventArgs e)
        {
            CargarINfoPacientes();
        }
        private void CargarINfoPacientes()
        {
            int patientId = Convert.ToInt32(pacientecbx.SelectedValue);
            if (patientId > 0)
            {
                // Usamos un bloque 'using' para asegurarnos de que la conexión se cierre automáticamente
                using (SqlConnection conn = new SqlConnection(ConexionBD.ConString))
                {
                    conn.Open();

                    #region Cargar Datos del Paciente
                    // Obtener información del paciente según el ID seleccionado.
                    SqlCommand command = new SqlCommand("SELECT FechaNacimiento, TipoSangre, Genero, Contacto, CodigoPaciente FROM Paciente WHERE IDPaciente=@IDPaciente", conn);
                    command.Parameters.AddWithValue("@IDPaciente", patientId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            DateTime fechaNacimiento = reader.GetDateTime(0); 

                            // Calcular la edad
                            int edad = DateTime.Today.Year - fechaNacimiento.Year;
                            if (fechaNacimiento.Date > DateTime.Today.AddYears(-edad))
                            {
                                edad--; // Ajustar si el cumpleaños aún no ha pasado este año
                            }

                            edadtxt.Text = edad.ToString(); // Mostrar la edad

                            // Cargar otros datos del paciente
                            tiposangretxt.Text = reader["TipoSangre"].ToString();
                            generotxt.Text = reader["Genero"].ToString();
                            contactotxt.Text = reader["Contacto"].ToString();
                            codigopaciente.Text = reader["CodigoPaciente"].ToString();
                        }
                    }
                    #endregion

                    #region Cargar Síntomas
                    string query = string.Format(@"SELECT * FROM sintoma WHERE IDPaciente={0}", patientId);
                    SqlDataAdapter sda = new SqlDataAdapter(query, conn); // Usamos la conexión existente (conn)
                    SqlCommandBuilder scb = new SqlCommandBuilder(sda);
                    var dataSet = new DataSet();
                    sda.Fill(dataSet);
                    dgvsintomas.DataSource = dataSet.Tables[0];

                    dgvsintomas.Columns[0].Visible = false;
                    dgvsintomas.Columns[2].Visible = false;
                    dgvsintomas.Columns[3].Visible = false;
                    dgvsintomas.Columns[4].Visible = false;
                    dgvsintomas.Columns[5].Visible = false;
                    dgvsintomas.Columns[6].Visible = false;
                    #endregion
                }
            }
        }




        private void Agregarbtn_Click(object sender, EventArgs e)
        {
            if (txtmedicina.Text.Trim() == "")
            {
                MessageBox.Show("Escriba el nombre de la medicina.");
                txtmedicina.Focus();
            }
            else
            {
                string name = txtmedicina.Text;

                int rowIndex = -1;
                var rowsCount = dgvmedicina.Rows.Count;

                if (rowsCount > 1)
                {
                    for (int i = 0; i < dgvmedicina.Rows.Count - 1; i++)
                    {
                        if (dgvmedicina.Rows[i].Cells["NombreMedicina"].Value.ToString() == name)
                        {
                            rowIndex = dgvmedicina.Rows[i].Index;
                            break;
                        }
                    }
                }
                if (rowIndex < 0)
                {
                    rowIndex = dgvmedicina.Rows.Add();
                }
                dgvmedicina.Rows[rowIndex].Cells["Serial"].Value = dgvmedicina.Rows.Count - 1;
                dgvmedicina.Rows[rowIndex].Cells["NombreMedicina"].Value = name;
            }
        }

        private void dgvmedicina_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.RowIndex < dgvmedicina.Rows.Count)
                {
                    dgvmedicina.Rows.RemoveAt(e.RowIndex);
                }
            }
            catch (Exception ex)
            {
            }
        }


        private void guardarbtn_Click(object sender, EventArgs e)
        {
            // Verificar si se ha seleccionado un paciente
            if (Convert.ToInt32(pacientecbx.SelectedValue) == 0)
            {
                MessageBox.Show("Seleccione un Paciente.");
            }
            // Verificar si hay medicina recetada
            else if (dgvmedicina.Rows.Count <= 1)
            {
                MessageBox.Show("Debe darle medicina.");
            }
            else
            {
                // Usar bloque 'using' para garantizar la liberación de recursos de la conexión
                using (SqlConnection conn = new SqlConnection(ConexionBD.ConString))
                {
                    conn.Open();
                    // Iniciar una transaccion para garantizar la integridad de los datos
                    SqlTransaction transaction = conn.BeginTransaction();
                    try
                    {
                        // Consulta para insertar un nuevo diagnostico y obtener el ID generado
                        string query = @"INSERT INTO Diagnostico (IDPaciente,IDDoctor,Descripcion,FechaAgregado) 
                                 VALUES (@IDPaciente,@IDDoctor,@Descripcion,@FechaAgregado);
                                 SELECT SCOPE_IDENTITY();"; // Obtiene el ID del diagnóstico recien insertado

                        SqlCommand command = new SqlCommand(query, conn, transaction);
                        // Asignar valores a los parámetros de la consulta
                        command.Parameters.AddWithValue("@IDPaciente", pacientecbx.SelectedValue);
                        command.Parameters.AddWithValue("@IDDoctor", Global.InfoUsuario.IDUsuario);
                        command.Parameters.AddWithValue("@Descripcion", descripciontxt.Text.Trim());
                        command.Parameters.AddWithValue("@FechaAgregado", DateTime.Now);
                        // Ejecutar la consulta y obtener el ID del diagnóstico
                        int dianosisId = Convert.ToInt32(command.ExecuteScalar());

                        if (dianosisId > 0)
                        {
                            // Recorrer las filas del DataGridView para insertar medicamentos
                            for (int i = 0; i < dgvmedicina.Rows.Count - 1; i++)
                            {
                                string name = dgvmedicina.Rows[i].Cells["NombreMedicina"].Value.ToString();

                                // Consulta para insertar cada medicamento relacionado con el diagnóstico
                                query = @"INSERT INTO Medicina (NombreMedicina,IDDiagnostico,IDPaciente,FechaAgregado) 
                                  VALUES (@NombreMedicina,@IDDiagnostico,@IDPaciente,@FechaAgregado);";
                                command = new SqlCommand(query, conn, transaction);
                                // Asignar valores a los parámetros de la consulta de medicamentos
                                command.Parameters.AddWithValue("@NombreMedicina", name);
                                command.Parameters.AddWithValue("@IDDiagnostico", dianosisId);
                                command.Parameters.AddWithValue("@IDPaciente", pacientecbx.SelectedValue);
                                command.Parameters.AddWithValue("@FechaAgregado", DateTime.Now);
                                // Ejecutar la consulta para insertar el medicamento
                                command.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        MessageBox.Show("Guardado Correctamente.");
                        txtmedicina.Text = "";
                        descripciontxt.Text = "";
                        CargarPacientes();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        transaction.Rollback();
                    }
                    finally
                    {
                        // Asegurar que la conexión se cierre siempre
                        conn.Close();
                    }
                }
            }
        }

    }
}
