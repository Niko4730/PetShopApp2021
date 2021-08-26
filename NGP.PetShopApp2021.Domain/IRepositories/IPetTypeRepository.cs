using System.Collections.Generic;
using NGP.PetShopApp2021.Core.Models;

namespace NGP.PetShopApp2021.Domain.IRepositories
{
    public interface IPetTypeRepository
    {
        List<PetType> FindALlTypes();

        PetType FindTypeById(int id);

    }
}