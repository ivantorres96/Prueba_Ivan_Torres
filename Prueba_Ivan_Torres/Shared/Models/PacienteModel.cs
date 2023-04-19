using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Ivan_Torres.Shared.Models
{
    public class PacienteModel
    {
		public decimal IdPaciente { get; set; }
        public string? Nombre { get; set; }
		public string? Apellidos { get; set; }
		public string? CorreoElectronico { get; set; }
		public string? Telefono { get; set; }
		public DateTime? FechaNacimiento { get; set; }
		public string? EstadoAfiliacion { get; set; }
		public decimal IdTipoDocumento { get; set; }
		public string? NumeroDocumento { get; set; }
	}

    public class PacienteListModel
    {
        public decimal IdPaciente { get; set; }
        public string? Nombre { get; set; }
        public string? Apellidos { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Telefono { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? EstadoAfiliacion { get; set; }
        public string? TipoDocumento { get; set; }
        public string? NumeroDocumento { get; set; }
    }
}
