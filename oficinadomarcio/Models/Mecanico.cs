using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace oficinadomarcio.Models
{
    [Table("Mecanicos")]
    public class Mecanico
    {
        [Key]
        public string Cpf { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [MaxLength(15)]
        public string Telefone { get; set; }

        [Required]
        [MaxLength(100)]
        [Index]
        public string Email { get; set; }

        [Required]
        [MaxLength(255)]
        public string Senha { get; set; }
    }
}