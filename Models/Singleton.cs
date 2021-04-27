using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4.Models
{
    public class Singleton
    {
        private readonly static Singleton _instance = new Singleton();
        public List<Developers> DevelopersList;
        public TablaHash<int, Developer> TablaDePrueba = new TablaHash<int, Developer>();
        public List<DeveloperIndice> prioridad = new List<DeveloperIndice>();
        //public ColaDePrioridad<DeveloperIndice> Heap = new ColaDePrioridad<DeveloperIndice>(20);
        //Se crea  la tabla de 10 
            
    private Singleton()
        {
            DevelopersList = new List<Developers>();

            //<---------Dar tamaño a la tabla hash------------>
            for (int i = 0; i < 10; i++)
            {
                TablaDePrueba.AgregarFinalLista();
            }

        }

        public static Singleton Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}

