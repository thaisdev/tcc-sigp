using System.Collections.Generic;
using System.Linq;
using VirtusGo.Core.Domain.CotacaoPontos;
using VirtusGo.Core.Domain.CotacaoPontos.Repository;
using VirtusGo.Core.Domain.Enums;
using VirtusGo.Core.Infra.Data.Context;

namespace VirtusGo.Core.Infra.Data.Repository
{
    public class CotacaoPontosRepository : Repository<CotacaoPontos>, ICotacaoPontosRepository
    {
        public CotacaoPontosRepository(VirtusContext context) : base(context)
        {
        }

        public CotacaoPontos ObterPorCotacaoId(int id)
        {
            return Db.Cotacao.FirstOrDefault(c => c.Id == id);
        }

        public List<CotacaoPontos> ObterTodosQueriable()
        {
            return Db.Cotacao.Where(x=>x.FlagExcluido != FlagExcluidoEnum.sim).ToList();
        }
    }
}