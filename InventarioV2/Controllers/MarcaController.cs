using Inventario.Entities.Dto;
using Inventario.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioV2.Controllers
{
    public class MarcaController : Controller
    {
        private IMarcaService _marcaService;

        public MarcaController(IMarcaService marcaService)
        {
            _marcaService = marcaService;
        }

        // GET: MarcaController
        public ActionResult Index()
        {
            var model = _marcaService.GetAll(); 

            return View(model);
        }

        // GET: MarcaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MarcaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MarcaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MarcaDto model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _marcaService.Insert(model);

                    return RedirectToAction(nameof(Index));
                }
                return View(model);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: MarcaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MarcaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MarcaDto model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _marcaService.Update(model);

                    return RedirectToAction(nameof(Index));
                }
                return View(model);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: MarcaController/Delete/5
       
        public ActionResult Delete(int id)
        {
            try
            {
                _marcaService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
