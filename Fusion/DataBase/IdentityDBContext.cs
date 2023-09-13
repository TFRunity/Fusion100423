using Fusion.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Fusion.DataBase
{
    public class IdentityDBContext : IdentityDbContext<User, UserRole, Guid>
    {
        public IdentityDBContext(DbContextOptions<IdentityDBContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<UsersPicture> UsersPictures { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductId> ProductIds { get; set; }
        public DbSet<ProductSubCategory> ProductSubCategories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //User's relationships

            modelBuilder.Entity<User>()
                .HasKey(t => new { t.Id });
            modelBuilder.Entity<User>()
                .HasMany(p => p.UsersPictures)
                .WithOne(u => u.User)
                .HasForeignKey(g => g.UserId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<User>()
                .HasMany(a => a.Orders)
                .WithOne(b => b.User)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Order>()
                .HasMany(a => a.ProductIds)
                .WithOne(b => b.Order)
                .HasForeignKey(c => c.OrderId)
                .OnDelete(DeleteBehavior.SetNull);
            //Ошибка может быть тут
            modelBuilder.Entity<Product>()
                .HasOne(a => a.ProductSubCategories)
                .WithOne(b => b.Product)
                .OnDelete(DeleteBehavior.Cascade);

            //n : n relationships

            modelBuilder.Entity<ProductCategory>()
                .HasKey(pf => new { pf.CategoryId, pf.ProductId });
            modelBuilder.Entity<ProductCategory>()
                .HasOne(pc => pc.Product)
                .WithMany(pc => pc.ProductCategories)
                .HasForeignKey(pc => pc.ProductId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ProductCategory>()
                .HasOne(pc => pc.Category)
                .WithMany(pc => pc.ProductCategories)
                .HasForeignKey(pc => pc.CategoryId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
