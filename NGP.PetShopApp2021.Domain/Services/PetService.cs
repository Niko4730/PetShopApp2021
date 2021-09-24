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

        public Pet CreatePet(Pet pet)
        {
            return _repo.AddPet(pet);
        }

        public Pet DeletePet(int id)
        {
            return _repo.DeletePet(id);
        }

        public Pet UpdatePet(Pet pet)
        {
            throw new NotImplementedException();
        }

        public List<Pet> SearchByType(string type)
        {
            List<Pet> searchTypeList = _repo.FindAll().FindAll(pt => pt.Type.Name == type );
            return searchTypeList;
        }

        public List<Pet> SearchByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<Pet> SortByPrice(double price)
        {
            throw new NotImplementedException();
        }

        public Pet GetBetById(int id)
        {
            return _repo.GetPetById(id);
        }
    }
}