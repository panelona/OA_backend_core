using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OA_Core.Domain.Entities;
using System.Diagnostics.CodeAnalysis;

namespace OA_Core.Repository.Mappings
{
	[ExcludeFromCodeCoverage]
	public class AulaEntityMap
	{
		public void Configure(EntityTypeBuilder<Aula> builder)
		{
			//Ignora prop de validação
			builder.Ignore(a => a.Valid).Ignore(a => a.ValidationResult);

			//Filtro para não buscar entidades deletadas
			builder.HasQueryFilter(a => a.DataDelecao == null);

			//Mapeamento de relações
			builder.HasOne(a => a.curso)
				.WithMany()
				.HasForeignKey(a => a.CursoId);

			//Implementa o TPH
			builder.HasDiscriminator<int>("TipoAulaEnum")
				.HasValue<AulaOnline>(0)
				.HasValue<AulaVideo>(1)
				.HasValue<AulaTexto>(2)
				.HasValue<AulaDownload>(3);

		}
	}
}
