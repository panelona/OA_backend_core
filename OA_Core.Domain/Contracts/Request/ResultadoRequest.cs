using System.Diagnostics.CodeAnalysis;
namespace OA_Core.Domain.Contracts.Request
{
	//TODO: Implementar testes unitários
	[ExcludeFromCodeCoverage]
	public class ResultadoRequest
	{
		public Guid AvaliacaoId { get; set; }
		public Guid AlunoId { get; set; }
		public double Nota { get; set; }
	}
}
