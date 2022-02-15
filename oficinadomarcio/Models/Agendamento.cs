using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace oficinadomarcio.Models
{
    [Table("Agendamentos")]
    public class Agendamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        [StringLength(1000)]
        public string Descricao { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Data_agendamento { get; set; }

        [ForeignKey("Horario")]
        public int HorarioId { get; set; }
        public Horario Horario { get; set; }

        // Vincular o agendamento ao cliente
        [ForeignKey("Cliente")]
        public string CpfCliente { get; set; }
        public Cliente Cliente { get; set; }

        // Vincular o agendamento ao veículo 
        [ForeignKey("Veiculo")]
        public string PlacaVeiculo { get; set; }
        public Veiculo Veiculo { get; set; }
    }
}