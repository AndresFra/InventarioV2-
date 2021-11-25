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
    public class MonitorController : Controller
    {
        private IMonitorService _monitorService;
        public MonitorController(IMonitorService monitorService)
        {
            _monitorService = monitorService;
        }

        // GET: MonitorController
        public ActionResult Index()
        {
            var model = _monitorService.GetAll();

            return View(model);
        }

        // GET: MonitorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MonitorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MonitorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MonitorDto model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _monitorService.Insert(model);
                    return RedirectToAction(nameof(Index));
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: MonitorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MonitorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MonitorDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _monitorService.Update(model);

                    return RedirectToAction(nameof(Index));
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: MonitorController/Delete/5
       

        public ActionResult Delete(int id)
        {
            try
            {
                _monitorService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
