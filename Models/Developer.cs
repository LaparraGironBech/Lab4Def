using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4.Models
{
    public class Developer
    {
        string titulo { get; set; }
        string descripcion { get; set; }
        string proyecto { get; set; }
        int prioridad { get; set; }
        string fecha { get; set; }

        public Developer(string Nombre,string Descripcion,string Proyecto,int Prioridad,string Fecha)
        {
            titulo = Nombre;
            descripcion = Descripcion;
            proyecto = Proyecto;
            prioridad = prioridad;
            fecha = Fecha;
        }
    }
}
