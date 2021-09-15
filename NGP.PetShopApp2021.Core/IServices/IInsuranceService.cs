using NGP.PetShopApp2021.Core.Models;

namespace NGP.PetShopApp2021.Core.IServices
{
    public interface IInsuranceService
    {
        Insurance InsuranceById(int id);
        
    }
}