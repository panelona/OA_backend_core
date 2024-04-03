using System.Diagnostics.CodeAnalysis;

namespace OA_Core.Domain.Contracts.Response
{

	//TODO: Implementar testes unitários
	[ExcludeFromCodeCoverage]
	public class CertificadoResponse : BaseResponse
	{
		public string Nome { get; set; }
		public string Descricao { get; set; }
		public int CargaHoraria { get; set; }
		public byte[] Assinatura { get; set; }
		public string SeloCaminho { get; set; }
	}
}
