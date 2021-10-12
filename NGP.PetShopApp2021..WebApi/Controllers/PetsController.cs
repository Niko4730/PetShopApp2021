using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NGP.PetShopApp2021.Core.Filtrering;
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
        public ActionResult<Pet> CreatePet(Pet pet)
        {
            return _petService.CreatePet(pet);
        }
        [HttpGet]
        public ActionResult<List<Pet>> GetAll([FromQuery] Filter filter)
        {
            return _petService.GetAllPets(filter);
        }

        [HttpDelete]
        public ActionResult<Pet> DeletePet(int id)
        {
            return _petService.DeletePet(id);
        }
    }
}