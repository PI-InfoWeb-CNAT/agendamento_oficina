using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace oficinadomarcio.Models
{
    public class ServicoItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Vincular o Item ao Agendamento
        [ForeignKey("Agendamento")]
        public int IdAgendamento { get; set; }
        public Agendamento Agendamento { get; set; }

        // Vincular o Item ao Serviço
        [ForeignKey("Servico")]
        public int IdServico { get; set; }
        public Servico Servico { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [Required]
        public double Preco { get; set; }
    }
}