using System;
using System.Collections.Generic;
using NGP.PetShopApp2021.Core.Models;
using NGP.PetShopApp2021.Domain.IRepositories;

namespace NGP.PetShopApp2021.Infrastructure.Data.Repositories
{
    public class PetRepositoryInMemory : IPetRepository
    {
        public Pet AddPet(string name, PetType type, string color, DateTime birthdate, DateTime soldDate, double price)
        {
            throw new NotImplementedException();
        }

        public List<Pet> FindAll()
        {
            throw new NotImplementedException();
        }
    }
}