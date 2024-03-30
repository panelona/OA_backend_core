using OA_Core.Domain.Contracts.Request;
using OA_Core.Domain.Contracts.Response;

namespace OA_Core.Domain.Interfaces.Service
{
	public interface IUsuarioCursoService
	{
		Task<Guid> CadastrarUsuarioACursoAsync(UsuarioCursoRequest cursoRequest);
		Task<List<CursoParaUsuarioResponse>> ObterCursosDeUsuarioPorIdAsync(Guid cursoId);
	}
}
