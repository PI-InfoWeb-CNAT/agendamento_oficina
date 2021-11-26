using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace oficina_do_marcio.Models
{
    [Table("Orcamentos")]
    public class Orcamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double Valor { get; set; }

        [Required]
        [StringLength(1000)]
        public string Descricao { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue("getutcdate()")]
        public DateTime Data_orcamento { get; set; } = DateTime.Now;
    }
}