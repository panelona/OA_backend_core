using FluentValidation;
using OA_Core.Domain.Entities;

namespace OA_Core.Domain.Validations
{
	public class CursoValidator : AbstractValidator<Curso>
	{
		public CursoValidator()
		{
			RuleFor(u => u.Nome)
			   .NotEmpty()
			   .WithMessage("Nome precisa ser preenchida");

			RuleFor(u => u.Descricao)
				.NotEmpty()
				.WithMessage("Descricao precisa ser preenchida");

			RuleFor(u => u.Categoria)
				.NotEmpty()
				.WithMessage("Categoria precisa ser preenchida");

			RuleFor(u => u.PreRequisito)
				.NotEmpty()
				.WithMessage("PreRequisito precisa ser preenchida");
		}
	}
}
