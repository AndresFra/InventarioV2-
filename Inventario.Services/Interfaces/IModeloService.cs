using Inventario.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Services.Interfaces
{
    public interface IModeloService
    {
        List<ModeloDto> GetAll();
        ModeloDto Get(int Id);
        ModeloDto Insert(ModeloDto modeloDto);
        bool Update(ModeloDto modeloDto);
        bool Delete(int Id);
    }
}
