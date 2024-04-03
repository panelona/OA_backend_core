using System.Diagnostics.CodeAnalysis;

namespace OA_Core.Domain.Entities
{
	//TODO: Implementar testes unitários
	[ExcludeFromCodeCoverage]
	public class CertificadoAluno
	{
		public Guid CursoId { get; set; }
		public Guid AlunoId { get; set; }
		public DateTime DataEmissao { get; set; }
	}
}
