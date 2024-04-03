using FluentValidation;
using OA_Core.Domain.Entities;
using System.Diagnostics.CodeAnalysis;

namespace OA_Core.Domain.Validations
{
	//Implementar testes unitários
	[ExcludeFromCodeCoverage]
	public class AvaliacaoUsuarioValidator : AbstractValidator<AvaliacaoUsuario>
	{
		public AvaliacaoUsuarioValidator()
		{
			RuleFor(u => u.AvaliacaoId)
				.NotEmpty()
				.WithMessage("Id de avaliacao precisa ser preenchido");
			RuleFor(u => u.UsuarioId)
				.NotEmpty()
				.WithMessage("Id de usuario precisa ser preenchido");
		}
	}
}
