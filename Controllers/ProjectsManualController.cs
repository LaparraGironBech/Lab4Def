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
            
        //    string key = "";
        //    for (int i = 0; i < Singleton.Instance.DevelopersList[0].colaDeveloper.heapArray.Length; i++)
        //    {
        //        if (Singleton.Instance.DevelopersList[0].colaDeveloper.heapArray[0] == Singleton.Instance.DevelopersList[0].colaDeveloper.HeapBuscar[i].prioridad)
        //        {
        //            key = Singleton.Instance.DevelopersList[0].colaDeveloper.HeapBuscar[i].titulo;
        //        }
        //    }

        // string titulo = Singleton.Instance.DevelopersList[0].HASHTABLE.Pos(FHash(key)).BuscarObjeto(key).titulo;
        // string descripcion = Singleton.Instance.DevelopersList[0].HASHTABLE.Pos(FHash(key)).BuscarObjeto(key).descripcion;
        //string proyecto = Singleton.Instance.DevelopersList[0].HASHTABLE.Pos(FHash(key)).BuscarObjeto(key).proyecto;
        //int prioridad  =    Singleton.Instance.DevelopersList[0].HASHTABLE.Pos(FHash(key)).BuscarObjeto(key).prioridad;
        //string fecha= Singleton.Instance.DevelopersList[0].HASHTABLE.Pos(FHash(key)).BuscarObjeto(key).fecha;

        //    ProjectsManual AgregarTareas = new ProjectsManual(titulo,descripcion,proyecto,prioridad,fecha);
            //return View(Singleton.Instance.ProjectsManualList);
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
                    fecha = collection["fecha"]

                };
                //Agregar a mi tabla hash
                Developer nuevo = new Developer(newProjectsManual.titulo, newProjectsManual.descripcion, newProjectsManual.proyecto, newProjectsManual.prioridad, newProjectsManual.fecha);
                int codigoHash = FHash(nuevo.titulo);//genera el código hash
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
        public int FHash(string titulo)// Nuestra función hash
        {

            titulo = titulo.ToLower(); //convertir todo a minuscula 
            int conversion = 0; //devolverá el valor en número
            char letra; // detecta letra por letra de la cadena
            for (int i = 0; i < titulo.Length; i++)
            {
                letra = Convert.ToChar(titulo.Substring(i, 1));
                conversion = conversion + Convert.ToInt32(letra);

            }

            conversion = conversion % 10;
            return conversion;
        }

    }
}
