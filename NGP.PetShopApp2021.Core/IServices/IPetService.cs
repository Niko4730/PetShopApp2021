using System;
using System.Collections.Generic;
using NGP.PetShopApp2021.Core.Models;

namespace NGP.PetShopApp2021.Core.IServices
{
    public interface IPetService
    {
        List<Pet> GetAllPets();

        Pet CreatePet(string name, PetType type, string color, string owner, DateTime birthdate, DateTime soldDate,
            double price);

        Pet DeletePet(int id);

        Pet UpdatePet(int id);

        List<Pet> SearchByType(string type);

        List<Pet> SearchByName(string name);

        List<Pet> SortByPrice(double price);

        Pet GetBetById(int id);

    }
}