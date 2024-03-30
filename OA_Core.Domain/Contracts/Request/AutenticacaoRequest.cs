using System.ComponentModel.DataAnnotations;

namespace OA_Core.Domain.Contracts.Request
{
	public class AutenticacaoRequest
	{
		[Required(ErrorMessage = "O campo 'Senha' é obrigatorio")]
		public string Senha { get; set; } = string.Empty;

		[Required(ErrorMessage = "O campo 'Email' é obrigatorio")]
		public string Email { get; set; } = string.Empty;
	}
}
