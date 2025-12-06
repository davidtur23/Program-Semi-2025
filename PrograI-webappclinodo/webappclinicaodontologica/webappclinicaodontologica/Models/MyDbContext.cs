using Microsoft.EntityFrameworkCore;
using webappclinicaodontologica.Models;

namespace webappclinicaodontologica.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Rol> Roles { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Servicio> Servicios { get; set; }

        public DbSet<Doctor> Doctores { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<HistorialMedico> HistorialMedico { get; set; }
        public DbSet<DetalleTratamiento> DetalleTratamiento { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rol>().ToTable("Roles").HasKey(r => r.IdRol);
            modelBuilder.Entity<Empleado>().ToTable("Empleados").HasKey(e => e.IdEmpleado);
            modelBuilder.Entity<Servicio>().ToTable("Servicios");



            modelBuilder.Entity<Empleado>()
                .HasOne(e => e.Rol)
                .WithMany(r => r.Empleados)
                .HasForeignKey(e => e.IdRol);

         
        
          
        }
    }
}
