﻿using Microsoft.EntityFrameworkCore;
using NGP.PetShop2021.EF.Entities;

namespace NGP.PetShop2021.EF
{
    public class PetShopDbContext : DbContext
    {
        public PetShopDbContext(DbContextOptions<PetShopDbContext> options) : base(options){}
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InsuranceEntity>()
                .HasData(new InsuranceEntity {Id = 1, Name = "Basic", Price = 60});
            modelBuilder.Entity<InsuranceEntity>()
                .HasData(new InsuranceEntity {Id = 2, Name = "Premium", Price = 80});
            modelBuilder.Entity<InsuranceEntity>()
                .HasData(new InsuranceEntity {Id = 3, Name = "Pro", Price = 100});
        }

        public DbSet<InsuranceEntity> Insurances { get; set; }    
    }
}