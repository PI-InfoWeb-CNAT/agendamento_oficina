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
        [StringLength(11)]
        public string Cpf { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool Admin { get; set; }

        [Required]
        [MaxLength(255)]
        public string Senha { get; set; }

        [Required] 
        [MaxLength(50)]
        public string Nome { get; set; }

        [MaxLength(15)]
        public string Telefone { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue("getutcdate()")]
        public DateTime? Data_cadastro { get; set; } = DateTime.Now;
    }
}