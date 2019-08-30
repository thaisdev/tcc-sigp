using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using VirtusGo.Core.Domain.Enums;
using VirtusGo.Core.Domain.Faixas;
using VirtusGo.Core.Domain.Faixas.Repository;
using VirtusGo.Core.Infra.Data.Context;

namespace VirtusGo.Core.Infra.Data.Repository
{
    public class FaixaRepository : Repository<Faixa>, IFaixaRepository
    {
        public FaixaRepository(VirtusContext context) : base(context)
        {
        }

        public List<Faixa> ObterTodosQueriable()
        {
            return Db.Faixas.ToList();
        }

        public IEnumerable<Faixa> ObterTodosAtivos()
        {
            //var cn = Db.Database.Connection;

            //var sql = @"SELECT * FROM faixas";

            //return cn.Query<Faixa>(sql);

            return Db.Faixas.Include(x => x.Empresa).Include(x => x.Unidades)
                .Where(x => x.FlagExcluido != FlagExcluidoEnum.sim);
        }

        public Faixa ObterPorFaixaId(int id)
        {
            return Buscar(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Faixa> ObterTodosAtivosPorEmpresaId(int id)
        {
            return Db.Faixas.Include(x => x.Empresa).Include(x => x.Unidades)
                .Where(x => x.FlagExcluido != FlagExcluidoEnum.sim && x.EmpresaId == id);
        }
    }
}