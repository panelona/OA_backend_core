using OA_Core.Domain.Entities;
using OA_Core.Domain.Interfaces.Repository;
using OA_Core.Repository.Context;
using System.Diagnostics.CodeAnalysis;


namespace OA_Core.Repository.Repositories
{
	[ExcludeFromCodeCoverage]
	public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
	{
		public UsuarioRepository(CoreDbContext coreDbContext) : base(coreDbContext)
		{
		}
	}
}
