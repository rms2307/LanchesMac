using LanchesMac.Context;
using LanchesMac.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
