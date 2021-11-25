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
    public class ModeloService : IModeloService
    {

        private readonly ApplicationDbContext _applicationDbContext;

        public ModeloService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public bool Delete(int Id)
        {

            bool status = false;
            try
            {
                var modelo = _applicationDbContext.Modelos.Find(Id);
                modelo.Eliminado = true;
                _applicationDbContext.Update(modelo);
                _applicationDbContext.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


            return status;
        }

        public ModeloDto Get(int Id)
        {
            throw new NotImplementedException();
        }

        public List<ModeloDto> GetAll()
        {
            return _applicationDbContext.Modelos.Where(x=> x.Eliminado==false).ToList().Select(x => new ModeloDto
            {
                Id = x.Id,
                Nombre = x.Nombre
            }).ToList();
        }

        public ModeloDto Insert(ModeloDto modeloDto)
        {
            _applicationDbContext.Modelos.Add(new Modelo
            {
                Nombre = modeloDto.Nombre
            });

            _applicationDbContext.SaveChanges();

            return modeloDto;
        }

        public bool Update(ModeloDto modeloDto)
        {
            bool status = false;
            try
            {
                var modelo = _applicationDbContext.Modelos.FirstOrDefault(x => x.Id == modeloDto.Id);
                modelo.Nombre = modeloDto.Nombre;

                _applicationDbContext.Entry(modelo).State = EntityState.Modified;
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
