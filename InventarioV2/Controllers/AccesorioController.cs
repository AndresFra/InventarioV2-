using Inventario.Entities.Dto;
using Inventario.Entities.Model;
using Inventario.Framework;
using Inventario.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioV2.Controllers
{
    public class AccesorioController : Controller
    {
        private IAccesorioService _accesorioService;
        public AccesorioController(IAccesorioService accesorioService)
        {
            _accesorioService = accesorioService;
        }

        // GET: AccesorioController
        public ActionResult Index()
        {
            var model = _accesorioService.GetAll();
            return View(model);
        }

        // GET: AccesorioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AccesorioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccesorioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AccesorioDto model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _accesorioService.Insert(model);

                    return RedirectToAction(nameof(Index));
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: AccesorioController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _accesorioService.Get(id);
            return View(model);
        }

        // POST: AccesorioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AccesorioDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _accesorioService.Update(model);

                    return RedirectToAction(nameof(Index));
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // POST: AccesorioController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                _accesorioService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
