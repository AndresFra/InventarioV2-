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
    public class MarcaService : IMarcaService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public MarcaService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public bool Delete(int Id)
        {

            bool status = false;
            try
            {
                var marca = _applicationDbContext.Marcas.Find(Id);
                marca.Eliminado = true;
                _applicationDbContext.Update(marca);
                _applicationDbContext.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


            return status;
        }

        public MarcaDto Get(int Id)
        {
            throw new NotImplementedException();
        }

        public List<MarcaDto> GetAll()
        {
            return _applicationDbContext.Marcas.Where(x=> x.Eliminado==false).ToList().Select(x => new MarcaDto
            {
                Id = x.Id,
                Nombre = x.Nombre
            }).ToList();
        }

        public MarcaDto Insert(MarcaDto marcaDto)
        {
            _applicationDbContext.Marcas.Add(new Marca
            {
                Nombre = marcaDto.Nombre
            });

            _applicationDbContext.SaveChanges();

            return marcaDto;
        }

        public bool Update(MarcaDto marcaDto)
        {
            bool status = false;
            try
            {
                var marca = _applicationDbContext.Marcas.FirstOrDefault(x => x.Id == marcaDto.Id);
                marca.Nombre = marcaDto.Nombre;

                _applicationDbContext.Entry(marca).State = EntityState.Modified;
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
