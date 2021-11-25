using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Entities.Dto
{
    public class EquipoDto
    {
        public int Id { get; set; }

        public string Empleado { get; set; }
        public int EmpleadoId { get; set; }

        public string Marca { get; set; }
        public int MarcaId { get; set; }
        public string Procesador { get; set; }
        public string Memoria { get; set; }
        public string Disco { get; set; }

        public string Asignacion { get; set; }
        public int AsignacionId { get; set; }
        public string Serial { get; set; }

        public string Modelo { get; set; }
        public int ModeloId { get; set; }

        public string Monitor { get; set; }
        public int MonitorId { get; set; }

        public string Accesorio { get; set; }
        public int AccesorioId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public DateTime? FechaDespacho { get; set; }
    }
}
