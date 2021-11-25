using Inventario.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Services.Interfaces
{
    public interface IAccesorioService
    {
        List<AccesorioDto> GetAll();
        AccesorioDto Get(int Id);
        AccesorioDto Insert(AccesorioDto accesorioDto);
        bool Update(AccesorioDto accesorioDto);
        bool Delete(int Id);
    }
}
