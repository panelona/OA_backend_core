using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OA_Core.Domain.Entities;
using System.Diagnostics.CodeAnalysis;

namespace OA_Core.Repository.Mappings
{
	[ExcludeFromCodeCoverage]
	public class UsuarioEntityMap
	{
		public void Configure(EntityTypeBuilder<Usuario> builder)
		{
			//Ignora prop de validação
			builder.Ignore(u => u.Valid).Ignore(u => u.ValidationResult);

			//Filtro para não buscar entidades deletadas
			builder.HasQueryFilter(c => c.DataDelecao == null);

			//Mapeamento de relações

			//Regras de negocio
			builder.HasIndex(c => c.Email).IsUnique();
		}
	}
}
