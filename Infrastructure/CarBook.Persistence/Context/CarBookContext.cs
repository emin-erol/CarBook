﻿using CarBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Burada Sql Server bağlantısı sağlanır ve oluşturulan entity'ler tablo haline getirilir

namespace CarBook.Persistence.Context
{
    public class CarBookContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=DESKTOP-F70PD25\\SQLEXPRESS\\SQLEXPRESS;initial Catalog=CarBookDb;integrated Security=true;TrustServerCertificate=true;");
            optionsBuilder.UseSqlServer("Server=DESKTOP-F70PD25\\SQLEXPRESS;Database=CarBookDb;Integrated Security=true; Encrypt=False;");
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarDescription> Descriptions { get; set; }
        public DbSet<CarFeature> CarFeatures { get; set; }
        public DbSet<CarPricing> CarPricings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<FooterAddress> FooterAddresses { get; set; }
        public DbSet<Location> Locations{ get; set; }
        public DbSet<Pricing> Pricings { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<TagCloud> TagClouds { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<RentACar> RentACars { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>()
                .HasOne(x => x.PickUpLocation)
                .WithMany(y => y.PickUpReservation)
                .HasForeignKey(z => z.PickUpLocationId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Reservation>()
                .HasOne(x => x.DropOffLocation)
                .WithMany(y => y.DropOffReservation)
                .HasForeignKey(z => z.DropOffLocationId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}