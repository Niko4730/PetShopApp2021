using System.Collections.Generic;

namespace NGP.PetShop2021.EF.Entities
{
    public class InsuranceEntity
    {
        
        public List<PetEntity> PetEntityList { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}