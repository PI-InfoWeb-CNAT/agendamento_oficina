﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace oficinadomarcio.Models
{
    [Table("ProdutoItem")]
    public class ProdutoItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Vincular o Item ao Agendamento
        [ForeignKey("Agendamento")]
        public int IdAgendamento { get; set; }
        public Agendamento Agendamentos { get; set; }

        // Vincular o Item ao Produto
        [ForeignKey("Produto")]
        public int IdProduto { get; set; }
        public Produto Produtos { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [Required]
        public double Preco { get; set; }
    }
}