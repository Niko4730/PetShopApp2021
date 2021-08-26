using System.Collections.Generic;
using NGP.PetShopApp2021.Core.IServices;
using NGP.PetShopApp2021.Core.Models;
using NGP.PetShopApp2021.Domain.IRepositories;

namespace NGP.PetShopApp2021.Domain.Services
{
    public class PetTypeService : IPetTypeService
    {
        private IPetTypeRepository _repo;

        public PetTypeService(IPetTypeRepository repo)
        {
            _repo = repo;
        }
        public List<PetType> GetAllTypes()
        {
            throw new System.NotImplementedException();
        }

        public PetType PetTypeById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}