﻿using AutoFixture;
using AutoMapper;
using FluentAssertions;
using NSubstitute;
using OA_Core.Domain.Contracts.Request;
using OA_Core.Domain.Contracts.Response;
using OA_Core.Domain.Entities;
using OA_Core.Domain.Exceptions;
using OA_Core.Domain.Interfaces.Notifications;
using OA_Core.Domain.Interfaces.Repository;
using OA_Core.Service;
using OA_Core.Tests.Config;

namespace OA_Core.Tests.Service
{
	[Trait("Service", "Avaliacao Service")]
	public class AvaliacaoServiceTest
	{
		private readonly IMapper _mapper;
		private readonly Fixture _fixture;
		private readonly INotificador _notifier;

		public AvaliacaoServiceTest()
		{
			_fixture = FixtureConfig.GetFixture();
			_mapper = MapperConfig.Get();
			_notifier = Substitute.For<INotificador>();
		}
		[Fact(DisplayName = "Cria uma Avaliacao válida")]
		public async Task AvaliacaoService_CriaAvaliacao_DeveCriar()
		{
			//Arrange
			var mockAvaliacaoRepository = Substitute.For<IAvaliacaoRepository>();
			var MockUsuarioRepository = Substitute.For<IUsuarioRepository>();
			var MockAvaliacaoUsuarioRepository = Substitute.For<IAvaliacaoUsuarioRepository>();
			var avaliacaoService = new AvaliacaoService(mockAvaliacaoRepository, MockUsuarioRepository, _notifier, _mapper, MockAvaliacaoUsuarioRepository);
			var avaliacao = _fixture.Create<Avaliacao>();
			var avaliacaoRequest = _fixture.Create<AvaliacaoRequest>();

			//Act
			mockAvaliacaoRepository.ObterPorIdAsync(Arg.Any<Guid>()).Returns(avaliacao);
			mockAvaliacaoRepository.AdicionarAsync(Arg.Any<Avaliacao>()).Returns(Task.CompletedTask);
			var result = await avaliacaoService.CadastrarAvaliacaoAsync(avaliacaoRequest);

			//Assert
			result.Should().NotBe(Guid.Empty);
		}

		[Fact(DisplayName = "Cria uma Avaliacao inválida")]
		public async Task AulaService_CriarAvaliacaoComNomeInvalido_DeveSerInvalido()
		{
			//Arrange
			var mockAvaliacaoRepository = Substitute.For<IAvaliacaoRepository>();
			var MockUsuarioRepository = Substitute.For<IUsuarioRepository>();
			var MockAvaliacaoUsuarioRepository = Substitute.For<IAvaliacaoUsuarioRepository>();
			var avaliacaoService = new AvaliacaoService(mockAvaliacaoRepository, MockUsuarioRepository, _notifier, _mapper, MockAvaliacaoUsuarioRepository);
			var avaliacaoRequest = _fixture.Create<AvaliacaoRequest>();
			avaliacaoRequest.Nome = "";

			//Act
			//Assert
			await Assert.ThrowsAsync<InformacaoException>(() => avaliacaoService.CadastrarAvaliacaoAsync(avaliacaoRequest));
		}

		[Fact(DisplayName = "Atualiza uma Avaliacao")]
		public async Task AvaliacaoService_AtualizarAvaliacao_DeveAtualizar()
		{
			//Arrange
			var mockAvaliacaoRepository = Substitute.For<IAvaliacaoRepository>(); ;
			var MockUsuarioRepository = Substitute.For<IUsuarioRepository>();
			var MockAvaliacaoUsuarioRepository = Substitute.For<IAvaliacaoUsuarioRepository>();
			var avaliacaoService = new AvaliacaoService(mockAvaliacaoRepository, MockUsuarioRepository, _notifier, _mapper, MockAvaliacaoUsuarioRepository);
			var avaliacaoRequest = _fixture.Create<AvaliacaoRequest>();
			var avaliacao = _fixture.Create<Avaliacao>();

			//Act
			mockAvaliacaoRepository.ObterPorIdAsync(Arg.Any<Guid>()).Returns(avaliacao);
			await avaliacaoService.EditarAvaliacaoAsync(avaliacao.Id, avaliacaoRequest);

			//Assert
			await mockAvaliacaoRepository.Received().EditarAsync(Arg.Is<Avaliacao>(c => c.NotaMaxima == avaliacaoRequest.NotaMaxima));
		}

		[Fact(DisplayName = "Atualiza uma AVALIACAO com Id inválido")]
		public async Task AvaliacaoService_AtualizarAvaliacaoComIdInvalido_DeveSerInvalido()
		{
			//Arrange
			var mockAvaliacaoRepository = Substitute.For<IAvaliacaoRepository>();
			var MockUsuarioRepository = Substitute.For<IUsuarioRepository>();
			var MockAvaliacaoUsuarioRepository = Substitute.For<IAvaliacaoUsuarioRepository>();
			var avaliacaoService = new AvaliacaoService(mockAvaliacaoRepository, MockUsuarioRepository, _notifier, _mapper, MockAvaliacaoUsuarioRepository);
			var avaliacaoRequest = _fixture.Create<AvaliacaoRequest>();


			//Act
			//Assert
			await Assert.ThrowsAsync<InformacaoException>(() => avaliacaoService.EditarAvaliacaoAsync(Guid.NewGuid(), avaliacaoRequest));
		}

		[Fact(DisplayName = "Obtém uma Avaliacao pelo Id")]
		public async Task AvaliacaoService_ObterAvaliacaoPorId_DeveObterUm()
		{
			//Arrange
			var mockAvaliacaoRepository = Substitute.For<IAvaliacaoRepository>();
			var MockUsuarioRepository = Substitute.For<IUsuarioRepository>();
			var MockAvaliacaoUsuarioRepository = Substitute.For<IAvaliacaoUsuarioRepository>();
			var avaliacaoService = new AvaliacaoService(mockAvaliacaoRepository, MockUsuarioRepository, _notifier, _mapper, MockAvaliacaoUsuarioRepository);
			var avaliacao = _fixture.Create<Avaliacao>();
			var avaliacaoResponse = _mapper.Map<AvaliacaoResponse>(avaliacao);

			//Act
			mockAvaliacaoRepository.ObterPorIdAsync(Arg.Any<Guid>()).Returns(avaliacao);
			var result = await avaliacaoService.ObterAvaliacaoPorIdAsync(avaliacao.Id);

			//Assert
			result.Should().BeEquivalentTo(avaliacaoResponse);
		}

		[Fact(DisplayName = "Tenta obter uma Avaliacao com Id inválido")]
		public async Task AvaliacaoService_ObterAvaliacaoPorIdInvalido_DeveSerInvalido()
		{
			//Arrange
			var mockAvaliacaoRepository = Substitute.For<IAvaliacaoRepository>();
			var MockUsuarioRepository = Substitute.For<IUsuarioRepository>();
			var MockAvaliacaoUsuarioRepository = Substitute.For<IAvaliacaoUsuarioRepository>();
			var avaliacaoService = new AvaliacaoService(mockAvaliacaoRepository, MockUsuarioRepository, _notifier, _mapper, MockAvaliacaoUsuarioRepository);

			//Act
			//Assert
			await Assert.ThrowsAsync<InformacaoException>(() => avaliacaoService.ObterAvaliacaoPorIdAsync(Guid.NewGuid()));
		}

		[Fact(DisplayName = "Deleta uma Avaliacao Válida")]
		public async Task AulaService_DeletaAula_DeveDeletar()
		{
			//Arrange
			var mockAvaliacaoRepository = Substitute.For<IAvaliacaoRepository>();
			var MockUsuarioRepository = Substitute.For<IUsuarioRepository>();
			var MockAvaliacaoUsuarioRepository = Substitute.For<IAvaliacaoUsuarioRepository>();
			var avaliacaoService = new AvaliacaoService(mockAvaliacaoRepository, MockUsuarioRepository, _notifier, _mapper, MockAvaliacaoUsuarioRepository);
			var avaliacao = _fixture.Create<Avaliacao>();

			//Act
			mockAvaliacaoRepository.ObterPorIdAsync(Arg.Any<Guid>()).Returns(avaliacao);
			await avaliacaoService.DeletarAvaliacaoAsync(avaliacao.Id);

			//Assert
			await mockAvaliacaoRepository.Received().RemoverAsync(avaliacao);
		}

		[Fact(DisplayName = "Tenta deletar uma Avaliacao com Id inválido")]
		public async Task AvaliacaoService_DeletarAvaliacaoComIdInvalido_DeveSerInvalido()
		{
			//Arrange
			var mockAvaliacaoRepository = Substitute.For<IAvaliacaoRepository>();
			var MockUsuarioRepository = Substitute.For<IUsuarioRepository>();
			var MockAvaliacaoUsuarioRepository = Substitute.For<IAvaliacaoUsuarioRepository>();
			var avaliacaoService = new AvaliacaoService(mockAvaliacaoRepository, MockUsuarioRepository, _notifier, _mapper, MockAvaliacaoUsuarioRepository);

			//Act
			//Assert
			await Assert.ThrowsAsync<InformacaoException>(() => avaliacaoService.DeletarAvaliacaoAsync(Guid.NewGuid()));
		}

		//[Fact(DisplayName = "Fazer softdelete em uma avaliação já existente")]
		//public async Task AvaliacaoService_DeletarAvaliacao_DeveFazerSoftDelete()
		//{
		//	//Arrange
		//	var mockAvaliacaoRepository = Substitute.For<IAvaliacaoRepository>();
		//	var MockUsuarioRepository = Substitute.For<IUsuarioRepository>();
		//	var MockAvaliacaoUsuarioRepository = Substitute.For<IAvaliacaoUsuarioRepository>();
		//	var avaliacaoService = new AvaliacaoService(mockAvaliacaoRepository, MockUsuarioRepository, _notifier, _mapper, MockAvaliacaoUsuarioRepository);
		//	var avaliacao = _fixture.Create<Avaliacao>();

		//	//Act
		//	mockAvaliacaoRepository.ObterPorIdAsync(Arg.Any<Guid>()).Returns(avaliacao);
		//	await avaliacaoService.DeletarAvaliacaoAsync(avaliacao.Id);

		//	//Assert
		//	await mockAvaliacaoRepository.Received().EditarAsync(Arg.Is<Avaliacao>(c => c.DataDelecao != null));
		//}

		[Fact(DisplayName = "Obtém todas as Avaliacoes")]
		public async Task AvaliacaoService_ObterTodosAvaliacoes_DeveObter()
		{
			//Arrange
			var mockAvaliacaoRepository = Substitute.For<IAvaliacaoRepository>();
			var MockUsuarioRepository = Substitute.For<IUsuarioRepository>();
			var MockAvaliacaoUsuarioRepository = Substitute.For<IAvaliacaoUsuarioRepository>();
			var avaliacaoService = new AvaliacaoService(mockAvaliacaoRepository, MockUsuarioRepository, _notifier, _mapper, MockAvaliacaoUsuarioRepository);
			var avaliacoes = _fixture.CreateMany<Avaliacao>(5);

			//Act
			mockAvaliacaoRepository.ObterTodosAsync(Arg.Any<int>(), Arg.Any<int>()).Returns(avaliacoes);
			var result = await avaliacaoService.ObterTodasAvaliacoesAsync(1, 5);

			//Assert
			result.Should().HaveCount(5);
		}
	}
}
