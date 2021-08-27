using System;
using NGP.PetShopApp2021.Core.IServices;
using NGP.PetShopApp2021.Core.Models;
using NGP.PetShopApp2021.Domain.IRepositories;
using NGP.PetShopApp2021.Domain.Services;
using NGP.PetShopApp2021.Infrastructure.Data.Repositories;

namespace NGP.PetShopApp2021.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            IPetTypeRepository petTypeRepository = new PetTypeRepositoryInMemory();
            IPetTypeService petTypeService = new PetTypeService(petTypeRepository);
            
            IPetRepository petRepository = new PetRepositoryInMemory();
            IPetService petService = new PetService(petRepository);
            var menu = new Menu(petService, petTypeService);
            
            menu.ShowMainMenu();
            menu.MenuSelector();
        }
    }
}