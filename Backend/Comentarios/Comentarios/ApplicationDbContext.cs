using Comentarios.Models;
using Microsoft.EntityFrameworkCore;

namespace Comentarios
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Comentario> Comentario { get; set; }

        protected ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;Database=ABMComentario;Uid=root;Pwd=@dministrador");
            }
            //base.OnConfiguring(optionsBuilder);
        }
    }
}