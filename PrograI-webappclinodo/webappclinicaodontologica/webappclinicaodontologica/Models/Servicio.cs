using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace webappclinicaodontologica.Models
{
    public class Servicio
    {
        [Key]
        public int IdServicio { get; set; }

        [Required]
        public string Nombre { get; set; }

        public decimal Precio { get; set; }

        public string Descripcion { get; set; }

        public string Estado { get; set; }
    }
}
