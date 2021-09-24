using System.Collections.Generic;
using NGP.PetShopApp2021.Core.Models;

namespace NGP.PetShopApp2021.Domain.IRepositories
{
    public interface IInsuranceRepository
    {
        Insurance GetById(int id);

        Insurance CreateInsurance(Insurance insurance);

        List<Insurance> FindAll();
        Insurance DeleteInsurance(int id);
        Insurance EditInsurance(Insurance insurance);
    }
}