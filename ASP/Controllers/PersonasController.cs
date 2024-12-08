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
        public ActionResult Create(clsPersona persona)
        {
            IActionResult result;

            try
            {
                clsMetodosPersonaBL.insertarPersonaBL(persona);
                ViewBag.Mensaje = "Persona creada correctamente";
                result = View();
            } catch(Exception e)
            {
                result = View("Error");
            }

            return View();
        }

        // GET: PersonasController/Edit/5
        public ActionResult Edit(int id)
        {
            IActionResult result;

            try
            {
                clsPersonaNombreDepYListado persona = new clsPersonaNombreDepYListado(id);
                result = View(persona);
            }
            catch (Exception e)
            {
                result = View("Error");
            }
            return View();
        }

        // POST: PersonasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(clsPersonaNombreDepYListado personaNDL)
        {
            ActionResult result;
            try
            {
                // No se me ocurría una forma más fácil de convertir un clsPersonaNombreDepYListado a clsPersona
                // ya que la capa BL solo conoce a clsPersona
                clsPersona persona = personaNDL.GetPersona();
                clsMetodosPersonaBL.editarPersonaBL(persona);
                ViewBag.Mensaje = "Persona editada correctamente";
                result = View(persona);
            }
            catch
            {
                result = View("Error");
            }

            return result;
        }

        // GET: PersonasController/Delete/5
        public ActionResult Delete(int id)
        {
            ActionResult result;

            try
            {
                clsPersona persona = clsMetodosPersonaBL.buscarPersonaPorIdBL(id);
                result = View(persona);
            }
            catch (Exception e)
            {
                result = View("Error");
            }

            return result;
        }

        // POST: PersonasController/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id, String nombre)
        {
            ActionResult result;

            try
            {
                clsMetodosPersonaBL.eliminarPersonaBL(id);
                ViewBag.Nombre = nombre;
                result = View("Eliminada");
            }
            catch (Exception e)
            {
                result = View("Error");
            }

            return result;
        }
    }
}
