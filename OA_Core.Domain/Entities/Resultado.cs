using System.Diagnostics.CodeAnalysis;

namespace OA_Core.Domain.Entities
{
	//Implementar testes unitários
	[ExcludeFromCodeCoverage]
	public class Resultado
	{
		public Guid AvaliacaoId { get; set; }
		public Guid AlunoId { get; set; }
		public double Nota { get; set; }
	}
}
