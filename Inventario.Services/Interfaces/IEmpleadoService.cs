using Inventario.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Services.Interfaces
{
    public interface IEmpleadoService
    {
        List<EmpleadoDto> GetAll();
        EmpleadoDto Get(int Id);
        EmpleadoDto Insert(EmpleadoDto empleadoDto);
        bool Update(EmpleadoDto empleadoDto);
        bool Delete(int Id);
    }
}
