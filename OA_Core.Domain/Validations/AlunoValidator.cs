using FluentValidation;
using OA_Core.Domain.Entities;

namespace OA_Core.Domain.Validations
{
	public class AlunoValidator : AbstractValidator<Aluno>
	{
		public AlunoValidator()
		{

			RuleFor(a => a.Foto)
				.NotEmpty()
				.WithMessage("É necessário anexar a foto");

			RuleFor(a => a.Cpf)
				.NotEmpty()
				.WithMessage("Cpf é obrigatório");
		}
	}
}
