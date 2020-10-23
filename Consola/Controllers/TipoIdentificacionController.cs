using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Consola.Controllers
{
    [Authorize]
    public class TipoIdentificacionController : Controller
    {
        // GET: TipoIdentificacion
        public ActionResult Index()
        {
            return View();
        }

        // GET: TipoIdentificacion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TipoIdentificacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoIdentificacion/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoIdentificacion/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TipoIdentificacion/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoIdentificacion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TipoIdentificacion/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
