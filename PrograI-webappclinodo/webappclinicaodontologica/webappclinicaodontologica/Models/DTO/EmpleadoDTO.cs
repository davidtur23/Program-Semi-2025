namespace webappclinicaodontologica.Models.DTO
{
    public class EmpleadoDTO
    {
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public int IdRol { get; set; }
        public string Estado { get; set; }

        // Solo lectura
        public string NombreRol { get; set; }
    }
}
