using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Entities.Model
{
    public class Empleado
    {
        public int Id { get; set; }

        [Required/*(ErrorMessage = "El campo nombre es requerido")*/]
        [StringLength(50)]

        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]

        public string Posicion { get; set; }

        [Required]
        [StringLength(50)]

        public string Direccion { get; set; }

        [Required]
        [StringLength(50)]

        public string Localidad { get; set; }

        [Required]


        public int Codigo { get; set; }

        public bool Eliminado { get; set; }
    }
}
