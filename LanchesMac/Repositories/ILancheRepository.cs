using LanchesMac.Models;
using System.Collections.Generic;

namespace LanchesMac.Repositories
{
    public interface ILancheRepository
    {
        IEnumerable<Lanche> ListarLanches();
        IEnumerable<Lanche> ListarLanchesPreferidos();
        Lanche GetLancheById(int lancheId);
    }
}
