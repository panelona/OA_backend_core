﻿using OA_Core.Domain.Contracts.Request;
using OA_Core.Domain.Contracts.Response;
using OA_Core.Domain.Entities;

namespace OA_Core.Domain.Interfaces.Service
{
	public interface IUsuarioCursoService
	{
		Task<Guid> CadastraUsuarioCursoAsync(UsuarioCursoRequest cursoRequest);
		Task<List<CursoParaUsuarioResponse>> ObterCursosDeUsuarioIdAsync(Guid cursoId);
	}
}
