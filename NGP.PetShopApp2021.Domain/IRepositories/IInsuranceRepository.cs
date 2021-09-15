using NGP.PetShopApp2021.Core.Models;

namespace NGP.PetShopApp2021.Domain.IRepositories
{
    public interface IInsuranceRepository
    {
        Insurance GetById(int id);
    }
}