﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OA_Core.Domain.Contracts.Response;
using OA_Core.Domain.Enums;
using OA_Core.Domain.Exceptions;
using OA_Core.Domain.Utils;
using System.Diagnostics.CodeAnalysis;

namespace OA_Core.Api.Filters
{
	[ExcludeFromCodeCoverage]
	public class ExceptionFilter : ExceptionFilterAttribute
	{
		private readonly ILogger<ExceptionFilter> _logger;

		public ExceptionFilter(ILogger<ExceptionFilter> logger)
		{
			_logger = logger;
		}

		public override Task OnExceptionAsync(ExceptionContext context)
		{
			var response = new InformacaoResponse();
			var environment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

			if (context.Exception is InformacaoException)
			{
				InformacaoException informacaoException = (InformacaoException)context.Exception;
				response.Codigo = informacaoException.Codigo;
				response.Mensagens = informacaoException.Mensagens;

				if (environment != Environments.Production)
					response.MensagemDebug = context.Exception.Message;
			}
			else
			{
				response.Codigo = StatusException.Erro;
				response.Mensagens = new List<string> { "Erro inesperado " };
				if (environment != Environments.Production)
					response.MensagemDebug = context.Exception.Message;
				_logger.LogError(context.Exception, "Erro inesperado");
			}

			context.Result = new ObjectResult(response)
			{
				StatusCode = response.Codigo.GetStatusCode()
			};

			OnException(context);
			return Task.CompletedTask;
		}
	}
}
