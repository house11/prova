
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TagLib.Riff;

namespace Prodotti_grafica
{
    public partial class Conn : DbContext
    {
        public virtual DbSet<Products> TProducts { get; set; }
        public virtual DbSet<Description> TDescription { get; set; }
        //public virtual DbSet<FamilyBody> FamilyBodies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost; Database=Prodotti; User ID=sa; Password=sa;trusted_connection=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Products>(e =>
            {
                e.HasOne(p => p.Description)
                .WithOne(f => f.Products)
               // .HasForeignKey<List>()
                .HasForeignKey<Description>(p => p.IdProducts).GetType();
                
                e.Property(p => p.id);
            });

            modelBuilder.Entity<Description>(e =>
                {
                    e.HasOne(p => p.Products)
                    .WithOne(f => f.Description)
                    .HasForeignKey<Products>(p => p.id).GetType();
                    e.Property(p => p.id);
                });

            //modelBuilder.Entity<Description>(e =>
            //{
            //    e.ToTable("TDescription");
            //    e.HasKey(p => p.id);
            //    e.Property(d => d.id);

            //});

            //modelBuilder.Entity<Products>()
            //.OwnsOne(a => a.Description,
            //    addr =>
            //    {
            //        addr.Property(p => p.id);
            //        addr.Property(p => p.IdProducts);
            //        addr.Property(p => p.Name);
            //        addr.Property(p => p.Info);
            //    }).Property(p => p.id);

        }
    }
}
