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
            var agendamento = (Agendamento) validationContext.ObjectInstance ?? null;

            if (agendamento.Data_agendamento == null || agendamento.Data_agendamento == DateTime.MinValue) 
                agendamento.Data_agendamento = DateTime.MinValue;

            var agendamentos = db.agendamento.ToList().Where(a => a.Data_agendamento.Date == agendamento.Data_agendamento.Date);

            bool existe = false;

            foreach (Agendamento ag in agendamentos)
            {
                if (ag.HorarioId == agendamento.HorarioId)
                {
                    existe = true;
                };
            }

            return existe ? new ValidationResult("Horário não disponível") : ValidationResult.Success;
        }
    }
}

