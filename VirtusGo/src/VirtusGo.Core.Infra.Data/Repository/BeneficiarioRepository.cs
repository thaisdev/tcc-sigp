using System.Collections.Generic;
using System.Linq;
using Dapper;
using Microsoft.EntityFrameworkCore;
using VirtusGo.Core.Domain.Beneficiarios;
using VirtusGo.Core.Domain.Beneficiarios.Repository;
using VirtusGo.Core.Domain.Enums;
using VirtusGo.Core.Infra.Data.Context;

namespace VirtusGo.Core.Infra.Data.Repository
{
    public class BeneficiarioRepository : Repository<Beneficiario>, IBeneficiarioRepository
    {
        public BeneficiarioRepository(VirtusContext context) : base(context)
        {

        }

        //TODO: DAPPER
        //public override IEnumerable<Beneficiario> ObterTodos()
        //{
        //    var sql = "SELECT * FROM beneficiarios B" +
        //              "WHERE B.FlgExcluido = 0" +
        //              "ORDER BY B.NumChave DESC";
        //    return Db.Database.GetDbConnection().Query<Beneficiario>(sql);
        //}

        public Beneficiario ObterPorCpf(string cpf)
        {
            return Buscar(x => x.NumeroDocumento == cpf).FirstOrDefault();
        }

        public Beneficiario ObterPorBeneficiarioId(int id)
        {
            return Buscar(x => x.Id == id).FirstOrDefault();
        }

        public Beneficiario ObterPorEmail(string email)
        {
            return Buscar(x => x.Email == email).FirstOrDefault();
        }

        public List<Beneficiario> ObterTodosInativos()
        {
            return Db.Beneficiarios.Where(x => x.Excluido == FlagExcluidoEnum.sim).ToList();
        }

        public List<Beneficiario> ObterTodosQueriable()
        {
            return Db.Beneficiarios.ToList();
        }

        public IEnumerable<Beneficiario> ObterTodosAtivosSelect()
        {
            //var usuarios = Db.EmpresasUsuarios.Where(x => x.EmpresaId == 25).Select(p => p.UsuarioId).ToArray();
            //return Db.Beneficiarios.Where(x => x.Excluido != FlagExcluidoEnum.sim && usuarios.Contains(x.UsuarioCriacaoId)).ToList();
            return null;
        }

        public List<Beneficiario> ObterTodosAtivos()
        {
            return Db.Beneficiarios.Where(x => x.Excluido != FlagExcluidoEnum.sim).ToList();
        }
    }
}