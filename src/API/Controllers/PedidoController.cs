using API.Controllers.Base;
using Domain.Adapters;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PedidoController : BaseController
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoController(INotificador notificador,
            IPedidoRepository pedidoRepository)
            : base(notificador)
        {
            _pedidoRepository = pedidoRepository;
        }

        [HttpGet("StatusPagamentoPedido")]
        public async Task<IActionResult?> GetStatusPagamentoPedido(string? numeroDoPedido)
        {
            if (!ModelState.IsValid) return null;

            var status = (await _pedidoRepository.Buscar(x => x.NumeroPedido == numeroDoPedido)).FirstOrDefault()?.StatusPedido.ToString();

            return Ok(new { StatusDoPagamento = status });
        }

        [HttpPost("AtualizaStatusPedido")]
        public async Task<IActionResult?> PostStatusPedido(string? numeroDoPedido, int idStatusPedido)
        {
            if (!ModelState.IsValid) return null;

            var pedido = (await _pedidoRepository.Buscar(x => x.NumeroPedido == numeroDoPedido)).FirstOrDefault();

            if (pedido == null) return BadRequest("Pedido não enconntrado.");

            pedido.StatusPedido = (EStatusPedido)idStatusPedido;

            var status = _pedidoRepository.Atualizar(pedido);

            return Ok(pedido);
        }
    }
}