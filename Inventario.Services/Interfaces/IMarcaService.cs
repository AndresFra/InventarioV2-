using Inventario.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Services.Interfaces
{
    public interface IMarcaService
    {
        List<MarcaDto> GetAll();
        MarcaDto Get(int Id);
        MarcaDto Insert(MarcaDto marcaDto);
        bool Update(MarcaDto marcaDto);
        bool Delete(int Id);
    }
}
