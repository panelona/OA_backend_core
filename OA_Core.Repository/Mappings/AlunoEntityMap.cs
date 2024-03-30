using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OA_Core.Domain.Entities;
using System.Diagnostics.CodeAnalysis;

namespace OA_Core.Repository.Mappings
{
	[ExcludeFromCodeCoverage]
	public class AlunoEntityMap
	{
		public void Configure(EntityTypeBuilder<Aluno> builder)
		{
			//Ignora prop de validação
			builder.Ignore(a => a.Valid).Ignore(a => a.ValidationResult);

			//Filtro para não buscar entidades deletadas
			builder.HasQueryFilter(c => c.DataDelecao == null);

			//Mapeamento de relações
			builder.HasOne(a => a.usuario)
				.WithMany()
				.HasForeignKey(a => a.UsuarioId);
		}
	}
}
