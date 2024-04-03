using System.Diagnostics.CodeAnalysis;

namespace OA_Core.Domain.Notifications
{
	[ExcludeFromCodeCoverage]
	public class Notificacao
	{
		public Notificacao(string mensagem)
		{
			Mensagem = mensagem;
		}
		public string Mensagem { get; set; }
	}
}
