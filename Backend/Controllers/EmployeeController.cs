using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Business;
using Backend.Model.Domain;
using Backend.Model.Dto;
using Backend.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        // private readonly IGenericRepository<Employee> employeeRepository;
        private readonly IEmployeeService employeeRepository;
        private readonly IMapper mapper;
        public EmployeeController(IEmployeeService employeeRepository, IMapper mapper)
        {
            this.employeeRepository = employeeRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("ViewAll")]
        public async Task<IActionResult> GetAll()
        {
            var users = await employeeRepository.GetAllAsync();
            if (users != null)
            {
                return Ok(users);
            }
            return BadRequest("Something Went Wrong");
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var user = await employeeRepository.GetByIdAsync(id);
            if (user != null)
            {
                return Ok(user);
            }
            return BadRequest("Something went wrong");
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] EmployeeResponseDto employeeResponseDto)
        {
            // var newEmployee = new Employee
            // {
            //     FirstName = employeeResponseDto.FirstName,
            //     LastName = employeeResponseDto.LastName,
            //     Gender = employeeResponseDto.Gender,
            //     ProfileImageUrl = employeeResponseDto.ProfileImageUrl,
            //     DOB = employeeResponseDto.DOB,
            //     HireDate = employeeResponseDto.HireDate,
            //     TerminationDate = employeeResponseDto.TerminationDate,
            //     Status = employeeResponseDto.Status,
            //     DepartmentId = employeeResponseDto.DepartmentId,
            //     JobRoleId = employeeResponseDto.JobRoleId,
            // };
            // var newEmployee = mapper.Map<Employee>(employeeResponseDto);
            var result = await employeeRepository.AddAsync(employeeResponseDto);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Employee not created");
        }


        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] EmployeeRequestDto employeeRequestDto)
        {
            var updatedUserDomain = mapper.Map<Employee>(employeeRequestDto);
            var result = await employeeRepository.UpdateAsync(id, updatedUserDomain);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<EmployeeResponseDto>(result));
        }


        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedEmployee = await employeeRepository.DeleteAsync(id);
            if (deletedEmployee != null)
            {
                return Ok(mapper.Map<EmployeeResponseDto>(deletedEmployee));
            }
            return null;
        }

    }
}