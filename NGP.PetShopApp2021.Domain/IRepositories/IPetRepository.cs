using System;
using System.Collections.Generic;
using NGP.PetShopApp2021.Core.Models;

namespace NGP.PetShopApp2021.Domain.IRepositories
{
    public interface IPetRepository
    {
        Pet AddPet(string name, PetType type, string color, string owner, DateTime birthdate, DateTime soldDate,
            double price);

        List<Pet> FindAll();

        Pet DeletePet(int id);

        Pet GetPetById(int id);
    }
}