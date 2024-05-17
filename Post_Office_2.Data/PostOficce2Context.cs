using Lab_2.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post_Office_2.Data
{
    //public class AppDbContext : DbContext
    //{
    //    public DbSet<Parcel> Parcels { get; set; }
    //    public DbSet<City> Cities { get; set; }
    //    public DbSet<PostOffice> PostOffices { get; set; }
    //    public DbSet<Client> Clients { get; set; }

    //    //public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    //    //{
    //    //}
    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    {
    //        var serverVersion = new MySqlServerVersion(new Version(8, 3, 0));
    //        optionsBuilder.UseMySql("server=Localhost;user=root;password=445566778899N;database=post_office", serverVersion);
    //    }

    //    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //        // Налаштування зв'язків між сутностями за допомогою Fluent API

    //        // Зв'язок багато-до-одного між Parcel та PostOffice
    //        modelBuilder.Entity<Parcel>()
    //             .HasOne(p => p.PostOffice)
    //             .WithMany(po => po.Parcels)
    //             .HasForeignKey(p => p.PostOfficeId);

    //        // Зв'язок багато-до-одного між PostOffice та City
    //        modelBuilder.Entity<PostOffice>()
    //            .HasOne(po => po.City)
    //            .WithMany(c => c.PostOffices)
    //            .HasForeignKey(po => po.CityId);
    //        // Configure primary key for Entity base class
    //        modelBuilder.Entity<ServiceObject>()
    //            .HasKey(e => e.Id);

    //        //Configure default value for Createdat in Entity base class
    //        modelBuilder.Entity<ServiceObject>()
    //            .Property(e => e.CreatedAt)
    //            .HasDefaultValueSql("CURRENT TIMESTAMP");
    //    }
    //}
    public class AppDbContext : DbContext
    {
        public DbSet<Parcel> Parcels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 3, 0));
            optionsBuilder.UseMySql("server=Localhost;user=root;password=445566778899N;database=post_office", serverVersion);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //// Configure primary key for Parcel entity
            //modelBuilder.Entity<Parcel>()
            //    .HasKey(e => e.Id);

            ////Configure default value for CreatedAt in Parcel entity
            //modelBuilder.Entity<Parcel>()
            //    .Property(e => e.CreatedAt)
            //    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            // Configure primary key for Parcel entity




            //modelBuilder.Entity<Parcel>()
            //    .HasKey(e => e.Id);

            ////Configure default value for CreatedAt in Parcel entity
            //modelBuilder.Entity<Parcel>()
            //    .Property(e => e.CreatedAt)
            //    .HasDefaultValueSql("DEFAULT CURRENT_TIMESTAMP");



            //// Configure primary key for Parcel entity
            //modelBuilder.Entity<Parcel>()
            //    .HasKey(e => e.Id);

            ////Configure default value for CreatedAt in Parcel entity
            //modelBuilder.Entity<Parcel>()
            //    .Property(e => e.CreatedAt)
            //    .HasDefaultValueSql("DEFAULT CURRENT_TIMESTAMP");

            //// Configure Parcels table
            //modelBuilder.Entity<Parcel>()
            //    .ToTable("Parcels");

            //modelBuilder.Entity<Parcel>()
            //    .Property(e => e.Weight)
            //    .IsRequired();

            //modelBuilder.Entity<Parcel>()
            //    .Property(e => e.DateSend)
            //    .IsRequired();

            //modelBuilder.Entity<Parcel>()
            //    .Property(e => e.DateCome)
            //    .IsRequired();

            //modelBuilder.Entity<Parcel>()
            //    .Property(e => e.Price)
            //    .IsRequired();

            //modelBuilder.Entity<Parcel>()
            //    .Property(e => e.PostOfficeId)
            //    .IsRequired();


            modelBuilder.Entity<Parcel>()
                .Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP()")
                .ValueGeneratedOnAddOrUpdate();













        }
    }

}
