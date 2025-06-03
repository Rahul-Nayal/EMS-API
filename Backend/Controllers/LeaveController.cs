using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Business;
using Backend.Model.Domain;
using Backend.Model.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaveController : ControllerBase
    {
        private readonly ILeaveService leaveService;
        private readonly IMapper mapper;

        public LeaveController(ILeaveService leaveService, IMapper mapper)
        {
            this.leaveService = leaveService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var leaveList = await leaveService.GetAllAsync();
            if (leaveList == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<List<LeaveRequestDto>>(leaveList));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Policy = Permission.Permission.Leave.View)]
        public async Task<IActionResult> GetById([FromRoute] Guid id) // employee id
        {
            var employeeLeave = await leaveService.GetByIdAsync(id);
            if (employeeLeave == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<List<LeaveRequestDto>>(employeeLeave));
        }

        [HttpPost]
        [Route("{id:Guid}")]
        [Authorize(Policy = Permission.Permission.Leave.Create)]
        public async Task<IActionResult> Create([FromRoute] Guid id, [FromBody] LeaveResponseDto leaveResponseDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var leaveDomain = mapper.Map<Leave>(leaveResponseDto);
                var newLeave = await leaveService.AddAsync(id, leaveDomain);
                if (newLeave == null)
                {
                    return StatusCode(500, "Leave not created due to internal server error");
                }
                var leaveResponse = mapper.Map<LeaveResponseDto>(newLeave);
                return CreatedAtAction(nameof(GetById), new { id = newLeave.Id }, leaveResponse);
            }
            catch (Exception er)
            {

                return StatusCode(500, "An error occured : " + er.Message);
            }
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [Authorize(Policy = Permission.Permission.Leave.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] LeaveResponseDto leaveResponseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var leaveDomain = mapper.Map<Leave>(leaveResponseDto);
            var updatedLeave = await leaveService.UpdateAsync(id, leaveDomain);
            if (updatedLeave == null)
            {
                return StatusCode(500, "Leave not updated due to internal server error");
            }
            return Ok(mapper.Map<LeaveResponseDto>(updatedLeave));
        }


        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Policy =Permission.Permission.Leave.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedLeave = await leaveService.DeleteAsync(id);
            if (deletedLeave == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<LeaveResponseDto>(deletedLeave));
        }
    }
}