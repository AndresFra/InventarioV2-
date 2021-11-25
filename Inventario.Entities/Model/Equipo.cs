using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Entities.Model
{
    public class Equipo
    {
        public int Id { get; set; }

        [Required/*(ErrorMessage = "El campo nombre es requerido")*/]
        [Display(Name = "Empleado")]
        public int EmpleadoId { get; set; }
        public Empleado Empleado { get; set; }

        [Required]
        [Display(Name = "Marca")]
        public int MarcaId { get; set; }
        public Marca Marca { get; set; }

        [Required]
        [StringLength(50)]
        public string Procesador { get; set; }

        [Required]
        [StringLength(50)]
        public string Memoria { get; set; }

        [Required]
        [Display(Name = "Asignacion")]
        public int AsignacionId { get; set; }
        public Asignacion Asignacion { get; set; }

        [Required]
        [StringLength(50)]
        public string Disco { get; set; }



        [Required]
        [StringLength(50)]
        public string Serial { get; set; }

        [Required]
        [Display(Name = "Modelo")]
        public int ModeloId { get; set; }
        public Modelo Modelo { get; set; }

        [Required]
        [Display(Name = "Monitor")]
        public int MonitorId { get; set; }
        public Monitor Monitor { get; set; }

        [Required]
        [Display(Name = "Accesorio")]
        public int AccesorioId { get; set; }
        public Accesorio Accesorio { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de creacion")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaCreacion { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de actualizacion")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FechaActualizacion { get; set; }

        //[Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de despacho")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FechaDespacho { get; set; }

        public bool Eliminado { get; set; }
    }
}
