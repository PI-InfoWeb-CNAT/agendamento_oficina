using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace oficinadomarcio.Models
{
    [Table("Servicos")]
    public class Servico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Resumo { get; set; }

        [Required]
        [StringLength(255)]
        public string Descricao { get; set; }

        [Range(0, double.MaxValue)]
        public double Valor { get; set; }


        [ForeignKey("Agendamento")]
        public int AgendamentoId { get; set; }
        public Agendamento Agendamento { get; set; }


        [ForeignKey("Veiculo")]
        public string VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; }


        [ForeignKey("Mecanico")]
        public string MecanicoId { get; set; }
        public Mecanico Mecanico { get; set; }


        [Required]
        [DefaultValue(false)]
        public bool Finalizado { get; set; }

        public DateTime Data_finalizacao { get; set; }
    }
}