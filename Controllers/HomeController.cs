using Lab4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            for (int i = 0; i <= 10; i++)
            {
                Singleton.Instance.TablaDePrueba.AgregarFinalLista();
            }
            Developer tumadre = new Developer("Chichis", "Hola", "JAJA", 1, "HOY");
            Developer tumadre2 = new Developer("Chichisa", "Holaaaaa", "JAJAnt", 3, "HOYa");
            Developer tumadre3 = new Developer("Chich", "Holaaaas", "JAJdA", 4, "HOYaaa");
            Singleton.Instance.TablaDePrueba.Pos(tumadre.prioridad).Agregar(1, tumadre);
            Singleton.Instance.TablaDePrueba.Pos(2).Agregar(2, tumadre2);
            Singleton.Instance.TablaDePrueba.Pos(3).Agregar(3, tumadre3);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
       
    }
}
