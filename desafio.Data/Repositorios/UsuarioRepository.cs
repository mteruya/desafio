using desafio.Data.Interfaces;
using desafio.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace desafio.Data.Repositorios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DesafioContext _dbContext;

        public UsuarioRepository(DesafioContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Usuario Add(Usuario dados)
        {
            _dbContext.Set<Usuario>().Add(dados);
            _dbContext.SaveChanges();
            return dados;
        }

        public void Edit(Usuario dados)
        {
            _dbContext.Entry(dados).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public Usuario Get(int Id)
        {
            return _dbContext.Set<Usuario>().Find(Id);
        }

        public IEnumerable<Usuario> Listar()
        {
            throw new NotImplementedException();
        }

        public Usuario Login(String login, String senha)
        {
            return _dbContext.Usuarios.Where(p => p.Login.Equals(login) && p.Senha.Equals(senha)).First<Usuario>();
        }

    }
}
