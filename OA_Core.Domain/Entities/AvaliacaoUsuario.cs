﻿using FluentValidation;
using FluentValidation.Results;
using OA_Core.Domain.Validations;
using System.Diagnostics.CodeAnalysis;

namespace OA_Core.Domain.Entities
{
	//TODO: Implementar Testes Unitários
	[ExcludeFromCodeCoverage]
	public class AvaliacaoUsuario
	{
		public AvaliacaoUsuario(Guid avaliacaoId,
								Guid usuarioId)
		{
			AvaliacaoId = avaliacaoId;
			UsuarioId = usuarioId;
			Validate(this, new AvaliacaoUsuarioValidator());
		}

		public Guid AvaliacaoId { get; set; }
		public virtual Avaliacao Avaliacao { get; set; }
		public Guid UsuarioId { get; set; }
		public virtual Usuario Usuario { get; set; }
		public double? NotaObtida { get; set; }
		public bool Aprovado { get; set; }
		public DateTime Inicio { get; set; }
		public DateTime? Fim { get; set; }
		public bool Valid { get; set; }
		public ValidationResult ValidationResult { get; set; }

		public bool Validate<T>(T model, AbstractValidator<T> validator)
		{
			ValidationResult = validator.Validate(model);
			return Valid = ValidationResult.IsValid;
		}
	}
}
