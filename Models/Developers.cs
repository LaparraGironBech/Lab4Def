using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace Lab4.Models
{
    public class Developers
    {
        [Required]

        public int? Id { get; set; }
        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        public ColaDePrioridad colaDeveloper = new ColaDePrioridad(20);

        public TablaHash<string, Developer> HASHTABLE = new TablaHash<string, Developer>();

        
        public Developers( int id, string nombre, string apellido)//metodo constructor, servira para asignar los valores y el tamaño a la tabla hash
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellido = apellido;

            
            for (int i = 0; i < 10; i++)//<---------Dar tamaño a la tabla hash------------>
            {
                HASHTABLE.AgregarFinalLista();
            }
          }    
        }
        
    }
    

