using Domain.Adapters;
using Domain.Entities;
using Infrastructure.Tests.Adapters;

namespace Infrastructure.Tests.Repositories
{
    public class PedidoRepositoryTest
    {
        private IPedidoRepository _pedidoRepository;

        public PedidoRepositoryTest()
        {
            _pedidoRepository = IPedidoRepositoryMock.GetMock();
        }

        [Fact]
        public async Task Pedido_DeveRetornarVerdadeiro_QuandoAtualizarPedido()
        {
            //Arrange
            Guid id = (_pedidoRepository.ObterTodos().Result.FirstOrDefault() ?? new()).Id;
            Pedido pedidoCadastrado = await _pedidoRepository.ObterPorId(id) ?? new();
            pedidoCadastrado.StatusPedido = Domain.Enums.EStatusPedido.RECEBIDO;

            //Act
            await _pedidoRepository.Atualizar(pedidoCadastrado);
            Pedido? pedidoAtualizado = await _pedidoRepository.ObterPorId(pedidoCadastrado.Id) ?? new();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(pedidoAtualizado);
                Assert.Equal(Domain.Enums.EStatusPedido.RECEBIDO, pedidoAtualizado.StatusPedido);
            });
        }
    }
}