using Microsoft.AspNetCore.Http;
using OA_Core.Domain.Enums;

namespace OA_Core.Domain.Interfaces.Service
{
	public interface IImagemService
	{
		Task<string> SalvarImagemAsync(IFormFile file, TipoImagem tipoImagem);

	}
}
