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
using System.Web.Mvc;

namespace Inventario.Services
{
    public class EquipoService : IEquipoService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public EquipoService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public bool Delete(int Id)
        {

            bool status = false;
            try
            {
                var equipo = _applicationDbContext.Equipos.Find(Id);
                equipo.Eliminado = true;
                _applicationDbContext.Update(equipo);
                _applicationDbContext.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


            return status;
        }

        public EquipoDto Get(int Id)
        {
            return _applicationDbContext.Equipos.Include(e => e.Empleado).Include(m => m.Marca).Include(o => o.Modelo).Include(n => n.Monitor).Include(a => a.Accesorio).Include(s => s.Asignacion).Where(x => x.Eliminado == false && x.Id == Id).Select(x => new EquipoDto
            {
                Id = x.Id,
                Empleado = x.Empleado.Nombre,
                EmpleadoId = x.EmpleadoId,
                Marca = x.Marca.Nombre,
                MarcaId = x.MarcaId,
                Procesador = x.Procesador,
                Memoria = x.Memoria,
                Asignacion = x.Asignacion.Nombre,
                AsignacionId = x.AsignacionId,
                Disco = x.Disco,
                Serial = x.Serial,
                Modelo = x.Modelo.Nombre,
                ModeloId = x.ModeloId,
                Monitor = x.Monitor.Marca,
                MonitorId = x.MonitorId,
                Accesorio = x.Accesorio.Nombre,
                AccesorioId = x.AccesorioId


            }).FirstOrDefault();
        }

        public List<EquipoDto> GetAll()
        {

            return _applicationDbContext.Equipos.Include(e=> e.Empleado).Include(m => m.Marca).Include(o => o.Modelo).Include(n => n.Monitor).Include(a => a.Accesorio).Include(s => s.Asignacion).Where(x => x.Eliminado == false).ToList().Select(x => new EquipoDto
            {
                Id = x.Id,
                Empleado = x.Empleado.Nombre,
                EmpleadoId = x.EmpleadoId,
                Marca = x.Marca.Nombre,
                MarcaId = x.MarcaId,
                Procesador = x.Procesador,
                Memoria = x.Memoria,
                Asignacion = x.Asignacion.Nombre,
                AsignacionId = x.AsignacionId,
                Disco = x.Disco,
                Serial = x.Serial,
                Modelo = x.Modelo.Nombre,
                ModeloId = x.ModeloId,
                Monitor = x.Monitor.Marca,
                MonitorId = x.MonitorId,
                Accesorio = x.Accesorio.Nombre,
                AccesorioId = x.AccesorioId


            }).ToList();
        }

        public List<MarcaDto> GetMarcas()
        {
            return _applicationDbContext.Marcas.Where(x => x.Eliminado == false).ToList().Select(x => new MarcaDto
            {
                Id = x.Id,
                Nombre = x.Nombre
            }).ToList();
        }

        public List<EmpleadoDto> GetEmpleados()
        {
            return _applicationDbContext.Empleados.Where(x => x.Eliminado == false).ToList().Select(x => new EmpleadoDto
            {
                Id = x.Id,
                Nombre = x.Nombre
                

            }).ToList();
        }

        public List<ModeloDto> GetModelos()
        {
            return _applicationDbContext.Modelos.Where(x => x.Eliminado == false).ToList().Select(x => new ModeloDto
            {
                Id = x.Id,
                Nombre = x.Nombre
            }).ToList();
        }

        public List<MonitorDto> GetMonitors()
        {
            return _applicationDbContext.Monitores.Where(x => x.Eliminado == false).ToList().Select(x => new MonitorDto
            {
                Id = x.Id,
                Marca = x.Marca
               

            }).ToList();
        }

        public List<AsignacionDto> GetAsignaciones()
        {
            return _applicationDbContext.Asignaciones.ToList().Select(x => new AsignacionDto
            {
                Id = x.Id,
                Nombre = x.Nombre
            }).ToList();
        }

        public List<AccesorioDto> GetAccesorios()
        {
            return _applicationDbContext.Accesorios.Where(x => x.Eliminado == false).ToList().Select(x => new AccesorioDto
            {
                Id = x.Id,
                Nombre = x.Nombre
            }).ToList();
        }

        public EquipoDto Insert(EquipoDto equipoDto)
        {
            _applicationDbContext.Equipos.Add(new Equipo
            {
                EmpleadoId = equipoDto.EmpleadoId,
                MarcaId = equipoDto.MarcaId,
                Procesador = equipoDto.Procesador,
                Memoria = equipoDto.Memoria,
                AsignacionId = equipoDto.AsignacionId,
                Disco = equipoDto.Disco,
                Serial = equipoDto.Serial,
                ModeloId = equipoDto.ModeloId,
                MonitorId = equipoDto.MonitorId,
                AccesorioId = equipoDto.AccesorioId,
                FechaCreacion = equipoDto.FechaCreacion,
                FechaActualizacion = equipoDto.FechaActualizacion,
                FechaDespacho = equipoDto.FechaDespacho
            });

            _applicationDbContext.SaveChanges();

            return equipoDto;
        }

        public bool Update(EquipoDto equipoDto)
        {
            bool status = false;
            try
            {
                var equipo = _applicationDbContext.Equipos.FirstOrDefault(x => x.Id == equipoDto.Id);
                equipo.EmpleadoId = equipoDto.EmpleadoId;
                equipo.MarcaId = equipoDto.MarcaId;
                equipo.Procesador = equipoDto.Procesador;
                equipo.Memoria = equipoDto.Memoria;
                equipo.AsignacionId = equipoDto.AsignacionId;
                equipo.Disco = equipoDto.Disco;
                equipo.Serial = equipoDto.Serial;
                equipo.ModeloId = equipoDto.ModeloId;
                equipo.MonitorId = equipoDto.MonitorId;
                equipo.AccesorioId = equipoDto.AccesorioId;
                equipo.FechaCreacion = equipoDto.FechaCreacion;
                equipo.FechaActualizacion = equipoDto.FechaActualizacion;
                equipo.FechaDespacho = equipoDto.FechaDespacho;

                _applicationDbContext.Entry(equipo).State = EntityState.Modified;
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
