using Microsoft.EntityFrameworkCore;
using Productos.Models;

namespace Productos
{
    public class Contexto : DbContext
    {
        public Contexto()
        {
        }

        public Contexto(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Categoria> Categorias { get; set; }

        public virtual DbSet<Subcategoria> Subcategorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(categoria =>
            {
                categoria.HasData(Categoriasiniciales());
            });
            base.OnModelCreating(modelBuilder);
        }

        private static List<Categoria> Categoriasiniciales()
        {
            return new List<Categoria>
            { new Categoria{Id= 1, Categoria_nombre="Tecnología" }  };
        }
    }
}