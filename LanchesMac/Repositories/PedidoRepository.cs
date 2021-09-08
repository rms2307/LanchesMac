using LanchesMac.Context;
using LanchesMac.Models;
using System;

namespace LanchesMac.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDBContext _appDbContext;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoRepository(AppDBContext appDbContext,
                                CarrinhoCompra carrinhoCompra)
        {
            _appDbContext = appDbContext;
            _carrinhoCompra = carrinhoCompra;
        }
        public void CriarPedido(Pedido pedido)
        {
            pedido.PedidoEnviado = DateTime.Now;
            _appDbContext.Pedidos.Add(pedido);
            _appDbContext.SaveChanges();

            var carrinhoCompraItens = _appDbContext.CarrinhoCompraItens;

            foreach (var item in carrinhoCompraItens)
            {
                var pedidosDetalhe = new PedidoDetalhe()
                {
                    Quantidade = item.Quantidade,
                    LancheId = item.Lanche.LancheId,
                    PedidoId = pedido.PedidoId,
                    Preco = item.Lanche.Preco
                };
                _appDbContext.PedidoDetalhes.Add(pedidosDetalhe);
            }
            _appDbContext.SaveChanges();
        }
    }
}
