using Domain.Adapters;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Infrastructure.Tests.Context;

namespace Infrastructure.Tests.Adapters
{
    public class IPedidoRepositoryMock
    {
        public static IPedidoRepository GetMock()
        {
            DataBaseContext dbContextMock = DbContextMock.CreateDbContext();
            return new PedidoRepository(dbContextMock);
        }
    }
}
