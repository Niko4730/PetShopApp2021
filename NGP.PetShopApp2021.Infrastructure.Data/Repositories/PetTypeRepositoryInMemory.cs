using System.Collections.Generic;
using NGP.PetShopApp2021.Core.Models;
using NGP.PetShopApp2021.Domain.IRepositories;

namespace NGP.PetShopApp2021.Infrastructure.Data.Repositories
{
    public class PetTypeRepositoryInMemory : IPetTypeRepository
    {
        private static List<PetType> _petTypeList = new List<PetType>();

        public PetTypeRepositoryInMemory()
        {
            PetType cat = new PetType {Id = 1, Name = "Cat"};
            PetType dog = new PetType {Id = 2, Name = "Dog"};
            PetType guineapig = new PetType {Id = 3, Name = "Guineapig"};
            _petTypeList.AddRange(new List<PetType> {cat, dog, guineapig});
        }

        public List<PetType> FindALlTypes()
        {
            return _petTypeList;
        }

        public PetType FindTypeById(int id)
        {
            foreach (PetType petType in _petTypeList)
            {
                if (petType.Id == id)
                {
                    return petType;
                }
            }
            return null;
        }
    }
}