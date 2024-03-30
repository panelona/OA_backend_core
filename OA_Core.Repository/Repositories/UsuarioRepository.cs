using OA_Core.Domain.Entities;
using OA_Core.Domain.Interfaces.Repository;
using OA_Core.Repository.Context;


namespace OA_Core.Repository.Repositories
{
	public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
	{
		public UsuarioRepository(CoreDbContext coreDbContext) : base(coreDbContext)
		{
		}
	}
}
