using Inventario.Entities.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario.Framework
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        
        public DbSet<Accesorio> Accesorios { get; set; }
        public DbSet<Asignacion> Asignaciones { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<Monitor> Monitores { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<SalidaEquipo> SalidaEquipos { get; set; }
    }
}
