using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaSantiago.Modal
{
    public class Medicina : PropiedadesComunes
    {
        public int IDMedicina { get; set; } = 0;
        public string NombreMedicina { get; set; } = "";
        public int IDDiagnostico { get; set; } = 0;
        public int IDPaciente { get; set; } = 0;
    }
}
