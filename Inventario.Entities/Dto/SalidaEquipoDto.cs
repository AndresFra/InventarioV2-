﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Entities.Dto
{
    public class SalidaEquipoDto
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Serial { get; set; }
        public string Modelo { get; set; }
        public string Empleado { get; set; }
        public DateTime FechaDespacho { get; set; }
        public int EquipoId { get; set; }
    }
}
