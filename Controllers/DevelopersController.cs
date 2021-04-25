using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab4.Models;

namespace Lab4.Controllers
{
    public class DevelopersController : Controller
    {
        // GET: DeveloperController
        public ActionResult Index()
        {
            return View(Singleton.Instance.DevelopersList);
        }

        // GET: DeveloperController/Details/5
        public ActionResult Details(int id)
        {
            var ViewDevelopers = Singleton.Instance.DevelopersList.Find(x => x.Id == id);
            return View(ViewDevelopers);
            
        }

        // GET: DeveloperController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeveloperController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var newDevelopers = new Models.Developers
                {
                    Id = Convert.ToInt32(collection["Id"]),
                    Nombre = collection["Nombre"],
                    Apellido = collection["Apellido"]
                    
                };
                Singleton.Instance.DevelopersList.Add(newDevelopers);
                return RedirectToAction(nameof(Index));


                
            }
            catch
            {
                return View();
            }
        }

        // GET: DeveloperController/Edit/5
        public ActionResult Edit(int id)
        {
            var editDevelopers = Singleton.Instance.DevelopersList.Find(x => x.Id == id);
            return View(editDevelopers);
        }

        // POST: DeveloperController/Edit/5
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

        // GET: DeveloperController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DeveloperController/Delete/5
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
