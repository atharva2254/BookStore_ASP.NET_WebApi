using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Infrastructure.Configuration
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CartItem>().HasKey(x => new { x.UserId, x.BookId });

            modelBuilder.Entity<CartItem>()
                .HasOne(x => x.User).WithMany(x => x.CartItems).HasForeignKey(x => x.UserId);

            modelBuilder.Entity<CartItem>()
                .HasOne(x => x.Book).WithMany(x => x.CartItems).HasForeignKey(x => x.BookId);

            modelBuilder.Entity<Order>()
                .HasOne(x => x.User)
                .WithMany(x => x.Orders).HasForeignKey(x => x.UserId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(x => x.Order)
                .WithMany(x => x.OrderItems)
                .HasForeignKey(x => x.OrderId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(x => x.Book)
                .WithMany(x => x.OrderItems)
                .HasForeignKey(x => x.BookId);
        }
    }
}
