using ASP.Models;
using BL;
using ENT;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace ASP.Controllers
{
    public class PersonasController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        // GET: PersonasController
        public ActionResult Listado()
        {
            ActionResult result;

            try
            {
                clsListadoPersonasConNombreDept personas = new clsListadoPersonasConNombreDept();
                result = View(personas.PersonasConNombreDept);
               
            } catch (Exception e)
            {
                ViewBag.Mensaje = e.Message;
                result = View("Error");
            }

            return result;
        }


        // GET: PersonasController/Details/5
        public ActionResult Details(int id)
        {
            ActionResult result;

            try
            {
                clsPersonaNombreDept persona = new clsPersonaNombreDept(id);
                result = View(persona);
            } catch (Exception e)
            {
                result = View("Error");
            }
            return result;
        }

        // GET: PersonasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PersonasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PersonasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
