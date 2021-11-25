using Inventario.Entities.Dto;
using Inventario.Entities.Model;
using Inventario.Framework;
using Inventario.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Services
{
    public class MonitorService : IMonitorService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public MonitorService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public bool Delete(int Id)
        {

            bool status = false;
            try
            {
                var monitor = _applicationDbContext.Monitores.Find(Id);
                monitor.Eliminado = true;
                _applicationDbContext.Update(monitor);
                _applicationDbContext.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


            return status;
        }

        public MonitorDto Get(int Id)
        {
            throw new NotImplementedException();
        }

        public List<MonitorDto> GetAll()
        {
            return _applicationDbContext.Monitores.Where(x=>x.Eliminado == false).ToList().Select(x => new MonitorDto
            {
                Id = x.Id,
                Marca = x.Marca,
                Modelo = x.Modelo,
                Serial = x.Serial,
                Tamaño = x.Tamaño,
                Cantidad = x.Cantidad

            }).ToList();
        }

        public MonitorDto Insert(MonitorDto monitorDto)
        {
            _applicationDbContext.Monitores.Add(new Monitor
            {
                Marca = monitorDto.Marca,
                Modelo = monitorDto.Modelo,
                Serial = monitorDto.Serial,
                Tamaño = monitorDto.Tamaño,
                Cantidad = monitorDto.Cantidad
            });

            _applicationDbContext.SaveChanges();

            return monitorDto;
        }

        public bool Update(MonitorDto monitorDto)
        {
            bool status = false;
            try
            {
                var monitor = _applicationDbContext.Monitores.FirstOrDefault(x => x.Id == monitorDto.Id);
                monitor.Marca = monitorDto.Marca;
                monitor.Modelo = monitorDto.Modelo;
                monitor.Serial = monitorDto.Serial;
                monitor.Tamaño = monitorDto.Tamaño;
                monitor.Cantidad = monitorDto.Cantidad;

                _applicationDbContext.Entry(monitor).State = EntityState.Modified;
                _applicationDbContext.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                throw;
            }


            return status;
        }
    }
}
