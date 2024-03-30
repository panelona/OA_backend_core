using OA_Core.Domain.Validations;

namespace OA_Core.Domain.Entities
{
	public class UsuarioCurso : Entidade
	{

		public UsuarioCurso(Guid cursoId, Guid usuarioId, string status, int progresso)
		{
			Id = Guid.NewGuid();
			CursoId = cursoId;
			UsuarioId = usuarioId;
			Status = status;
			Progresso = progresso;
			Validate(this, new UsuarioCursoValidator());
		}

		public Guid UsuarioId { get; set; }
		public Usuario Usuario { get; set; }
		public Guid CursoId { get; set; }
		public Curso Curso { get; set; }
		public string Status { get; set; }
		public int Progresso { get; set; }
	}
}
