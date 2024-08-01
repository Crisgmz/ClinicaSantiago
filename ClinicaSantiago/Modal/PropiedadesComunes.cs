using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaSantiago.Modal
{
    public class PropiedadesComunes
    {
        public DateTime? FechaAgregado { get; set; } = null;

        public int? AgregadorPor { get; set; } = 0;

        public DateTime? FechaActualizado { get; set; } = null;

        public int? ActualizadoPor { get; set; } = 0;
    }
}
