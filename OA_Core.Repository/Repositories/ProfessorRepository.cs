﻿using OA_Core.Domain.Entities;
using OA_Core.Domain.Interfaces.Repository;
using OA_Core.Repository.Context;
namespace OA_Core.Repository.Repositories
{
	public class ProfessorRepository : BaseRepository<Professor>, IProfessorRepository
	{
		public ProfessorRepository(CoreDbContext coreDbContext) : base(coreDbContext)
		{
		}
	}
}
