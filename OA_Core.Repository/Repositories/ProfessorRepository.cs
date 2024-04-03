using OA_Core.Domain.Entities;
using OA_Core.Domain.Interfaces.Repository;
using OA_Core.Repository.Context;
using System.Diagnostics.CodeAnalysis;
namespace OA_Core.Repository.Repositories
{
	[ExcludeFromCodeCoverage]
	public class ProfessorRepository : BaseRepository<Professor>, IProfessorRepository
	{
		public ProfessorRepository(CoreDbContext coreDbContext) : base(coreDbContext)
		{
		}
	}
}
