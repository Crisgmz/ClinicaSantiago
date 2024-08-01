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
    public partial class Pacientes : Form
    {
        public Pacientes()
        {
            InitializeComponent();
            codigopacientelbl.Text = DateTime.Now.ToString("ddMMhhmmss");
            CargarDoctores();
        }

        private void CargarDoctores()
        {
            using (SqlConnection conn = new SqlConnection(ConexionBD.ConString))
            {
                try
                {
                    // Consulta SQL para obtener los doctores (ID y Nombre)
                    string query = "SELECT IDDoctor, NombreDoctor FROM Doctor";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);

                    // Abrir la conexión antes de llenar el DataSet
                    conn.Open();

                    DataSet ds = new DataSet();
                    da.Fill(ds, "Doctor"); // Llenar el DataSet con los datos de los doctores

                    // Configurar el ComboBox de doctores
                    doctorcbx.DisplayMember = "NombreDoctor"; // Mostrar el nombre del doctor en el combobox
                    doctorcbx.ValueMember = "IDDoctor";       // Almacenar el ID del doctor en el valor del combobox
                    doctorcbx.DataSource = ds.Tables["Doctor"]; // Fuente de datos del combobox
                }
                catch (SqlException sqlEx) // Capturar errores específicos de SQL
                {
                    // Mostrar un mensaje de error mas específico si es un error de SQL
                    MessageBox.Show($"Error al cargar los doctores (SQL): {sqlEx.Message}",
                                    "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex) // Capturar cualquier otro tipo de error
                {
                    // Mostrar un mensaje genérico para otros errores
                    MessageBox.Show($"Error al cargar los doctores: {ex.Message}",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // (Opcional) Registrar el error en un log para depuración
                    // Logger.LogError(ex, "Error en CargarDoctores");
                }
            }
        }

        private void patientDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (pacientesdgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null && !string.IsNullOrWhiteSpace(pacientesdgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
            {
                pacientesdgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = new DataGridViewCellStyle { ForeColor = Color.Black };
            }
            else
            {
                pacientesdgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = pacientesdgv.DefaultCellStyle;
            }
        }

        private void ageTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void guardarbtn_Click(object sender, EventArgs e)
        {
            // Validar que todos los campos requeridos estén llenos
            if (string.IsNullOrWhiteSpace(nombrepacientetxt.Text) ||
                string.IsNullOrWhiteSpace(tiposangrecbx.Text) ||
                string.IsNullOrWhiteSpace(fechanacimientopicker.Text) ||
                fechanacimientopicker.Value == DateTimePicker.MinimumDateTime || // Verificar si se ha seleccionado una fecha válida
                string.IsNullOrWhiteSpace(generocbx.Text) ||
                string.IsNullOrWhiteSpace(contactopacientetxt.Text) ||
                string.IsNullOrWhiteSpace(direcciontxt.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return; // Detener la ejecución si faltan datos
            }

            // Validar que se haya seleccionado un doctor
            if (doctorcbx.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un doctor.");
                return; // Detener la ejecución si no se seleccionó un doctor
            }

            // Validar que se hayan agregado síntomas
            if (pacientesdgv.Rows.Count <= 1)
            {
                MessageBox.Show("Por favor, agregue los síntomas del paciente.");
                return; // Detener la ejecución si no hay síntomas
            }

            // Confirmación antes de guardar
            var confirmResult = MessageBox.Show("¿Está seguro de que desea guardar? ¡No se podrá borrar!", "", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(ConexionBD.ConString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        // Insertar paciente
                        string patientQuery = @"INSERT INTO Paciente (Nombre, Direccion, Contacto, FechaNacimiento, Genero, TipoSangre, CodigoPaciente, IDDoctor, FechaAgregado, AgregadoPor) 
                                                VALUES (@Nombre, @Direccion, @Contacto, @FechaNacimiento, @Genero, @TipoSangre, @CodigoPaciente, @IDDoctor, @FechaAgregado, @AgregadoPor);
                                                SELECT SCOPE_IDENTITY();"; // Obtener el ID del paciente insertado
                        SqlCommand command = new SqlCommand(patientQuery, conn, transaction);
                        // ... (Parámetros para la inserción del paciente)

                        int patientId = Convert.ToInt32(command.ExecuteScalar());

                        if (patientId > 0)
                        {
                            // Insertar síntomas
                            string symptomQuery = @"INSERT INTO Sintoma (Nombre, IDPaciente, FechaAgregado) 
                                                    VALUES (@Nombre, @IDPaciente, @FechaAgregado);";
                            for (int i = 0; i < pacientesdgv.Rows.Count - 1; i++) // -1 para excluir la última fila vacía
                            {
                                string name = pacientesdgv.Rows[i].Cells["Nombre"].Value.ToString();

                                command = new SqlCommand(symptomQuery, conn, transaction);
                                // ... (Parámetros para la inserción de los síntomas)

                                command.ExecuteNonQuery();
                            }
                        }
                        transaction.Commit(); // Confirmar la transacción si todo va bien
                        MessageBox.Show("Información del paciente guardada correctamente.");
                        Reset(); // Reiniciar el formulario (si aplica)
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al guardar: {ex.Message}");
                        transaction.Rollback(); // Revertir la transacción en caso de error
                    }
                }
            }
        }

        private void Reset()
        {
            idpacientetxt.Text = 0.ToString();
            nombrepacientetxt.Text = "";
            tiposangrecbx.Text = "";
            generocbx.Text = "";
            contactopacientetxt.Text = "";
            direcciontxt.Text = "";
            sintomacbx.Text = "";
            tiposangrecbx.Text = "";
            generocbx.Text = "";
            Otrosintomatxt.Text = "";
            pacientesdgv.Columns.Clear();
        }

        private void sintomacbx_SelectedValueChanged(object sender, EventArgs e)
        {
            Otrosintomatxt.Text = "";
            Otrosintomatxt.ReadOnly = true;
            Otrosintomatxt.Enabled = false;
            if (pacientesdgv.Text == "Otro")
            {
                Otrosintomatxt.ReadOnly = false;
                Otrosintomatxt.Enabled = true;
            }
        }

        private void AgregarPacientebtn_Click(object sender, EventArgs e)
        {
            if (sintomacbx.Text.Trim() == "")
            {
                MessageBox.Show("Selecciona un sintoma.");
                sintomacbx.Focus();
            }
            else if (sintomacbx.Text == "Otro" && Otrosintomatxt.Text.Trim() == "")
            {
                MessageBox.Show("Selecciona un sintoma.");
                Otrosintomatxt.Focus();
            }
            else
            {
                string name = sintomacbx.Text;
                if (sintomacbx.Text == "Otro")
                {
                    name = Otrosintomatxt.Text;
                }

                int rowIndex = -1;
                var rowsCount = pacientesdgv.Rows.Count;

                if (rowsCount > 1)
                {
                    for (int i = 0; i < pacientesdgv.Rows.Count - 1; i++)
                    {
                        if (pacientesdgv.Rows[i].Cells["Nombre"].Value.ToString() == name)
                        {
                            rowIndex = pacientesdgv.Rows[i].Index;
                            break;
                        }
                    }
                }
                if (rowIndex < 0)
                {
                    rowIndex = pacientesdgv.Rows.Add();
                }

                pacientesdgv.Rows[rowIndex].Cells["Serial"].Value = pacientesdgv.Rows.Count - 1;
                pacientesdgv.Rows[rowIndex].Cells["Nombre"].Value = name;
            }
        }


        private void obtenerrecetabtn_Click(object sender, EventArgs e)
        {
            RecetaDoctor recetadoctor = new RecetaDoctor();
            recetadoctor.ShowDialog();
        }
    }
}
