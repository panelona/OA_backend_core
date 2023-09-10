﻿using FluentValidation;
using OA_Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_Core.Domain.Validations
{
    public class AulaValidator : AbstractValidator<Aula>
    {
        public AulaValidator()
        {
            RuleFor(u => u.Nome)
               .NotEmpty()
               .WithMessage("Nome precisa ser preenchida");

            RuleFor(u => u.Descricao)
                .NotEmpty()
                .WithMessage("Descricao precisa ser preenchida");

            RuleFor(u => u.Caminho)
                .NotEmpty()
                .WithMessage("Caminho precisa ser preenchido");

            RuleFor(u => u.Tipo)
                .NotEmpty()
                .WithMessage("Tipo precisa ser preenchido");

            RuleFor(u => u.Duracao)
                .NotEmpty()
                .WithMessage("Duração precisa ser preenchida");

            RuleFor(u => u.Ordem)
                .NotEmpty()
                .WithMessage("Ordem precisa ser preenchida");
        }
    }
}
