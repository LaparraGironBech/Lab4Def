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
        public TablaHash<string, Developer> HASHTABLE = new TablaHash< string, Developer>();
        //Se crea  la tabla de 10 
            
    private Singleton()
        {
            DevelopersList = new List<Developers>();

            //<---------Dar tamaño a la tabla hash------------>
            for (int i = 0; i < 10; i++)
            {
                HASHTABLE.AgregarFinalLista();
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

