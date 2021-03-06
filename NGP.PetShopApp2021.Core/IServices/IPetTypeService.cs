using System;
using System.Collections.Generic;
using NGP.PetShopApp2021.Core.Models;

namespace NGP.PetShopApp2021.Core.IServices
{
    public interface IPetTypeService
    {
        List<PetType> GetAllTypes();

        PetType PetTypeById(int id);
    }
}