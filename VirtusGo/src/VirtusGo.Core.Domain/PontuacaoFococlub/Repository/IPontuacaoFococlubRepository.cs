using System.Collections.Generic;
using VirtusGo.Core.Domain.Interfaces;

namespace VirtusGo.Core.Domain.PontuacaoFococlub.Repository
{
    public interface IPontuacaoFococlubRepository : IRepository<PontuacaoFocoClub>
    {
        List<PontuacaoFocoClub> Obtertodos();
    }
}