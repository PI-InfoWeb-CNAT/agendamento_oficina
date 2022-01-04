using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace oficinadomarcio.Models
{
    [Table("Veiculos")]
    public class Veiculo
    {
        [Key] 
        [MaxLength(7)]
        public string Placa { get; set; }

        [Required]
        [MaxLength(20)] 
        public string Marca { get; set; }

        [Required]
        [MaxLength(100)] 
        public string Modelo { get; set; }

        [Required]
        [Range(0, 2050)]
        public int Ano { get; set; }
    }
}