using desafio.Data.Interfaces;
using desafio.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace desafio.Data.Repositorios
{
    public class CartaoRepository : ICartaoRepository
    {

        private readonly DesafioContext _dbContext;

        public CartaoRepository(DesafioContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Cartao Add(Cartao dados)
        {
            _dbContext.Set<Cartao>().Add(dados);
            _dbContext.SaveChanges();
            return dados;
        }

        public void Edit(Cartao dados)
        {
            _dbContext.Entry(dados).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public Cartao Get(int Id)
        {
            return _dbContext.Set<Cartao>().Find(Id);
        }

        public Cartao ObterporNumeroCartao(String numCartao)
        {
            return _dbContext.Cartoes.Where(p => p.NumCartao.Equals(numCartao)).FirstOrDefault<Cartao>();
        }
        public IEnumerable<Cartao> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
