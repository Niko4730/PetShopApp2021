using System.Linq;
using System.Xml.Schema;
using NGP.PetShop2021.EF.Entities;
using NGP.PetShopApp2021.Core.Models;
using NGP.PetShopApp2021.Domain.IRepositories;

namespace NGP.PetShop2021.EF.Repositories
{
    public class InsuranceRepository :IInsuranceRepository
    {
        private readonly PetShopDbContext _ctx;

        public InsuranceRepository(PetShopDbContext ctx)
        {
            _ctx = ctx;
        }

        public Insurance GetById(int id)
        {
            return _ctx.Insurances
                .Select(ie => new Insurance
                    {
                        Id = ie.Id,
                        Name = ie.Name,
                        Price = ie.Price
                    })
                .FirstOrDefault(insurance => insurance.Id == id);
        }
    }
}