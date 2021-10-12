using System;
using System.Collections.Generic;
using NGP.PetShopApp2021.Core.Filtrering;
using NGP.PetShopApp2021.Core.Models;

namespace NGP.PetShopApp2021.Core.IServices
{
    public interface IPetService
    {
        List<Pet> GetAllPets(Filter filter);

        int TotalCount();

        Pet CreatePet(Pet pet);

        Pet DeletePet(int id);

        Pet UpdatePet(Pet pet);

        List<Pet> SearchByType(string type);

        List<Pet> SearchByName(string name);

        List<Pet> SortByPrice(double price);

        Pet GetBetById(int id);

    }
}