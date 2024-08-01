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
    public partial class VerPacientes : Form
    {

        SqlConnection sqlCon = new SqlConnection(ConexionBD.ConString);
        public VerPacientes()
        {
            InitializeComponent();
            CargarPacientes();
        }

        private void CargarPacientes()
        {
            sqlCon = MetodosComunes.OpenConnectionString(sqlCon);
            string query = "SELECT * FROM VistaPaciente"; // Cargar los Pacientes
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlCon);
            SqlCommandBuilder scb = new SqlCommandBuilder(sda);
            var dataSet = new DataSet();
            sda.Fill(dataSet);
            pacientesdgv.DataSource = dataSet.Tables[0];
            sqlCon.Close();

            pacientesdgv.Columns[0].Visible = false;
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

        }


        private void sintomacbx_SelectedValueChanged(object sender, EventArgs e)
        {
        }

        private void AgregarPacientebtn_Click(object sender, EventArgs e)
        {

        }
    }
}
