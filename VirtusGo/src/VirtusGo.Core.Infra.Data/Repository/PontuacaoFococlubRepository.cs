using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using VirtusGo.Core.Domain.PontuacaoFococlub;
using VirtusGo.Core.Domain.PontuacaoFococlub.Repository;
using VirtusGo.Core.Infra.Data.Context;

namespace VirtusGo.Core.Infra.Data.Repository
{
    public class PontuacaoFococlubRepository : IPontuacaoFococlubRepository
    {

        private readonly FococlubContext _context;

        public PontuacaoFococlubRepository(FococlubContext context)
        {
            _context = context;
        }
        
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Adicionar(PontuacaoFocoClub obj)
        {
            _context.PontuacaoFocoClub.Add(obj);
            _context.SaveChanges();
        }

        public PontuacaoFocoClub ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PontuacaoFocoClub> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Atualizar(PontuacaoFocoClub obj)
        {
            throw new NotImplementedException();
        }

        public void Remover(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PontuacaoFocoClub> Buscar(Expression<Func<PontuacaoFocoClub, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public List<PontuacaoFocoClub> Obtertodos()
        {
            return _context.PontuacaoFocoClub.ToList();
        }
    }
}