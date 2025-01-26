using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Attemp1.Models;

namespace Attemp1.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        // DbSet para las entidades
        public DbSet<Human> Human { get; set; }
        public DbSet<Comment> Comments { get; set; }

        // Configuración adicional en OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de la entidad Human
            modelBuilder.Entity<Human>(entity =>
            {
                entity.Property(h => h.Weight)
                    .HasColumnType("decimal(5, 2)") // Ajusta precisión y escala
                    .IsRequired(); // Asegura que no sea null

                entity.Property(h => h.Height)
                    .HasColumnType("decimal(5, 2)") // Ajusta precisión y escala
                    .IsRequired();

                entity.Property(h => h.Name)
                    .HasMaxLength(100) // Límite de longitud para el nombre
                    .IsRequired();

                entity.Property(h => h.Gender)
                    .HasMaxLength(10) // Límite de longitud para el género
                    .IsRequired();
            });

            // Configuración de la entidad Comment
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(c => c.Title)
                    .HasMaxLength(200) // Límite de longitud para el título
                    .IsRequired();

                entity.Property(c => c.Content)
                    .IsRequired();

                entity.Property(c => c.CreatedOn)
                    .HasDefaultValueSql("GETDATE()"); // Valor por defecto al insertar

                // Configuración de la relación con Human
                entity.HasOne(c => c.Human)
                    .WithMany(h => h.Comments)
                    .HasForeignKey(c => c.HumanId)
                    .OnDelete(DeleteBehavior.Cascade); // Elimina comentarios cuando se elimina un humano
            });
        }
    }
}


/*
namespace Attemp1.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Human> Human { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
*/