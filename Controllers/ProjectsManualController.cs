using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab4.Models;
namespace Lab4.Controllers
{
    public class ProjectsManualController : Controller
    {
        // GET: ProjectsManualController
        public ActionResult Index()
        {
            return View(Singleton.Instance.ProjectsManualList);
        }

        // GET: ProjectsManualController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProjectsManualController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjectsManualController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var newProjectsManual = new ProjectsManual
                {
                    
                    titulo = collection["titulo"],
                    descripcion = collection["descripcion"],
                    proyecto = collection["proyecto"],
                    prioridad = Convert.ToInt32(collection["prioridad"]),
                    fecha = collection["proyecto"]

                };
                Singleton.Instance.ProjectsManualList.Add(newProjectsManual);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProjectsManualController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProjectsManualController/Edit/5
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

        // GET: ProjectsManualController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProjectsManualController/Delete/5
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
