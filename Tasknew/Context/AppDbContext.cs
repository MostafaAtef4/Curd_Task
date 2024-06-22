using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using Tasknew.Mapper;
using Tasknew.Models;

namespace Tasknew.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Order>()
            //.HasMany(o => o.OrderItems)
            //.WithOne(oi => oi.Order)
            //.HasForeignKey(oi => oi.OrderId);


            //.WithMany(mi => mi.OrderItems)
            //.HasForeignKey(oi => oi.MenuItemId);
          

            modelBuilder.Entity<FeedBack>().Property(x => x.DateSubmitted)
                 .HasDefaultValue(DateTime.UtcNow);

            modelBuilder.Entity<Order>().Property(x => x.OrderDate)
                .HasDefaultValue(DateTime.UtcNow);

            // modelBuilder.Entity<FeedBack>()
            //.Property(p => p.Rating)
            //.IsRequired()
            //.HasDefaultValue(1)
            // .HasAnnotation("Range", new RangeAttribute(1, 5));

            //modelBuilder.Entity<FeedBack>().Property(x => x.Rating)
            //    .HasDefaultValue(1)
            //    .HasAnnotation("Range", new RangeAttribute(1, 5));



            //Make Referentialaction in delete at all table Restrict 

            //foreach (var relationship in modelBuilder.Model.GetEntityTypes()
            //    .SelectMany(e => e.GetForeignKeys()))
            //{
            //    relationship.DeleteBehavior = DeleteBehavior.Restrict;
            //}
        }

    }
}
