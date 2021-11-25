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
        [Key]
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
    }
}