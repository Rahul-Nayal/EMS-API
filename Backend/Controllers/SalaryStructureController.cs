using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Business;
using Backend.Model.Domain;
using Backend.Model.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalaryStructureController : ControllerBase
    {
        private readonly ISalaryStructure salaryStructure;

         private readonly IMapper mapper;
        public SalaryStructureController(ISalaryStructure salaryStructure, IMapper mapper)
        {
            this.salaryStructure = salaryStructure;
            this.mapper = mapper;
        }

        [HttpGet]
        // [Authorize(Policy = Permission.Permission.JobRole.View)]
        public async Task<IActionResult> GetAll()
        {
            var result = await salaryStructure.GetAllAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);

        }

        [HttpGet]
        [Route("{id:Guid}")]
        // [Authorize(Policy = Permission.Permission.JobRole.View)]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var searchedJob = await salaryStructure.GetByIdAsync(id);
            if (searchedJob == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<SalaryStructureDto>(searchedJob));
        }

        // [Authorize(Roles = "Admin")]
        [HttpPost]
        // [Authorize(Policy = Permission.Permission.JobRole.Create)]
        public async Task<IActionResult> Create([FromBody] SalaryStructureDto salaryStructureDto)
        {
            ClaimsIdentity? identity = HttpContext.User.Identity as ClaimsIdentity;
            var currUser = identity.Claims.Where(a => a.Type == "user_id").Select(a => a.Value).SingleOrDefault() ?? "System";
            //convert dto to domain
            var jobDomainModel = mapper.Map<SalaryStructure>(salaryStructureDto);
            jobDomainModel.CreatedBy = currUser;
            jobDomainModel.UpdatedBy = currUser;
            jobDomainModel.IsDeleted = false;
            var jobCreated = await salaryStructure.AddAsync(jobDomainModel);
            if (jobCreated == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<SalaryStructureDto>(jobCreated));
        }


        [HttpPut]
        [Route("{id:guid}")]
        // [Authorize(Policy = Permission.Permission.JobRole.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] SalaryStructureDto salaryStructureDto)
        {
            var updatedSalaryStructure = mapper.Map<SalaryStructure>(salaryStructureDto);
            var updatedResult = await salaryStructure.UpdateAsync(id, updatedSalaryStructure);
            if (updatedResult == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<SalaryStructureDto>(updatedResult));
        }

        [HttpDelete]
        [Route("{id:guid}")]
        // [Authorize(Policy = Permission.Permission.JobRole.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedSalaryStructure = await salaryStructure.DeleteAsync(id);
            if (deletedSalaryStructure == null)
            {
                return null;
            }
            return Ok(deletedSalaryStructure);
        }
    }
}