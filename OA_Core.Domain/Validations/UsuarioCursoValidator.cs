using FluentValidation;
using OA_Core.Domain.Entities;

namespace OA_Core.Domain.Validations
{
	public class UsuarioCursoValidator : AbstractValidator<UsuarioCurso>
	{
		public UsuarioCursoValidator()
		{
			RuleFor(u => u.UsuarioId)
				.NotEmpty()
				.WithMessage("UsuarioId não pode ser nulo");
		}
	}
}
