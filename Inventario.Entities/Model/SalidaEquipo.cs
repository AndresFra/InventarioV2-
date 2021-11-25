using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Entities.Model
{
    public class SalidaEquipo
    {
        public int Id { get; set; }
        [Required]
        public string Marca { get; set; }

        [Required]
        public string Serial { get; set; }

        [Required]
        public string Modelo { get; set; }

        [Required]
        public string Empleado { get; set; }


        public DateTime FechaDespacho { get; set; }

        [Required]
        public int EquipoId { get; set; }
        public Equipo Equipo { get; set; }
    }
}
