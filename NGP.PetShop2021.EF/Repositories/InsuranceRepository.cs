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

        public Insurance DeleteInsurance(int id)
        {
            //Shows name, id and price on deleted element
            InsuranceEntity toRemove = _ctx.Insurances.Single(i => i.Id == id);
            _ctx.Remove(toRemove);
            _ctx.SaveChanges();
            Insurance returnValue = new Insurance
            {
                Id = toRemove.Id,
                Name = toRemove.Name,
                Price = toRemove.Price
            };
            return returnValue;
            //Shows only id of deleted element
            /*var entity = _ctx.Remove(new InsuranceEntity {Id = id}).Entity;
            
            _ctx.SaveChanges();
            return new Insurance
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price
            };*/
        }

        public Insurance EditInsurance(Insurance insurance)
        {
            var insuranceEntity = new InsuranceEntity
            {
                Id = insurance.Id,
                Name = insurance.Name,
                Price = insurance.Price
            };
            var entity = _ctx.Update(insuranceEntity).Entity;
            _ctx.SaveChanges();
            return new Insurance
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price
            };
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