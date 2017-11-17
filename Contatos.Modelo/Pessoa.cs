﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contatos.Modelo
{
    class Pessoa
    {
        [Key]
        public Guid Id { get; set; }    
        [Required]
        public int Usuario { get; set; }    

    }
}
