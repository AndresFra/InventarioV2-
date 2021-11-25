using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Entities.Dto
{
    public class EmpleadoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Posicion { get; set; }
        public string Direccion { get; set; }
        public string Localidad { get; set; }
        public int Codigo { get; set; }
    }
}
