using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace OA_Core.Domain.Contracts.Request
{
	[ExcludeFromCodeCoverage]
	//TODO: Implementar testes unitários

	public class AutenticacaoRequest
	{
		[Required(ErrorMessage = "O campo 'Senha' é obrigatorio")]
		public string Senha { get; set; } = string.Empty;

		[Required(ErrorMessage = "O campo 'Email' é obrigatorio")]
		public string Email { get; set; } = string.Empty;
	}
}
