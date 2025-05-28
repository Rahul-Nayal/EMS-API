using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Business;
using Backend.Model.Domain;
using Backend.Model.Dto;
using Backend.Permission;
using Backend.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobRoleController : ControllerBase
    {
        // private readonly IGenericRepository<JobRole> jobRoleRepository;
        private readonly IJobRoleService jobRoleRepository;
        private readonly IMapper mapper;
        public JobRoleController(IJobRoleService jobRoleRepository, IMapper mapper)
        {
            this.jobRoleRepository = jobRoleRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize(Policy = Permission.Permission.JobRole.View)]
        public async Task<IActionResult> GetAll()
        {
            var result = await jobRoleRepository.GetAllAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);

        }

        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Policy = Permission.Permission.JobRole.View)]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var searchedJob = await jobRoleRepository.GetByIdAsync(id);
            if (searchedJob == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<JobRoleRequestDto>(searchedJob));
        }

        // [Authorize(Roles = "Admin")]
        [HttpPost]
        [Authorize(Policy = Permission.Permission.JobRole.Create)]
        public async Task<IActionResult> Create([FromBody] JobRoleRequestDto jobRoleRequestDto)
        {
            ClaimsIdentity? identity = HttpContext.User.Identity as ClaimsIdentity;
            var currUser = identity.Claims.Where(a => a.Type == "user_id").Select(a => a.Value).SingleOrDefault() ?? "System";
            //convert dto to domain
            var jobDomainModel = mapper.Map<JobRole>(jobRoleRequestDto);
            jobDomainModel.CreatedBy = currUser;
            jobDomainModel.UpdatedBy = currUser;
            jobDomainModel.IsDeleted = false;
            var jobCreated = await jobRoleRepository.AddAsync(jobDomainModel);
            if (jobCreated == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<JobRoleRequestDto>(jobCreated));
        }


        [HttpPut]
        [Route("{id:guid}")]
        [Authorize(Policy = Permission.Permission.JobRole.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] JobRoleRequestDto jobRoleRequestDto)
        {
            var updatedUserDomain = mapper.Map<JobRole>(jobRoleRequestDto);
            var updatedResult = await jobRoleRepository.UpdateAsync(id, updatedUserDomain);
            if (updatedResult == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<JobRoleRequestDto>(updatedResult));
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize(Policy = Permission.Permission.JobRole.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedJobRole = await jobRoleRepository.DeleteAsync(id);
            if (deletedJobRole == null)
            {
                return null;
            }
            return Ok(deletedJobRole);
        }
    }
}