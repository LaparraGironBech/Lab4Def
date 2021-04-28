﻿using System;
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
              
    }
    
}
