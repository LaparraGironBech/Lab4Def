using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Lab4.Models;

namespace Lab4.Controllers
{


    public class DevelopersController : Controller
    {

        //Cargar archivo CSV
        private IHostingEnvironment Environment;
        public DevelopersController(IHostingEnvironment _environment)
        {
            Environment = _environment;
        }
        //termina parte de csv

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
                var newDevelopers = new Developers
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
                return RedirectToAction(nameof(Details));
            }
            catch
            {
                return View();
            }
        }
        //carga csv------------------------------------------------------------------------>
        [HttpPost]
        public IActionResult Index(IFormFile postedFile)
        {
           
            if (postedFile != null)
            {
                string path = Path.Combine(this.Environment.WebRootPath, "Uploads");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string fileName = Path.GetFileName(postedFile.FileName);
                string filePath = Path.Combine(path, fileName);
                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }
                string csvData = System.IO.File.ReadAllText(filePath);
                DataTable dt = new DataTable();
                bool firstRow = true;
                foreach (string row in csvData.Split('\n'))
                {
                    if (!string.IsNullOrEmpty(row))
                    {
                        if (!string.IsNullOrEmpty(row))
                        {
                            if (firstRow)
                            {

                                foreach (string cell in row.Split(','))//Sirve para no tomar el encabezado del archivo
                                {

                                    //dt.Columns.Add(cell.Trim());

                                }

                                firstRow = false;
                            }
                            else
                            {
                                //dt.Rows.Add();
                                int i = 0;
                                int cont = 0;
                                string[] NodoM = new string[5] { "", "", "", "", "" };
                                int encontrar = 0;
                                string cell2 = "";
                                foreach (string cell in row.Split(','))
                                {
                                    if (cell.Substring(0, 1) != "\"" && encontrar == 0) //identifica que las comas del texto sean validas y no las tome como la delimitación por comas
                                    {
                                        //dt.Rows[dt.Rows.Count - 1][i] = cell.Trim();
                                        NodoM[cont] = cell.Trim();
                                        cell2 = "";
                                        cont++;
                                        i++;
                                    }
                                    else
                                    {
                                        cell2 = cell2 + cell + ", "; encontrar++;
                                        if (cell.Substring((cell.Length - 1), 1) == "\"")
                                        {
                                            encontrar = 0;
                                            cell2 = cell2.Remove(0, 1);
                                            cell2 = cell2.Remove(cell2.Length - 3, 3);
                                            //dt.Rows[dt.Rows.Count - 1][i] = cell2.Trim();
                                            NodoM[cont] = cell2.Trim();
                                            cont++;
                                            i++;
                                            cell2 = "";
                                        }

                                    }
                                }
                                //parte para agregar en cada iteración ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
                                //Llenar Tablahash
                                Developer AgregarDeveloper = new Developer(NodoM[0], NodoM[1], NodoM[2], Convert.ToInt16(NodoM[3]), NodoM[4]); //Se crea un objeto developer para agregar a la tabla hash
                                int codigoHash = FHash(NodoM[0]);//genera el código hash

                                //Verificar si el titulo no es repetido si no es repetido lo agrega
                                bool Existe = false;
                                Existe = Singleton.Instance.HASHTABLE.Pos(codigoHash).Existe(AgregarDeveloper.titulo);
                                if (Existe == false)
                                {
                                    Singleton.Instance.HASHTABLE.Pos(codigoHash).Agregar(NodoM[0], AgregarDeveloper);//Se van almacenando a la tabla hash
                                }
                            }
                        }
                    }
                }
                Console.WriteLine(Singleton.Instance.prioridad);
                Console.ReadKey();
                return RedirectToAction(nameof(Create));
            }


            return View();

        }
            //termina carga de csv------->
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
