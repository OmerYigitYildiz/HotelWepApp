using HotelDomain.Entities;
using HotelDomain.Entities.BaseEntity;
using HotelInfrastructure.Seeds;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelInfrastructure.Data
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
        {

        }

        //public DbSet<Ids> Ids { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Room> Rooms { get; set; }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Reserved> Reserveds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var roomIds = new[] { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() };

            modelBuilder.ApplyConfiguration(new RoomSeed(roomIds));
            modelBuilder.ApplyConfiguration(new ReservedSeed(roomIds));
            modelBuilder.ApplyConfiguration(new CustomerSeed(new Guid[] { }));


            modelBuilder.Entity<Author>()
                .HasMany(a => a.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(b => b.AuthorId);

            // One-to-One ilişkiyi tanımlama
            modelBuilder.Entity<Reserved>()
                .HasOne(r => r.Room)
                .WithOne()
                .HasForeignKey<Reserved>(r => r.RoomId)
                .OnDelete(DeleteBehavior.Cascade); // Room silinirse Reserved de silinsin


        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Book>()
        //        .HasOne(t => t.AuthorName)
        //        .WithMany(p => p.Books)
        //        .HasForeignKey(t => t.AuthorId);
        //}
    }
}
