using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace oficinadomarcio.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Descricao { get; set; }

        [Required]
        [MaxLength(50)]
        public string Marca { get; set; }

        [Required]
        [MaxLength(30)]
        public string Categoria { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [Required]
        public double Preco { get; set; }
    }
}