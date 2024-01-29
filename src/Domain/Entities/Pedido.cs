using Domain.Enums;

namespace Domain.Entities
{
    public class Pedido : EntidadeBase<Guid>
    {
        public Guid IdentificacaoPedidoId { get; private set; }
        public string? NumeroPedido { get; private set; }
        public EStatusPedido StatusPedido { get; set; }
        public EStatusPagamentoPedido StatusPagamentoPedido { get; set; }
    }
}