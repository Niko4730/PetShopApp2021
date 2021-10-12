using Microsoft.EntityFrameworkCore;
using NGP.PetShop2021.EF.Entities;

namespace NGP.PetShop2021.EF
{
    public class PetShopDbContext : DbContext
    {
        public PetShopDbContext(DbContextOptions<PetShopDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PetEntity>().HasOne(petEntity => petEntity.Insurance)
                .WithMany(ie => ie.PetEntityList)
                .HasForeignKey(pet => new {pet.insuranceId});
            modelBuilder.Entity<InsuranceEntity>()
                .HasData(new InsuranceEntity {Id = 1, Name = "Basic", Price = 60});
            modelBuilder.Entity<InsuranceEntity>()
                .HasData(new InsuranceEntity {Id = 2, Name = "Premium", Price = 80});
            modelBuilder.Entity<InsuranceEntity>()
                .HasData(new InsuranceEntity {Id = 3, Name = "Pro", Price = 100});
            modelBuilder.Entity<InsuranceEntity>()
                .HasData(new InsuranceEntity {Id = 4, Name = "ProPlus", Price = 120});
            
            modelBuilder.Entity<PetEntity>()
                .HasData(new PetEntity {Id = 4, Name = "Loui", Price = 1000, insuranceId = 1});
        }

        public DbSet<InsuranceEntity> Insurances { get; set; }  
        
        public DbSet<PetEntity> Pet { get; set; }
        
    }
}