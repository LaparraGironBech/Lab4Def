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
        private Singleton()
        {
            DevelopersList = new List<Developers>();
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

