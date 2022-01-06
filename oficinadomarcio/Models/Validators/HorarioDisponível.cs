using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using oficinadomarcio.Context;

namespace oficinadomarcio.Models
{
    public class HorarioDisponivel : ValidationAttribute //custom data annotation validator inherit ValidationAttribute
    {
        private EFContext db;
        public HorarioDisponivel()
        {
            db = new EFContext();
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext) //pick the second one when type override IsValid
        {
            var agendamento = (Agendamento) validationContext.ObjectInstance;
            var agendamentos = db.agendamento.ToList().Where(a => a.Data_servico.Value.Date == agendamento.Data_servico.Value.Date);

            bool existe = false;

            foreach (Agendamento ag in agendamentos)
            {
                if (ag.HorarioId == agendamento.HorarioId) existe = true;
            }

            if (existe)
            {
                return new ValidationResult("Horário não disponível");
            }

            return existe ? new ValidationResult("Horário não disponível") : ValidationResult.Success;
        }
    }
}