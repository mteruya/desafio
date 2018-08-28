using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore; 

namespace desafio.Data
{
    public class DesafioContext : DbContext
    {
        public DesafioContext(DbContextOptions<DesafioContext> options) : base(options)
        {
        }

        public virtual DbSet<Models.Usuario> Usuarios { get; set; }
        public virtual DbSet<Models.Cartao> Cartoes { get; set; }
        public virtual DbSet<Models.LoteArquivo> LoteArquivos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Models.Usuario>().ToTable("usuarios");
            modelBuilder.Entity<Models.Cartao>().ToTable("cartoes");
            modelBuilder.Entity<Models.LoteArquivo>().ToTable("lotearquivos");
            var usuario = new Models.Usuario() { Id=1, Nome="teste", Login="teste", Senha="teste123"};
            modelBuilder.Entity<Models.Usuario>().HasData(usuario);
            var cartao = new Models.Cartao() { Id=1, NumCartao="123457890123", UsuarioId=1};
            modelBuilder.Entity<Models.Cartao>().HasData(cartao);

        }
    }
}

