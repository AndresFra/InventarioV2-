using Inventario.Entities.Dto;
using Inventario.Entities.Model;
using Inventario.Framework;
using Inventario.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioV2.Controllers
{
    public class EquipoController : Controller
    {
        private IEquipoService _equipoService;

        public EquipoController(IEquipoService equipoService)
        {
            _equipoService = equipoService;
        }

      
        // GET: EquipoController
        public ActionResult Index()
        {
            var model = _equipoService.GetAll();

            return View(model);
        }

        // GET: EquipoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EquipoController/Create
        public ActionResult Create()
        {
            ViewBag.marcaId = _equipoService.GetMarcas().Select((x => new SelectListItem { Value = x.Id.ToString(), Text = x.Nombre }));
            ViewBag.empleadoId = _equipoService.GetEmpleados().Select((x => new SelectListItem { Value = x.Id.ToString(), Text = x.Nombre }));
            ViewBag.monitorId = _equipoService.GetMonitors().Select((x => new SelectListItem { Value = x.Id.ToString(), Text = x.Marca }));
            ViewBag.modeloId = _equipoService.GetModelos().Select((x => new SelectListItem { Value = x.Id.ToString(), Text = x.Nombre }));
            ViewBag.asignacionId = _equipoService.GetAsignaciones().Select((x => new SelectListItem { Value = x.Id.ToString(), Text = x.Nombre }));
            ViewBag.accesorioId = _equipoService.GetAccesorios().Select((x => new SelectListItem { Value = x.Id.ToString(), Text = x.Nombre }));



            return View();
        }

        // POST: EquipoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EquipoDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _equipoService.Insert(model);

                    return RedirectToAction(nameof(Index));
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: EquipoController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _equipoService.Get(id);
            var marcas = _equipoService.GetMarcas();
        
            ViewBag.marcaId = _equipoService.GetMarcas().Select((x => new SelectList(marcas, "Id", "Nombre", model.MarcaId)));
            ViewBag.empleadoId = _equipoService.GetEmpleados().Select((x => new SelectListItem { Value = x.Id.ToString(), Text = x.Nombre }));
            ViewBag.monitorId = _equipoService.GetMonitors().Select((x => new SelectListItem { Value = x.Id.ToString(), Text = x.Marca }));
            ViewBag.modeloId = _equipoService.GetModelos().Select((x => new SelectListItem { Value = x.Id.ToString(), Text = x.Nombre }));
            ViewBag.asignacionId = _equipoService.GetAsignaciones().Select((x => new SelectListItem { Value = x.Id.ToString(), Text = x.Nombre }));
            ViewBag.accesorioId = _equipoService.GetAccesorios().Select((x => new SelectListItem { Value = x.Id.ToString(), Text = x.Nombre }));

            return View(model);
        }

        // POST: EquipoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EquipoDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _equipoService.Update(model);

                    return RedirectToAction(nameof(Index));
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: EquipoController/Delete/5
       
        public ActionResult Delete(int id)
        {
            try
            {
                _equipoService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
