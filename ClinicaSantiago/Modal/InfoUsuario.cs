using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaSantiago.Modal
{
    public class InfoUsuario : PropiedadesComunes
    {
        public int IDUsuario { get; set; } = 0;
        public string NombreUsuario { get; set; } = "";
        public string Contrasena { get; set; } = "";
        public int TipoUsuario { get; set; } = 0;
        public int IDDoctor { get; set; } = 0;
    }
}
