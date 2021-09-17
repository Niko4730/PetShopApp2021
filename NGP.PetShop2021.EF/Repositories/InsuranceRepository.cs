using System.Collections.Generic;
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

        public Insurance CreateInsurance(Insurance insurance)
        {
            var entity = _ctx.Add(new InsuranceEntity
            {
                Name = insurance.Name,
                Price = insurance.Price,
            }).Entity;
            _ctx.SaveChanges();
            return new Insurance
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price
            };
        }

        public List<Insurance> FindAll()
        {
            return _ctx.Insurances.Select(insurance => new Insurance
                {
                    Id = insurance.Id,
                    Name = insurance.Name,
                    Price = insurance.Price
                }).OrderBy(i => i.Price)
                .ToList();
        }
    }
}