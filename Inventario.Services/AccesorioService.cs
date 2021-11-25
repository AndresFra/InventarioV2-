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
    public class AccesorioService : IAccesorioService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public AccesorioService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public bool Delete(int Id)
        {

            bool status = false;
            try
            {
                var accesorio = _applicationDbContext.Accesorios.Find(Id);
                accesorio.Eliminado = true;
                _applicationDbContext.Update(accesorio);
                _applicationDbContext.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


            return status;
        }

        public AccesorioDto Get(int Id)
        {
            try
            {
                return _applicationDbContext.Accesorios.Where(x => x.Eliminado == false && x.Id == Id).Select(x => new AccesorioDto
                {
                    Id = x.Id,
                    Nombre = x.Nombre
                }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<AccesorioDto> GetAll()
        {
            try
            {
                return _applicationDbContext.Accesorios.Where(x => x.Eliminado == false).ToList().Select(x => new AccesorioDto
                {
                    Id = x.Id,
                    Nombre = x.Nombre
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            
        }

        public AccesorioDto Insert(AccesorioDto accesorioDto)
        {
            try
            {
                _applicationDbContext.Accesorios.Add(new Accesorio
                {
                    Nombre = accesorioDto.Nombre
                });

                _applicationDbContext.SaveChanges();

                return accesorioDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Update(AccesorioDto accesorioDto)
        {
            bool status = false;
            try
            {
                var accesorio = _applicationDbContext.Accesorios.FirstOrDefault(x => x.Id == accesorioDto.Id);
                accesorio.Nombre = accesorioDto.Nombre;

                _applicationDbContext.Entry(accesorio).State = EntityState.Modified;
                _applicationDbContext.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


            return status;
        }
    }
}


