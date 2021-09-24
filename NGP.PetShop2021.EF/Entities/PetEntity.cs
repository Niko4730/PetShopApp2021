using System;

namespace NGP.PetShop2021.EF.Entities
{
    public class PetEntity
    {
        public int Id { get; set; }

        public InsuranceEntity Insurance { get; set; }

        public int insuranceId { get; set; }
        
        public string Name { get; set; }
        
        public string Owner { get; set; }
        
        public DateTime BirthDate { get; set; }
        
        public DateTime SoldDate { get; set; }
        
        public string Color { get; set; }
        
        public double Price { get; set; }
    }
}