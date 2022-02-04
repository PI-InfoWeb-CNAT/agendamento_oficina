using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace oficinadomarcio.Models
{
    [Table("Horarios")]
    public class Horario
    {
        [Key]
        public int Id { get; set; }
        [HorarioDisponivel]
        public string Hora { get; set; }
    }
}