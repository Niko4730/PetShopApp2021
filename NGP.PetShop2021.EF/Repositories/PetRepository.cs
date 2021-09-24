using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NGP.PetShop2021.EF.Entities;
using NGP.PetShopApp2021.Core.Models;
using NGP.PetShopApp2021.Domain.IRepositories;

namespace NGP.PetShop2021.EF.Repositories
{
    public class PetRepository : IPetRepository
    {

        private readonly PetShopDbContext _ctx;

        public PetRepository(PetShopDbContext ctx)
        {
            _ctx = ctx;
        }
        public Pet AddPet(Pet pet)
        {
            var entity = new PetEntity()
            {
                Name = pet.Name, 
                Color = pet.Color,
                Price = pet.Price,
                BirthDate = pet.BirthDate,
                SoldDate = pet.SoldDate
            };
            var saveEnt = _ctx.Pet.Add(entity).Entity;
            _ctx.SaveChanges();
            return new Pet
            {
                Name = saveEnt.Name,
                Color = saveEnt.Color,
                Price = saveEnt.Price,
                BirthDate = saveEnt.BirthDate,
                SoldDate = saveEnt.SoldDate
            };
        }

        public List<Pet> FindAll()
        {
            return _ctx.Pet
                .Include(pet => pet.Insurance)
                .Select(pet => new Pet
                {
                    Name = pet.Name,
                    Color = pet.Color,
                    Price = pet.Price,
                    BirthDate = pet.BirthDate,
                    SoldDate = pet.SoldDate,
                    Insurance = new Insurance
                    {
                        Id = pet.Insurance.Id,
                        Name = pet.Insurance.Name,
                        Price = pet.Insurance.Price
                    }
                }).ToList();
        }

        public Pet DeletePet(int id)
        {
            _ctx.Pet.Remove(new PetEntity {Id = id});
            _ctx.SaveChanges();
            return new Pet
            {
                Id = id
            };
        }

        public Pet GetPetById(int id)
        {
            return _ctx.Pet
                .Include(pet => pet.Insurance)
                .Select(entity => new Pet
                {
                    Name = entity.Name,
                    Color = entity.Color,
                    BirthDate = entity.BirthDate,
                    SoldDate = entity.SoldDate,
                    Insurance = new Insurance
                    {
                        Id = entity.Insurance.Id,
                        Name = entity.Insurance.Name
                    }
                }).FirstOrDefault(pet => pet.Id == id);
        }

        public Pet UpdatePet(Pet pet)
        {
            throw new NotImplementedException();
        }
    }
}