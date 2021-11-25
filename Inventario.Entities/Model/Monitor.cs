using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Entities.Model
{
    public class Monitor
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]

        public string Marca { get; set; }

        [Required]
        [StringLength(50)]

        public string Serial { get; set; }

        [Required]
        [StringLength(50)]

        public string Modelo { get; set; }

        [Required]
        [StringLength(50)]

        public string Tamaño { get; set; }

        [Required]


        public int Cantidad { get; set; }

        public bool Eliminado { get; set; }
    }
}
