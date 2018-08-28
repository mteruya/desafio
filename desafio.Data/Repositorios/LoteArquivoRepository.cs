using desafio.Data.Interfaces;
using desafio.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace desafio.Data.Repositorios
{
    public class LoteArquivoRepository : ILoteArquivoRepository

    {
        private readonly DesafioContext _dbContext;
        public LoteArquivoRepository(DesafioContext dbContext)
        {
            _dbContext = dbContext;
        }


        public LoteArquivo Add(LoteArquivo dados)
        {
            _dbContext.Set<LoteArquivo>().Add(dados);
            _dbContext.SaveChanges();
            return dados;
        }
        public int AdiconarLote(LoteArquivo dados)
        {
            LoteArquivo lote = new LoteArquivo()
            {
                Lote = dados.Lote,
                Nome = dados.Nome,
                TotalRegistros = dados.TotalRegistros,
                DataArquivo = dados.DataArquivo
            };

            _dbContext.Set<LoteArquivo>().Add(lote);
           _dbContext.SaveChanges();
            return lote.Id;

        }
        public void Edit(LoteArquivo dados)
        {
            _dbContext.Entry(dados).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public LoteArquivo Get(int Id)
        {
            return _dbContext.Set<LoteArquivo>().Find(Id);
        }

        public IEnumerable<LoteArquivo> Listar()
        {
            return _dbContext.Set<LoteArquivo>().ToList();
        }
    }
}
