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
    [Route("api/Insurance")]
    [ApiController]
    public class InsuranceController : ControllerBase
    {
        private readonly IInsuranceService _insuranceService;

        public InsuranceController(IInsuranceService insuranceService)
        {
            _insuranceService = insuranceService;
        }

        [HttpPost]
        public ActionResult<Insurance> Create([FromBody] Insurance insurance)
        {
            try
            {
                return Ok(_insuranceService.CreateInsurance(insurance));
            }
            catch (Exception e)
            {
                return StatusCode(500, "Call 911");
            }
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

        [HttpGet]
        public ActionResult<List<Insurance>> ReadAll()
        {
            try
            {
                return Ok(_insuranceService.GetAllInsurances());
            }
            catch (Exception e)
            {
                return StatusCode(500, "Call 911");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Insurance> DeleteInsurance(int id)
        {
            try
            {
                return Ok(_insuranceService.DeleteInsurance(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, "Call 911");
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Insurance> UpdateInsurance(int id, [FromBody] Insurance insurance)
        {
            try
            {
                if (id != insurance.Id)
                {
                    return BadRequest("Id is wrong");
                }
                insurance.Id = id;
                
                return Ok(_insuranceService.EditInsurance(insurance));
            }
            catch (Exception e)
            {
                return StatusCode(500, "Call 911");
            }
        }
    }
}