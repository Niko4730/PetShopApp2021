using System;
using System.Collections.Generic;
using NGP.PetShopApp2021.Core.IServices;
using NGP.PetShopApp2021.Core.Models;
using NGP.PetShopApp2021.Domain.IRepositories;

namespace NGP.PetShopApp2021.Domain.Services
{
    public class PetService : IPetService
    {
        private IPetRepository _repo;
        public PetService(IPetRepository repo)
        {
            _repo = repo;
        }
        public List<Pet> GetAllPets()
        {
            return _repo.FindAll();
        }

        public Pet CreatePet(string name, PetType type, string color, DateTime birthdate, DateTime soldDate, double price)
        {
            throw new NotImplementedException();
        }

        public Pet DeletePet(int id)
        {
            throw new NotImplementedException();
        }

        public Pet UpdatePet(int id)
        {
            throw new NotImplementedException();
        }

        public List<Pet> SearchByType(PetType type)
        {
            throw new NotImplementedException();
        }

        public List<Pet> SearchByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<Pet> SortByPrice(double price)
        {
            throw new NotImplementedException();
        }
    }
}