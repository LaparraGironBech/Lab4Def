using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4.Models
{
    public class DeveloperIndice : IComparable
    {
        public int prioridad;
        public string titulo;
        public int CompareTo(object? obj)
        {
            return 0;
        }
    }
}
