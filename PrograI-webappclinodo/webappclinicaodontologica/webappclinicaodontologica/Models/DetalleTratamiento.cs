using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;



namespace webappclinicaodontologica.Models
{
    public class DetalleTratamiento
    {
        [Key]
       
        [JsonIgnore]
        public int IdDetalle { get; set; }

        [JsonIgnore]
        public int? IdTratamiento { get; set; }  

        public int IdPaciente { get; set; }

        public DateTime FechaAplicacion { get; set; }

        public string Observaciones { get; set; }
    }
}
