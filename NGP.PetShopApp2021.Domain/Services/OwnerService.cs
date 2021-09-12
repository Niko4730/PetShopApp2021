using NGP.PetShopApp2021.Core.IServices;
using NGP.PetShopApp2021.Core.Models;
using NGP.PetShopApp2021.Domain.IRepositories;

namespace NGP.PetShopApp2021.Domain.Services
{
    public class OwnerService : IOwnerService
    {
        private IOwnerRepository _repo;

        public OwnerService(IOwnerRepository repo)
        {
            _repo = repo;
        }

        public Owner OwnerById(int id)
        {
            return _repo.OwnerById(id);
        }
    }
}