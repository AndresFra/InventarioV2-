using Inventario.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Services.Interfaces
{
    public interface IMonitorService
    {
        List<MonitorDto> GetAll();
        MonitorDto Get(int Id);
        MonitorDto Insert(MonitorDto monitorDto);
        bool Update(MonitorDto monitorDto);
        bool Delete(int Id);
    }
}
