using API.Controllers;
using Domain.Adapters;
using Domain.Enums;
using Infrastructure.Tests.Adapters;
using Moq;

namespace API.Tests.Controllers
{
    public class PedidoControllerTests
    {
        private readonly Mock<INotificador> _notification;
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoControllerTests()
        {
            _notification = new Mock<INotificador>();
            _pedidoRepository = IPedidoRepositoryMock.GetMock();
        }

        [Fact]
        public void Pedido_DeveRetornarVerdadeiro_StatusDoPedido()
        {
            //Arrange
            var controllerPedido = new PedidoController(_notification.Object, _pedidoRepository);
            string? numeroPedido = (_pedidoRepository.ObterTodos().Result.FirstOrDefault() ?? new()).NumeroPedido;

            //Act
            var result = controllerPedido.GetStatusPagamentoPedido(numeroPedido).Result;

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Pedido_DeveRetornarVerdadeiro_QuandoAtualizarStatusDoPedido()
        {
            //Arrange
            var controllerPedido = new PedidoController(_notification.Object, _pedidoRepository);
            string? numeroPedido = (_pedidoRepository.ObterTodos().Result.FirstOrDefault() ?? new()).NumeroPedido;

            //Act
            var result = controllerPedido.PostStatusPedido(numeroPedido, (int)EStatusPedido.EM_PREPARACAO).Result;

            //Assert
            Assert.NotNull(result);
        }
    }
}
