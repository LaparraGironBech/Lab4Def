using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4.Models
{
    public class Developer
    {
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public string proyecto { get; set; }
        public int prioridad { get; set; }
        public string fecha { get; set; }

        public Developer(string Nombre,string Descripcion,string Proyecto,int Prioridad,string Fecha)
        {
            titulo = Nombre;
            descripcion = Descripcion;
            proyecto = Proyecto;
            prioridad = Prioridad;
            fecha = Fecha;
        }
    }
}
