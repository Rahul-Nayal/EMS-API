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
using StackExchange.Redis;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        // private readonly IGenericRepository<Department> departmentRepository;
        private readonly IDepartmentService departmentRepository;
        private readonly IMapper mapper;
        public DepartmentController(IDepartmentService departmentRepository, IMapper mapper)
        {
            this.departmentRepository = departmentRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        // [Authorize(Policy = Permission.Permission.Department.View)]
        public async Task<IActionResult> GetAll()
        {
            var departmentDomain = await departmentRepository.GetAllAsync();
            if (departmentDomain == null)
            {
                return NotFound();
            }
            return Ok(departmentDomain);
        }


        [Authorize(Policy = Permission.Permission.Department.View)]
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var existingDepartment = await departmentRepository.GetByIdAsync(id);
            if (existingDepartment == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<DepartmentDto>(existingDepartment));
        }


        [HttpPost]
        // [Authorize(Policy = Permission.Permission.Department.Create)]
        public async Task<IActionResult> Create([FromBody] DepartmentResponseDto departmentResponseDto)
        {
            // var currUser = HttpContext?.User?.Identity.??"System";
            ClaimsIdentity? identity = HttpContext.User.Identity as ClaimsIdentity;
            var currUser = identity.Claims.Where(a => a.Type == "user_id").Select(a => a.Value).SingleOrDefault() ?? "System";
            var departmentDomain = mapper.Map<Department>(departmentResponseDto);
            departmentDomain.CreatedBy = currUser;
            departmentDomain.CreatedAt = DateTime.UtcNow;
            departmentDomain.UpdatedBy = currUser;
            departmentDomain.UpdatedAt = DateTime.Now;
            departmentDomain.IsDeleted = false;

            var departmentCreated = await departmentRepository.AddAsync(departmentDomain);
            if (departmentCreated == null)
            {
                return Conflict("Department with this name already exists!");
            }
            return CreatedAtAction(nameof(GetById), new { id = departmentCreated.DepartmentId }, mapper.Map<DepartmentDto>(departmentCreated));
        }

        [HttpPut]
        [Route("{id:guid}")]
        [Authorize(Policy = Permission.Permission.Department.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] DepartmentDto departmentDto)
        {
            var updatedDepartmentDomain = mapper.Map<Department>(departmentDto);
            var updatedDepartmentResult = await departmentRepository.UpdateAsync(id, updatedDepartmentDomain);
            if (updatedDepartmentResult == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<DepartmentDto>(updatedDepartmentResult));
        }


        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize(Policy = Permission.Permission.Department.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedDepartment = await departmentRepository.DeleteAsync(id);
            if (deletedDepartment == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<DepartmentDto>(deletedDepartment));
        }


        [HttpGet]
        [Route("{id:guid}/jobroles")]
        [Authorize(Policy = Permission.Permission.JobRole.View)]
        public async Task<IActionResult> GetAllJobRole([FromRoute] Guid id)
        {
            var allJobDetails = await departmentRepository.GetAllJobRoleAsync(id);
            if (allJobDetails == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<IEnumerable<JobRoleDto>>(allJobDetails));
        }
        
    }
}