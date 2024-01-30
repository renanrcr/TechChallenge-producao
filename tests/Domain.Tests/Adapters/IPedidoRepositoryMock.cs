using Domain.Adapters;
using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Infrastructure.Tests.Context;

namespace Infrastructure.Tests.Adapters
{
    public class IPedidoRepositoryMock
    {
        public static IPedidoRepository GetMock()
        {
            List<Pedido> pedidos = GenerateTestDataAsync();
            DataBaseContext dbContextMock = DbContextMock.GetMock<Pedido, DataBaseContext>(pedidos, x => x.Pedidos);
            return new PedidoRepository(dbContextMock);
        }

        private static List<Pedido> GenerateTestDataAsync()
        {
            List<Pedido> pedidos = new();
            for (int index = 1; index <= 10; index++)
            {
                var pedidoMock = new Pedido();

                pedidos.Add(pedidoMock);
            }
            return pedidos;
        }
    }
}
