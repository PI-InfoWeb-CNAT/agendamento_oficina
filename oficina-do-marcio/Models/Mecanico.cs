using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace oficina_do_marcio.Models
{
    public class Mecanico
    {
        [Key] [MaxLength(11)]
        public string Cpf { get; set; }
        
        [Required] [MaxLength(50)]
        public string Nome { get; set; }
        [MaxLength(15)] 
        public string Telefone { get; set; }
    }
}