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

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue("getutcdate()")]
        public DateTime? Data_agendamento { get; set; } = DateTime.Now;

        [DisplayName("Data")]
        [Required(ErrorMessage = "Uma data deve ser inserida")]
        public DateTime? Data_servico { get; set; }

        [ForeignKey("Horario")]
        [HorarioDisponivel]
        public int HorarioId { get; set; }
        public Horario Horario { get; set; }

        public Agendamento()
        {
            this.Data_agendamento = DateTime.UtcNow;
        }
    }
}