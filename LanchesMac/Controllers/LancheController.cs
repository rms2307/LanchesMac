using LanchesMac.Models;
using LanchesMac.Repositories;
using LanchesMac.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LanchesMac.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILancheRepository _lancheRepository;
        private ICategoriaRepository _categoriaRepository;

        public LancheController(ILancheRepository lancheRepository,
            ICategoriaRepository categoriaRepository)
        {
            _lancheRepository = lancheRepository;
            _categoriaRepository = categoriaRepository;
        }

        public IActionResult List(string categoria)
        {
            IEnumerable<Lanche> lanches = new List<Lanche>();
            string categoriaAtual;

            if (string.IsNullOrEmpty(categoria))
            {
                lanches = _lancheRepository.ListarLanches();
                categoriaAtual = "Todos os Lanches";
            }
            else
            {
                switch (categoria)
                {
                    case "Normal":
                        lanches = _lancheRepository.ListarLanches(categoria);
                        break;
                    case "Natural":
                        lanches = _lancheRepository.ListarLanches(categoria);
                        break;
                    default:
                        break;
                }

                categoriaAtual = categoria;
            }

            var lancheListViewModel = new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual
            };
            return View(lancheListViewModel);
        }

        public IActionResult Details(int lancheId)
        {
            var lanche = _lancheRepository.GetLancheById(lancheId);
            if (lanche == null) return View("~/Views/Error/Error.cshtml");

            return View(lanche);
        }

        public IActionResult Search(string searchString)
        {
            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(searchString))
            {
                lanches = _lancheRepository.ListarLanches();
            }
            else
            {
                lanches = _lancheRepository.ListarLanches()
                    .Where(l => l.Nome.ToLower().Contains(searchString));
            }

            return View("~/Views/Lanche/List.cshtml", new LancheListViewModel { Lanches = lanches, CategoriaAtual = "Todos os Lanches" });
        }
    }
}
