using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NGP.PetShopApp2021.Core.IServices;
using NGP.PetShopApp2021.Core.Models;

namespace NGP.PetShopApp2021._WebApi.Controllers
{
    [Route("api/Pets")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private IPetService _petService;
        public PetsController(IPetService petService)
        {
            _petService = petService;
        }

        [HttpPost]
        public Pet CreatePet(string name, PetType type, string color, DateTime birthdate, DateTime soldDate, double price)
        {
            return _petService.CreatePet(name, type, color, birthdate, soldDate, price);
        }
        [HttpGet]
        public List<Pet> GetAll()
        {
            return _petService.GetAllPets();
        }
    }
}