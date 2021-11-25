using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Entities.Dto
{
    public class MonitorDto
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Serial { get; set; }
        public string Modelo { get; set; }
        public string Tamaño { get; set; }
        public int Cantidad { get; set; }
    }
}
