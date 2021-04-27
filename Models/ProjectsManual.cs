using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace Lab4.Models
{
    public class ProjectsManual 
    {
        
        [Required]
        public string titulo { get; set; }
        [Required]
        public string descripcion { get; set; }
        [Required]
        public string proyecto { get; set; }
        [Required]
        public int prioridad { get; set; }
        [Required]
        public string fecha { get; set; }

       
    }
}
