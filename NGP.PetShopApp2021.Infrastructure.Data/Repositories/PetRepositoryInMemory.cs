using System;
using System.Collections.Generic;
using NGP.PetShopApp2021.Core.Models;
using NGP.PetShopApp2021.Domain.IRepositories;

namespace NGP.PetShopApp2021.Infrastructure.Data.Repositories
{
    public class PetRepositoryInMemory : IPetRepository
    {
        private static List<Pet> _petList = new List<Pet>();
        private static int _id = 1;
        public Pet AddPet(string name, PetType type, string color, DateTime birthdate, DateTime soldDate, double price)
        {
            var pet = new Pet()
            {
                Id = _id++,
                Name = name,
                Type = type,
                Color = color,
                BirthDate = birthdate,
                SoldDate = soldDate,
                Price = price
            };
            _petList.Add(pet);
            {
                return pet;
            }
        }

        public List<Pet> FindAll()
        {
            return _petList;
        }

        public Pet DeletePet(int id)
        {
            var pet = _petList.Find(p => p.Id == id);
            _petList.Remove(pet);
            return pet;
        }

        public Pet GetPetById(int id)
        {
            var pet = _petList.Find(p => p.Id == id);
            return pet;
        }
    }
}