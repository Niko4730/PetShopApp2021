using NGP.PetShopApp2021.Core.Models;

namespace NGP.PetShopApp2021.Core.IServices
{
    public interface IOwnerService
    {
        public Owner OwnerById(int id);
    }
}