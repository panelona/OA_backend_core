using System.Diagnostics.CodeAnalysis;

namespace OA_Core.Domain.Contracts.Request
{
	//TODO: Implementar testes unitários
	[ExcludeFromCodeCoverage]
	internal class CertificadoAlunoRequest
	{
		public Guid CursoId { get; set; }
		public Guid AlunoId { get; set; }
		public DateTime DataEmissao { get; set; }
	}
}
