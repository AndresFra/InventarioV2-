using Inventario.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Inventario.Services.Interfaces
{
    public interface IEquipoService
    {
        List<EquipoDto> GetAll();
        EquipoDto Get(int Id);
        EquipoDto Insert(EquipoDto equipoDto);
        bool Update(EquipoDto equipoDto);
        bool Delete(int Id);

        List<MarcaDto> GetMarcas();
        List<EmpleadoDto> GetEmpleados();
        List<ModeloDto> GetModelos();
        List<MonitorDto> GetMonitors();
        List<AsignacionDto> GetAsignaciones();
        List<AccesorioDto> GetAccesorios();
    }
}
