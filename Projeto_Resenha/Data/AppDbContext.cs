using Microsoft.EntityFrameworkCore;
using Projeto_Resenha.Dominio1;
using ProjetoResenha.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ProjetoResenha.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Resenha> Resenhas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("usuarios");
            modelBuilder.Entity<Autor>().ToTable("autores");
            modelBuilder.Entity<Livro>().ToTable("livros");
            modelBuilder.Entity<Resenha>().ToTable("resenhas");
        }
    }
}
