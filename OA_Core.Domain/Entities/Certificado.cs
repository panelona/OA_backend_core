using System.Diagnostics.CodeAnalysis;

namespace OA_Core.Domain.Entities
{
	//Impleentar teste unitário
	[ExcludeFromCodeCoverage]
	public class Certificado : Entidade
	{
		public string Nome { get; set; }
		public string Descricao { get; set; }
		public int CargaHoraria { get; set; }
		public byte[] Assinatura { get; set; }
		public string SeloCaminho { get; set; }
	}
}
