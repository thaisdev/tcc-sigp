using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using VirtusGo.Core.Domain.Enums;
using VirtusGo.Core.Domain.Pontuacao;
using VirtusGo.Core.Domain.Pontuacao.Repository;
using VirtusGo.Core.Infra.Data.Context;

namespace VirtusGo.Core.Infra.Data.Repository
{
    public class PontuacaoRepository : Repository<Pontuacao>, IPontuacaoRepository
    {
        public PontuacaoRepository(VirtusContext context) : base(context)
        {
        }

        public IEnumerable<Pontuacao> ObterTodosAtivos()
        {
            return Db.Pontuacao.Include(x => x.Beneficiarios).Include(x=>x.Unidade).Include(x=>x.Empresa).Where(x => x.FlagExcluido != FlagExcluidoEnum.sim && x.FlagInterface != "1");
        }

        public List<Pontuacao> ObterTodosInativos()
        {
            return Db.Pontuacao.Where(x => x.FlagExcluido == FlagExcluidoEnum.sim).ToList();
        }

        public List<Pontuacao> ObterTodosAtivosPorBeneficiarioId(int id)
        {
            return Db.Pontuacao.Where(x => x.BeneficiarioId == id).ToList();
        }
        public List<Pontuacao> ObterTodosAtivosPorEmpresaId(int id)
        {
            return Db.Pontuacao.Where(x => x.EmpresaId == id).ToList();
        }

        public Pontuacao ObterDadosPorId(int id)
        {
            return Db.Pontuacao.AsNoTracking().Include(x=>x.Beneficiarios).Include(x=>x.Unidade).Include(x => x.Empresa).FirstOrDefault(x => x.FlagExcluido != FlagExcluidoEnum.sim && x.FlagInterface != "1" && x.Id == id);
        }
    }
}