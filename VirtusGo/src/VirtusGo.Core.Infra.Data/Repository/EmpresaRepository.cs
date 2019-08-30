using System;
using System.Collections.Generic;
using System.Linq;
using VirtusGo.Core.Domain.Empresa;
using VirtusGo.Core.Domain.Empresa.Repository;
using VirtusGo.Core.Domain.Enums;
using VirtusGo.Core.Infra.Data.Context;

namespace VirtusGo.Core.Infra.Data.Repository
{
    public class EmpresaRepository : Repository<Empresas>, IEmpresaRepository
    {
        public EmpresaRepository(VirtusContext context) : base(context)
        {

        }

        public Empresas ObterPorEmpresaId(int id)
        {
            return Buscar(x => x.Id == id).FirstOrDefault();

            //var cn = Db.Database.Connection;

            //const string sql = @"SELECT * FROM empresas WHERE DesCnpj = @cnpj";

            //return cn.Query<Empresa>(sql, new { cnpj = cnpj }).FirstOrDefault();
        }

        public Empresas ObterPorCnpj(string cnpj)
        {
            return Buscar(x => x.NumeroDocumento == cnpj).FirstOrDefault();

            //var cn = Db.Database.Connection;

            //const string sql = @"SELECT * FROM empresas WHERE DesCnpj = @cnpj";

            //return cn.Query<Empresa>(sql, new { cnpj = cnpj }).FirstOrDefault();
        }

        public Empresas ObterPorRazaoSocial(string razao)
        {
            return Buscar(x => x.RazaoSocial == razao).FirstOrDefault();
        }

        public Empresas ObterPorGuid(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Empresas ObterPorEmail(string email)
        {
            return Buscar(x => x.Email == email).FirstOrDefault();
        }

        public List<Empresas> ObterTodosQueriable()
        {
            return Db.Empresas.ToList();

            //var cn = Db.Database.Connection;
            //const string sql = @"SELECT * FROM empresas";

            //return cn.Query<Empresa>(sql).ToList();
        }

        public List<Empresas> ObterTodosAtivos()
        {
            return Db.Empresas.Where(x => x.Excluido != FlagExcluidoEnum.sim && x.Bloqueado != FlagBloqueadoEnum.sim)
                .ToList();
        }

        public List<Empresas> ObterTodosInativos()
        {
            return Db.Empresas.Where(x => x.Excluido == FlagExcluidoEnum.sim)
                .ToList();
        }
    }
}
