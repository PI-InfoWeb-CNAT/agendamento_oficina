using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace oficina_do_marcio.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        [Key] 
        [StringLength(11)]
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

        [MaxLength(255)]
        public string Endereco { get; set; }

        [DefaultValue("getutcdate()")]
        public DateTime? Data_cadastro { get; set; } = DateTime.Now;

        public Cliente()
        {
            this.Data_cadastro = DateTime.UtcNow;
        }
    }
}