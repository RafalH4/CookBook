using CookBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<UserRole>()
        //        .HasOne(x => x.User)
        //        .WithMany(x => x.Roles)
        //        .HasForeignKey(x => x.UserId);

        //    modelBuilder.Entity<UserRole>()
        //        .HasOne(x => x.Role)
        //        .WithMany(x => x.UserRoles)
        //        .HasForeignKey(x => x.RoleId);

        //    modelBuilder.Entity<Ingredient>()
        //        .HasOne(x => x.Product)
        //        .WithMany(x => x.AsIngredient)
        //        .HasForeignKey(x => x.ProductId);

        //    modelBuilder.Entity<Ingredient>()
        //        .HasOne<Dish>(x => x.Dish)
        //        .WithMany(x => x.Ingredients)
        //        .HasForeignKey(x => x.)
        //}

        //public DbSet<Dish> Dishes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
    }
}
