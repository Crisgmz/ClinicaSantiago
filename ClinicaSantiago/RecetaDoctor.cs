using ClinicaSantiago.Comunes;
using ClinicaSantiago.DB;
using ClinicaSantiago.Modal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaSantiago
{
    public partial class RecetaDoctor : Form
    {
        SqlConnection sqlCon = new SqlConnection(ConexionBD.ConString);
        int _patientId = 0;
        public RecetaDoctor()
        {
            InitializeComponent();
            LoadPatients();
        }
        private void LoadPatients()
        {
            using (SqlConnection conn = new SqlConnection(ConexionBD.ConString))
            {
                try
                {
                    // Consulta SQL para obtener ID y Código de Paciente
                    string query = "SELECT IDPaciente, CodigoPaciente FROM Paciente";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);

                    // Abrir la conexión antes de llenar el DataSet
                    conn.Open();

                    DataSet ds = new DataSet();
                    da.Fill(ds, "Paciente"); // Llenar el DataSet con los datos de los pacientes

                    cbxpaciente.DisplayMember = "CodigoPaciente"; 
                    cbxpaciente.ValueMember = "IDPaciente";        
                    cbxpaciente.DataSource = ds.Tables["Paciente"]; 
                }
                catch (SqlException sqlEx) // Capturar errores específicos de SQL
                {
                    // Manejo de errores de SQL: mostrar mensaje más detallado 
                    MessageBox.Show($"Error al cargar los pacientes (SQL): {sqlEx.Message}",
                                    "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex) // Capturar cualquier otro tipo de error general
                {
                    // Manejo de errores generales: mostrar mensaje genérico
                    MessageBox.Show($"Error al cargar los pacientes: {ex.Message}",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }


        private void recetabtn_Click(object sender, EventArgs e)
        {
            _patientId = Convert.ToInt32(cbxpaciente.SelectedValue);
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK && _patientId > 0)
            {
                printDocument1.Print();
            }
        }

        private Paciente GetPatientInfo(DataTable dt)
        {
            // Verifica si el DataTable tiene filas
            if (dt.Rows.Count == 0)
            {
                throw new Exception("El DataTable está vacío.");
            }

            // Verifica si las columnas necesarias existen
            string[] requiredColumns = { "Nombre", "Direccion", "Contacto", "FechaNacimiento", "Genero", "TipoSangre", "CodigoPaciente", "NombreDoctor" };
            foreach (string column in requiredColumns)
            {
                if (!dt.Columns.Contains(column))
                {
                    throw new Exception($"La columna '{column}' no existe en el DataTable.");
                }
            }

            // Asume que solo hay una fila en el DataTable para el paciente
            DataRow row = dt.Rows[0];

            Paciente paciente = new Paciente()
            {
                Nombre = Convert.ToString(row["Nombre"]),
                Direccion = Convert.ToString(row["Direccion"]),
                Contacto = Convert.ToString(row["Contacto"]),
                FechaNacimiento = Convert.ToDateTime(row["FechaNacimiento"]),
                Genero = Convert.ToString(row["Genero"]),
                TipoSangre = Convert.ToString(row["TipoSangre"]),
                CodigoPaciente = Convert.ToString(row["CodigoPaciente"]),
                NombreDoctor = Convert.ToString(row["NombreDoctor"])
            };

            return paciente;
        }



        private List<Medicina> GetMedicinesInfo(DataTable dt)
        {
            List<Medicina> medicines = (from rw in dt.AsEnumerable()
                                        select new Medicina()
                                        {
                                            NombreMedicina = Convert.ToString(rw["NombreMedicina"])
                                        }).ToList();
            return medicines;
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Paciente paciente = new Paciente();   // Crear una instancia del objeto Paciente para almacenar la información
            List<Medicina> medicines = new List<Medicina>(); // Crear una lista para almacenar la información de las medicinas

            _patientId = Convert.ToInt32(cbxpaciente.SelectedValue);

            if (_patientId > 0)
            {
                try
                {
                    // Obtener la informacion del paciente
                    sqlCon = MetodosComunes.OpenConnectionString(sqlCon);
                    string query = string.Format(@"SELECT * FROM VistaPaciente WHERE IDPaciente='{0}'", _patientId);
                    SqlDataAdapter sda = new SqlDataAdapter(query, sqlCon);
                    DataTable dataTable = new DataTable();
                    sda.Fill(dataTable);
                    sqlCon.Close();
                    paciente = this.GetPatientInfo(dataTable);  // Llenar el objeto paciente con los datos obtenidos

                    // Obtener la informacion de las medicinas del paciente
                    sqlCon = MetodosComunes.OpenConnectionString(sqlCon);
                    query = string.Format(@"SELECT * FROM Medicina WHERE IDPaciente='{0}'", _patientId);
                    sda = new SqlDataAdapter(query, sqlCon);
                    dataTable = new DataTable();
                    sda.Fill(dataTable);
                    sqlCon.Close();
                    medicines = this.GetMedicinesInfo(dataTable); // Llenar la lista de medicinas con los datos obtenidos

                    // Imprimir el encabezado "Receta Médica"
                    e.Graphics.DrawString("==Receta Médica==", new Font("Century", 22, FontStyle.Bold), Brushes.Red, new Point(200, 40));

                    // Imprimir la informacion del paciente
                    e.Graphics.DrawString("Paciente : " + paciente.Nombre, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(120, 105));
                    e.Graphics.DrawString("Género : " + paciente.Genero, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(120, 125));
                    int edad = CalcularEdad(paciente.FechaNacimiento); 
                    e.Graphics.DrawString("Edad : " + edad, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(120, 145));
                    e.Graphics.DrawString("Tipo de Sangre : " + paciente.TipoSangre, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(120, 165));
                    e.Graphics.DrawString("Código Paciente : " + paciente.CodigoPaciente, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(120, 185));
                    e.Graphics.DrawString("Contacto : " + paciente.Contacto, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(120, 205));
                    e.Graphics.DrawString("Dirección : " + paciente.Direccion, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(120, 225));
                    e.Graphics.DrawString("Doctor : " + paciente.NombreDoctor, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(120, 245));

                    // Imprimir el encabezado "Medicinas Dadas"
                    e.Graphics.DrawString("Medicinas Dadas", new Font("Century", 18, FontStyle.Bold), Brushes.Red, new Point(200, 265));

                    // Imprimir la lista de medicinas
                    int rowGap = 20,
                        lastPoint = 265;
                    foreach (var medicine in medicines)
                    {
                        lastPoint += rowGap + 10;
                        e.Graphics.DrawString(medicine.NombreMedicina, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(120, lastPoint));
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de errores: Mostrar un mensaje de error al usuario o registrar el error en un log.
                    MessageBox.Show("Error al generar la receta: " + ex.Message);
                }
            }
        }


        public int CalcularEdad(DateTime fechaNacimiento)
        {
            int edad = DateTime.Now.Year - fechaNacimiento.Year;
            if (DateTime.Now.DayOfYear < fechaNacimiento.DayOfYear)
            {
                edad--;
            }
            return edad;
        }
    }
}
