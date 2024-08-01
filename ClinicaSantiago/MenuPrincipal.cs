using ClinicaSantiago.Comunes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaSantiago
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void Doctoresbtn_Click(object sender, EventArgs e)
        {
            if (Global.InfoUsuario.TipoUsuario != 1)
            {
                MessageBox.Show("Solo los usuarios administradores pueden acceder.");
            }
            else
            {
                Doctores doctorForm = new Doctores();
                doctorForm.ShowDialog();
            }
        }

        private void Pacientesbtn_Click(object sender, EventArgs e)
        {
            Pacientes pacientes = new Pacientes();
            pacientes.ShowDialog();
        }

        private void Diagnosticobtn_Click(object sender, EventArgs e)
        {
            Diagnosticos diagnostico = new Diagnosticos();
            diagnostico.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VerPacientes verPacientes = new VerPacientes();
            verPacientes.ShowDialog();
        }

        private void cerrarsesionbtn_Click(object sender, EventArgs e)
        {
   
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas cerrar sesión?", "Confirmar cierre de sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Login Login = new Login();
                Login.Show();

                    this.Close();
                }
       

        }
    }
}
