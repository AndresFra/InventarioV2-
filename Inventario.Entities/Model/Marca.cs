using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Entities.Model
{
    public class Marca
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]

        public string Nombre { get; set; }

        public bool Eliminado { get; set; }
    }
}
