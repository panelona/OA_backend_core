using FluentValidation;
using OA_Core.Domain.Entities;

namespace OA_Core.Domain.Validations
{
	public class AulaValidator : AbstractValidator<Aula>
	{
		public AulaValidator()
		{
			RuleFor(u => u.Titulo)
			   .NotEmpty()
			   .WithMessage("Titulo precisa ser preenchido");
		}
	}
}
