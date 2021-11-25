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
    public class EmpleadoService : IEmpleadoService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public EmpleadoService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public bool Delete(int Id)
        {
            bool status = false;
            try
            {
                var empleado = _applicationDbContext.Empleados.Find(Id);
                empleado.Eliminado = true;
                _applicationDbContext.Update(empleado);
                _applicationDbContext.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


            return status;
        }

        public EmpleadoDto Get(int Id)
        {
            throw new NotImplementedException();
        }

        public List<EmpleadoDto> GetAll()
        {
            return _applicationDbContext.Empleados.Where(x => x.Eliminado == false).ToList().Select(x => new EmpleadoDto
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Posicion = x.Posicion,
                Codigo = x.Codigo,
                Localidad = x.Localidad,
                Direccion = x.Direccion

            }).ToList();
        }

        public EmpleadoDto Insert(EmpleadoDto empleadoDto)
        {
            _applicationDbContext.Empleados.Add(new Empleado
            {
                Nombre = empleadoDto.Nombre,
                Posicion = empleadoDto.Posicion,
                Codigo = empleadoDto.Codigo,
                Localidad = empleadoDto.Localidad,
                Direccion = empleadoDto.Direccion
            });

            _applicationDbContext.SaveChanges();

            return empleadoDto;
        }

        public bool Update(EmpleadoDto empleadoDto)
        {
            bool status = false;
            try
            {
                var empleado = _applicationDbContext.Empleados.FirstOrDefault(x => x.Id == empleadoDto.Id);
                empleado.Nombre = empleadoDto.Nombre;
                empleado.Posicion = empleadoDto.Posicion;
                empleado.Codigo = empleadoDto.Codigo;
                empleado.Localidad = empleadoDto.Localidad;
                empleado.Direccion = empleadoDto.Direccion;

                _applicationDbContext.Entry(empleado).State = EntityState.Modified;
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
