﻿using FluentValidation;
using OA_Core.Domain.Entities;

namespace OA_Core.Domain.Validations
{
	public class CursoProfessorValidator : AbstractValidator<CursoProfessor>
	{
		public CursoProfessorValidator()
		{
			RuleFor(u => u.ProfessorId)
				.NotEmpty()
				.WithMessage("ProfessorId não pode ser nulo");
		}
	}
}
