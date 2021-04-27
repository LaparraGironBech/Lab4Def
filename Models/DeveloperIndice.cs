using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4.Models
{
    public class DeveloperIndice : IComparable
    {        
        public int CompareTo(object? obj)
        {
            DeveloperIndice value = (DeveloperIndice)obj;
            return titulo.CompareTo(value.titulo);
        }
        public int prioridad { get; set; }
        public string titulo { get; set; }

        public DeveloperIndice(string Titulo, int Prioridad)
        {
            prioridad = Prioridad;
            titulo = Titulo;
        }
    }
}
