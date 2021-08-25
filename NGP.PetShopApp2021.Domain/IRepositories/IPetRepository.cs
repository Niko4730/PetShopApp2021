﻿using System;
using System.Collections.Generic;
using NGP.PetShopApp2021.Core.Models;

namespace NGP.PetShopApp2021.Domain.IRepositories
{
    public interface IPetRepository
    {
        Pet AddPet(string name, PetType type, string color, DateTime birthdate, DateTime soldDate, double price);

        List<Pet> FindAll();
    }
}