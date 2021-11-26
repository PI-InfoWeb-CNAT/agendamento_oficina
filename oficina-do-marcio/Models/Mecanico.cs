﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace oficina_do_marcio.Models
{
    [Table("Mecanicos")]
    public class Mecanico
    {
        [Key] 
        [StringLength(11)]
        public string Cpf { get; set; }

        [Required]
        [MaxLength(255)]
        public string Senha { get; set; }

        [Required] 
        [MaxLength(50)]
        public string Nome { get; set; }

        [MaxLength(15)]
        public string Telefone { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? Data_cadastro { get; set; } = DateTime.Now;
    }
}