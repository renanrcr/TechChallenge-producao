using Infrastructure.Context;
using Domain.Entities;
using Domain.Adapters;

namespace Infrastructure.Repositories
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(DataBaseContext dataBaseContext)
            : base(dataBaseContext)
        {
        }
    }
}