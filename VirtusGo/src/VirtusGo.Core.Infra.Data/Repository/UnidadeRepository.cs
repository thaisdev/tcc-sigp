using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using VirtusGo.Core.Domain.Enums;
using VirtusGo.Core.Domain.Unidades;
using VirtusGo.Core.Domain.Unidades.Repository;
using VirtusGo.Core.Infra.Data.Context;

namespace VirtusGo.Core.Infra.Data.Repository
{
    public class UnidadeRepository : Repository<Unidade>, IUnidadeRepository
    {
        public UnidadeRepository(VirtusContext context) : base(context)
        {
        }

        public Unidade ObterPorCnpj(string cnpj)
        {
            return Buscar(x => x.Documento == cnpj).FirstOrDefault();
        }

        public Unidade ObterPorFantasia(string fantasia)
        {
            return Buscar(x => x.Fantasia == fantasia).FirstOrDefault();
        }

        public Unidade ObterPorUnidadeId(int id)
        {
//            return Buscar(x => x.Id == id).FirstOrDefault();
            return Db.Unidades.AsNoTracking().Include("Empresa").FirstOrDefault(x => x.Id == id);
        }

        public Unidade ObterPorEmail(string email)
        {
            return Buscar(x => x.Email == email).FirstOrDefault();
        }

        public List<Unidade> ObterTodosQueryiable()
        {
            return Db.Unidades.ToList();
        }

        public List<Unidade> ObterTodosAtivos()
        {
            return Db.Unidades.Include(x=>x.Empresa).Where(x => x.FlagExcluido != FlagExcluidoEnum.sim && x.FlagBloqueado != FlagBloqueadoEnum.sim)
                .ToList();
        }

        public List<Unidade> ObterTodosInativos()
        {
            return Db.Unidades
                .Where(x => x.FlagBloqueado != FlagBloqueadoEnum.nao && x.FlagExcluido != FlagExcluidoEnum.nao)
                .ToList();
        }

        public List<Unidade> ObterTodosAtivosPorEmpresa(int id)
        {
            return Db.Unidades.Include(x=>x.Empresa).Where(x => x.EmpresaId == id && x.FlagExcluido != FlagExcluidoEnum.sim && x.FlagBloqueado != FlagBloqueadoEnum.sim).ToList();
        }

        public List<Unidade> ObterTodosInativosPorEmpresa(int empresaId)
        {
            return Db.Unidades
                .Where(x => x.FlagBloqueado != FlagBloqueadoEnum.nao && x.FlagExcluido != FlagExcluidoEnum.nao && x.EmpresaId == empresaId)
                .ToList();
        }
    }
}