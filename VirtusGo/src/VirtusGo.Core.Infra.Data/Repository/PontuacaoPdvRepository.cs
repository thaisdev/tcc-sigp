using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using VirtusGo.Core.Domain.Enums;
using VirtusGo.Core.Domain.PontuacaoPdv;
using VirtusGo.Core.Domain.PontuacaoPdv.Repository;
using VirtusGo.Core.Infra.Data.Context;

namespace VirtusGo.Core.Infra.Data.Repository
{
    public class PontuacaoPdvRepository : Repository<PontuacaoPDV>, IPontuacaoPDVRepository
    {
        public PontuacaoPdvRepository(VirtusContext context) : base(context)
        {
        }

        public PontuacaoPDV ObterPorGuid(Guid guid)
        {
            throw new NotImplementedException();
        }

        public PontuacaoPDV ObterPorPontuacaoPDVId(int id)
        {
            return Buscar(x => x.Id == id).FirstOrDefault();
        }

        public List<PontuacaoPDV> ObterTodosQueriable()
        {
            return Db.Pdv.Include(x=>x.Unidade).ToList();
        }

        public List<PontuacaoPDV> ObterTodosAtivos()
        {
            return Db.Pdv.AsNoTracking().Include(x=>x.Unidade).Where(x => x.FlagExcluido != FlagExcluidoEnum.sim & x.FlagInterface != "1").ToList();
        }

        public List<PontuacaoPDV> ObterTodosAtivosPorUnidadeId(int id)
        {
            return Db.Pdv.AsNoTracking().Include(x=>x.Unidade)
                .Where(x => x.UnidadeId == id && x.FlagExcluido != FlagExcluidoEnum.sim & x.FlagInterface != "1")
                .ToList();
        }
    }
}