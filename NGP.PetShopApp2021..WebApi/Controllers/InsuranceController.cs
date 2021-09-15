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
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceController : ControllerBase
    {
        private readonly IInsuranceService _insuranceService;

        public InsuranceController(IInsuranceService insuranceService)
        {
            _insuranceService = insuranceService;
        }

        [HttpGet("{id}")]
        public ActionResult<Insurance> ReadById(int id)
        {
            try
            {
                return Ok(_insuranceService.InsuranceById(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, "Call 911");
            }
        }
    }
}