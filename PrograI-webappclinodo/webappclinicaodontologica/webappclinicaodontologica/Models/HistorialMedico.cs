using System.ComponentModel.DataAnnotations;

namespace webappclinicaodontologica.Models
{
    public class HistorialMedico
    {
        [Key]
        public int IdHistorial { get; set; }

        public int IdPaciente { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        public string Diagnostico { get; set; }

        public string TratamientoSugerido { get; set; }

        public int IdDoctor { get; set; }
    }
}
