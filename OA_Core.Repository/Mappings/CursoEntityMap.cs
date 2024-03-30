using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OA_Core.Domain.Entities;
using System.Diagnostics.CodeAnalysis;

namespace OA_Core.Repository.Mappings
{
	[ExcludeFromCodeCoverage]
	public class CursoEntityMap
	{
		public void Configure(EntityTypeBuilder<Curso> builder)
		{
			//Ignora prop de validação
			builder.Ignore(c => c.Valid).Ignore(c => c.ValidationResult);

			//Filtro para não buscar entidades deletadas
			builder.HasQueryFilter(c => c.DataDelecao == null);

			//Mapeamento de relações
			builder.HasOne(c => c.Professor)
				.WithMany()
				.HasForeignKey(c => c.ProfessorId);
		}
	}
}
