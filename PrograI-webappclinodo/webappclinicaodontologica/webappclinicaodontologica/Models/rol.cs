

    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;

    namespace webappclinicaodontologica.Models
    {
        public class Rol
        {
            [Key]
            public int IdRol { get; set; }

            public string RolNombre { get; set; }

            [JsonIgnore]
            public List<Empleado> Empleados { get; set; }
        }
    }





