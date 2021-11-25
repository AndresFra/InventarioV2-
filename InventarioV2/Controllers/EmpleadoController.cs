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
    public class EmpleadoController : Controller
    {
        private IEmpleadoService _empleadoService;
        public EmpleadoController(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        // GET: EmpleadoController
        public ActionResult Index()
        {
            var model = _empleadoService.GetAll();
            
            return View(model);
        }

        // GET: EmpleadoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmpleadoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpleadoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmpleadoDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _empleadoService.Insert(model);

                    return RedirectToAction(nameof(Index));
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: EmpleadoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmpleadoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmpleadoDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _empleadoService.Update(model);

                    return RedirectToAction(nameof(Index));
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: EmpleadoController/Delete/5
       
        
        public ActionResult Delete(int id)
        {
            try
            {
                _empleadoService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
