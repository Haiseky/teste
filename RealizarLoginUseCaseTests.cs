using Aplicação.Casos_de_Uso;
using Aplicação.DTOs;
using Aplicação.RespostaPadrao;
using Dominio.Entidades;
using Dominio.Interface_Repositorios;
using Moq;
using Xunit;

namespace TestesAplicacao
{
    public class RealizarLoginUseCaseTests
    {
        [Fact]
        public void DeveRetornarErro_QuandoUsuarioNaoExiste()
        {
            var mockRepo = new Mock<IUsuarioRepositorio>();
            mockRepo.Setup(r => r.NomeUsuarioExiste("inexistente")).Returns(false);

            var useCase = new RealizarLoginUseCase(mockRepo.Object);
            var loginDto = new LoginDTO { Usuario = "inexistente", Senha = "123" };

            var resposta = useCase.Executar(loginDto);

            Assert.False(resposta.Sucesso);
            Assert.Equal("Usuário incorreto!", resposta.Mensagem);
            Assert.Null(resposta.Dados);
        }

        [Fact]
        public void DeveRetornarErro_QuandoSenhaIncorreta()
        {
            var mockRepo = new Mock<IUsuarioRepositorio>();
            var usuario = new Mock<Usuario>("admin", "senhaCorreta");
            usuario.Setup(u => u.VerificarSenha("senhaErrada")).Returns(false);

            mockRepo.Setup(r => r.NomeUsuarioExiste("admin")).Returns(true);
            mockRepo.Setup(r => r.RecuperarPorNome("admin")).Returns(usuario.Object);

            var useCase = new RealizarLoginUseCase(mockRepo.Object);
            var loginDto = new LoginDTO { Usuario = "admin", Senha = "senhaErrada" };

            var resposta = useCase.Executar(loginDto);

            Assert.False(resposta.Sucesso);
            Assert.Equal("Senha incorreta!", resposta.Mensagem);
            Assert.Null(resposta.Dados);
        }

        [Fact]
        public void DeveRetornarSucesso_QuandoLoginCorreto()
        {
            var mockRepo = new Mock<IUsuarioRepositorio>();
            var usuario = new Usuario("admin", "senhaCorreta");
            var usuarioMock = new Mock<Usuario>("admin", "senhaCorreta");
            usuarioMock.Setup(u => u.VerificarSenha("senhaCorreta")).Returns(true);

            mockRepo.Setup(r => r.NomeUsuarioExiste("admin")).Returns(true);
            mockRepo.Setup(r => r.RecuperarPorNome("admin")).Returns(usuarioMock.Object);

            var useCase = new RealizarLoginUseCase(mockRepo.Object);
            var loginDto = new LoginDTO { Usuario = "admin", Senha = "senhaCorreta" };

            var resposta = useCase.Executar(loginDto);

            Assert.True(resposta.Sucesso);
            Assert.Equal("Login", resposta.Mensagem);
            Assert.NotNull(resposta.Dados);
            Assert.Equal("admin", resposta.Dados.Nome);
        }
    }
}