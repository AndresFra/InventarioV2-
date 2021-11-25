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
    public class ModeloController : Controller
    {
        private IModeloService _modeloService;
        public ModeloController(IModeloService modeloService)
        {
            _modeloService = modeloService;
        }

        // GET: ModeloController
        public ActionResult Index()
        {
            var model = _modeloService.GetAll();
            return View(model);
        }

        // GET: ModeloController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ModeloController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ModeloController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ModeloDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _modeloService.Insert(model);

                    return RedirectToAction(nameof(Index));
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: ModeloController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ModeloController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ModeloDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _modeloService.Update(model);

                    return RedirectToAction(nameof(Index));
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: ModeloController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                _modeloService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
