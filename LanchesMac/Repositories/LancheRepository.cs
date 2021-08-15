using LanchesMac.Context;
using LanchesMac.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LanchesMac.Repositories
{
    public class LancheRepository : ILancheRepository
    {
        private readonly AppDBContext _context;
        public LancheRepository(AppDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Lanche> ListarLanches()
        {
            return _context.Lanches.Include(c => c.Categoria)
                    .OrderBy(l => l.LancheId)
                    .ToList();
        }

        public IEnumerable<Lanche> ListarLanches(string categoria)
        {
            return _context.Lanches.Include(c => c.Categoria)
                    .Where(l => l.Categoria.CategoriaNome.Equals(categoria))
                    .OrderBy(l => l.Nome)
                    .ToList();
        }

        public IEnumerable<Lanche> ListarLanchesPreferidos()
        {
            return _context.Lanches.Include(c => c.Categoria)
                    .Where(l => l.IsLanchePreferido == true)
                    .ToList();
        }

        public Lanche GetLancheById(int lancheId)
        {
            return _context.Lanches.FirstOrDefault(l => l.LancheId == lancheId);
        }
    }
}
