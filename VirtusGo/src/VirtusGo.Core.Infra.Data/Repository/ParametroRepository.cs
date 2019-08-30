using System.Collections.Generic;
using System.Linq;
using VirtusGo.Core.Domain.Enums;
using VirtusGo.Core.Domain.Parametro;
using VirtusGo.Core.Domain.Parametro.Repository;
using VirtusGo.Core.Infra.Data.Context;

namespace VirtusGo.Core.Infra.Data.Repository
{
    public class ParametroRepository : Repository<Parametro>, IParametroRepository
    {
        public ParametroRepository(VirtusContext context) : base(context)
        {
        }

        public List<Parametro> ObterTodosQueriable()
        {
            return Db.Parametro.ToList();
        }

        public List<Parametro> ObterTodosAtivo()
        {
            return Buscar(x => x.FlagExcluido != FlagExcluidoEnum.sim).ToList();
        }

        public Parametro ObterParametroAtivo()
        {
            return Db.Parametro.LastOrDefault();
        }
    }
}