using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace webappclinicaodontologica.Models.DTO
{
    public class ServicioDTO
    {
        [Key]
        public int IdServicio { get; set; }
        public string NombreServicio { get; set; }
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }

        public int? Doctor1Id { get; set; }
        public int? Doctor2Id { get; set; }

        public IFormFile Foto { get; set; }
    }
}
