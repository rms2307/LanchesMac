﻿using LanchesMac.Models;
using LanchesMac.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        private readonly ILancheRepository _lancheRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraController(ILancheRepository lancheRepository,
                                        CarrinhoCompra carrinhoCompra)
        {
            _lancheRepository = lancheRepository;
            _carrinhoCompra = carrinhoCompra;
        }
        public IActionResult Index()
        {
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItens = itens;

            var carrinhoCompraViewModel = new ViewModels.CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
            };

            return View(carrinhoCompraViewModel);
        }

        public RedirectToActionResult AdicionarItemCarrinhoCompra(int lancheId)
        {
            var lanche = _lancheRepository.GetLancheById(lancheId);

            if (lanche != null)
            {
                _carrinhoCompra.AdicionarAoCarrinho(lanche);
            }

            return RedirectToAction(nameof(Index));
        }

        public RedirectToActionResult RemoverItemCarrinhoCompra(int lancheId)
        {
            var lanche = _lancheRepository.GetLancheById(lancheId);
            if (lanche != null)
            {
                _carrinhoCompra.RemoverDoCarrinho(lanche);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
