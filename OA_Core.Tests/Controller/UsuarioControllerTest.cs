using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using OA_Core.Api.Controllers;
using OA_Core.Domain.Contracts.Request;
using OA_Core.Domain.Contracts.Response;
using OA_Core.Domain.Entities;
using OA_Core.Domain.Interfaces.Service;
using OA_Core.Tests.Config;

namespace OA_Core.Tests.Controller
{
	[Trait("Controller", "Usuario Controller Test")]
	public class UsuarioControllerTest
	{
		private readonly Fixture _fixture;
		private readonly IUsuarioService _cursoSevice;
		private readonly IUsuarioCursoService _usuarioCursoService;
		private readonly IMapper _mapper;

		public UsuarioControllerTest()
		{
			_mapper = MapperConfig.Get();
			_fixture = FixtureConfig.GetFixture();
			_cursoSevice = Substitute.For<IUsuarioService>();
			_usuarioCursoService = Substitute.For<IUsuarioCursoService>();
		}

		[Fact(DisplayName = "ObterTodosUsuarios_DeveRetornarLista")]
		public async Task ObterTodosUsuarios_DeveRetornarLista()
		{
			var usuarioController = new UsuarioController(_cursoSevice, _usuarioCursoService);

			var entity = _fixture.Create<List<UsuarioResponse>>();

			_cursoSevice.ObterTodosUsuariosAsync(0, 25).Returns(entity);

			var controllerResult = await usuarioController.ObterTodosUsuarios(0, 25);

			Assert.IsType<OkObjectResult>(controllerResult.Result);

			var resultValue = (controllerResult.Result as OkObjectResult).Value as PaginationResponse<UsuarioResponse>;

			resultValue.Resultado.Should().BeEquivalentTo(entity);
		}

		[Fact(DisplayName = "ObterUsuarioPorId_DeveRetornarUsuario")]
		public async Task ObterUsuarioPorId_DeveRetornarUsuario()
		{
			var usuarioController = new UsuarioController(_cursoSevice, _usuarioCursoService);

			var entity = _fixture.Create<UsuarioResponse>();
			Guid id = Guid.NewGuid();

			_cursoSevice.ObterUsuarioPorIdAsync(id).Returns(entity);

			var controllerResult = await usuarioController.ObterUsuarioPorId(id);

			Assert.IsType<OkObjectResult>(controllerResult.Result);

			var resultValue = (controllerResult.Result as OkObjectResult).Value as UsuarioResponse;

			resultValue.Should().BeEquivalentTo(entity);
		}


		[Fact(DisplayName = "CriaUsuario_Valido_DeveRetornar201")]
		public async Task CriaUsuario_Valido_DeveRetornar201()
		{
			var usuarioController = new UsuarioController(_cursoSevice, _usuarioCursoService);

			var usuarioRequest = _fixture.Create<UsuarioRequest>();

			var entity = _mapper.Map<Usuario>(usuarioRequest);

			_cursoSevice.CadastrarUsuarioAsync(usuarioRequest).Returns(entity.Id);

			var controllerResult = await usuarioController.CadastrarUsuario(usuarioRequest);
			var actionResult = Assert.IsType<CreatedResult>(controllerResult);

			Assert.Equal(StatusCodes.Status201Created, actionResult.StatusCode);
			Assert.Equal(entity.Id, actionResult.Value);
		}

		[Fact(DisplayName = "EditaUsuario_Valido_DeveRetornar204")]
		public async Task EditaUsuario_Valido_DeveRetornar204()
		{
			var usuarioController = new UsuarioController(_cursoSevice, _usuarioCursoService);

			var usuarioRequest = _fixture.Create<UsuarioRequest>();
			Guid id = Guid.NewGuid();

			await _cursoSevice.EditarUsuarioAsync(id, usuarioRequest);

			var controllerResult = await usuarioController.EditarUsuario(id, usuarioRequest);
			var actionResult = Assert.IsType<NoContentResult>(controllerResult);

			Assert.Equal(StatusCodes.Status204NoContent, actionResult.StatusCode);
		}

		[Fact(DisplayName = "ExcluiUsuario_Valido_DeveRoternar204")]
		public async Task ExcluiUsuario_Valido_DeveRoternar204()
		{
			var usuarioController = new UsuarioController(_cursoSevice, _usuarioCursoService);

			Guid id = Guid.NewGuid();

			await _cursoSevice.DeletarUsuarioAsync(id);

			var controllerResult = await usuarioController.DeletarUsuario(id);
			var actionResult = Assert.IsType<NoContentResult>(controllerResult);

			Assert.Equal(StatusCodes.Status204NoContent, actionResult.StatusCode);
		}

		[Fact(DisplayName = "CriaUsuarioCurso_Valido_DeveRetornar201")]
		public async Task CriaUsuarioCurso_Valido_DeveRetornar201()
		{
			var usuarioController = new UsuarioController(_cursoSevice, _usuarioCursoService);

			var usuarioRequest = new UsuarioCursoRequest
			{
				UsuarioId = Guid.NewGuid(),
				CursoId = Guid.NewGuid(),
				Progresso = 0,
				Status = 0,
			};

			var entity = _mapper.Map<UsuarioCurso>(usuarioRequest);

			_usuarioCursoService.CadastrarUsuarioACursoAsync(usuarioRequest).Returns(entity.Id);

			var controllerResult = await usuarioController.CadastrarCursoAUsuario(usuarioRequest);
			var actionResult = Assert.IsType<CreatedResult>(controllerResult);

			Assert.Equal(StatusCodes.Status201Created, actionResult.StatusCode);
			Assert.Equal(entity.Id, actionResult.Value);
		}



		[Fact(DisplayName = "GetUsuarioCursoByIdAsync_DeveRetornarLista")]
		public async Task GetUsuarioCursoByIdAsync_DeveRetornarLista()
		{
			var usuarioController = new UsuarioController(_cursoSevice, _usuarioCursoService);

			var entity = _fixture.Create<List<CursoParaUsuarioResponse>>();
			Guid id = Guid.NewGuid();

			_usuarioCursoService.ObterCursosDeUsuarioPorIdAsync(id).Returns(entity);

			var controllerResult = await usuarioController.ObterCursosDeUsuarioPorId(id);

			Assert.IsType<OkObjectResult>(controllerResult.Result);

			var resultValue = (controllerResult.Result as OkObjectResult).Value as List<CursoParaUsuarioResponse>;

			Assert.Equal(entity, resultValue);
		}
	}
}
