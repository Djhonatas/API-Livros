using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : DbContext
    {
        //construtor que faz conexão com o banco de dados
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        }
        //abaixo, tenho as duas tabelas que tem na minha base

        public DbSet<AutorModel> Autor { get; set; }
        public DbSet<LivroModel> Livros { get; set; }
    }
}
