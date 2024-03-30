namespace OA_Core.Domain.Contracts.Request
{
	public class AulaRequest : AulaRequestPut
	{
		public Guid CursoId { get; set; }
	}
}
