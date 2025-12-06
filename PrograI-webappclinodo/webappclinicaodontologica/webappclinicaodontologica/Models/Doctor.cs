using System.ComponentModel.DataAnnotations;

namespace webappclinicaodontologica.Models
{
    public class Doctor
    {
        [Key]
        public int IdDoctor { get; set; }

        [Required]
        public string Nombre { get; set; }

        public string? Especialidad { get; set; }

        public string? Telefono { get; set; }

        [Required]
        public bool Estado { get; set; }
    }
}
