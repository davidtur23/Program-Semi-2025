
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webappclinicaodontologica.Models
    {
        public class Paciente
        {
            [Key]
            public int IdPaciente { get; set; }

            public string Nombre { get; set; }
            public string Telefono { get; set; }
            public string Correo { get; set; }

            public DateTime FechaNacimiento { get; set; }

            public int Edad =>
                DateTime.Today.Year - FechaNacimiento.Year -
                (FechaNacimiento > DateTime.Today.AddYears(-(DateTime.Today.Year - FechaNacimiento.Year)) ? 1 : 0);
        }
  }



