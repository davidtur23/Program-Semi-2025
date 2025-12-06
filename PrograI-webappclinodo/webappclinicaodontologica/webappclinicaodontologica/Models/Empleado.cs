using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace webappclinicaodontologica.Models
{
    public class Empleado
    {
        [Key]
        public int IdEmpleado { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        public string Usuario { get; set; }

        [Required]
        public string Contrasena { get; set; }

        public int IdRol { get; set; }

        public string Estado { get; set; }

        [JsonIgnore]
        public Rol Rol { get; set; }
    }
}
