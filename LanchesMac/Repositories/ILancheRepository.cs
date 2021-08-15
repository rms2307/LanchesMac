using LanchesMac.Models;
using System.Collections.Generic;

namespace LanchesMac.Repositories
{
    public interface ILancheRepository
    {
        IEnumerable<Lanche> ListarLanches();
        IEnumerable<Lanche> ListarLanches(string categoria);
        IEnumerable<Lanche> ListarLanchesPreferidos();
        Lanche GetLancheById(int lancheId);
    }
}
