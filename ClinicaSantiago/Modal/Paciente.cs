using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaSantiago.Modal
{
    public class Paciente : PropiedadesComunes
    {
        public int IDPaciente { get; set; } = 0;
        public string Nombre { get; set; } = "";
        public string Direccion { get; set; } = "";
        public string Contacto { get; set; } = "";
        public DateTime FechaNacimiento { get; set; }
        public string Genero { get; set; } = "";
        public string TipoSangre { get; set; } = "";
        public string CodigoPaciente { get; set; } = "";
        public int IDDoctor { get; set; } = 0;
        public string NombreDoctor { get; set; } = "";
    }
}
