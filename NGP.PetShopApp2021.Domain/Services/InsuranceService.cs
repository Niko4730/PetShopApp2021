using System.Collections.Generic;
using NGP.PetShopApp2021.Core.IServices;
using NGP.PetShopApp2021.Core.Models;
using NGP.PetShopApp2021.Domain.IRepositories;

namespace NGP.PetShopApp2021.Domain.Services
{
    public class InsuranceService : IInsuranceService
    {
        private readonly IInsuranceRepository _insuranceRepository;

        public InsuranceService(IInsuranceRepository insuranceRepository)
        {
            _insuranceRepository = insuranceRepository;
        }

        public Insurance InsuranceById(int id)
        {
            return _insuranceRepository.GetById(id);
        }

        public Insurance CreateInsurance(Insurance insurance)
        {
            return _insuranceRepository.CreateInsurance(insurance);
        }

        public List<Insurance> GetAllInsurances()
        {
            return _insuranceRepository.FindAll();
        }

        public Insurance DeleteInsurance(int id)
        {

            return _insuranceRepository.DeleteInsurance(id);
        }
        
        public Insurance EditInsurance(Insurance insurance)
        {
            return _insuranceRepository.EditInsurance(insurance);
        }
    }
}