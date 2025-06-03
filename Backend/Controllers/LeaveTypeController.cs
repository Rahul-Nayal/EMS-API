using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Business;
using Backend.Model.Domain;
using Backend.Model.Dto;
using Backend.Permission;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaveTypeController : ControllerBase
    {
        private readonly ILeaveTypeService leaveTypeService;
        private readonly IMapper mapper;
        public LeaveTypeController(ILeaveTypeService leaveTypeService, IMapper mapper)
        {
            this.leaveTypeService = leaveTypeService;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize (Policy = Permission.Permission.LeaveType.View)]
        public async Task<IActionResult> Get()
        {
            var leaveTypes = await leaveTypeService.GetAllAsync();
            if (leaveTypes == null)
            {
                return NotFound(new List<object>());
            }
            return Ok(mapper.Map<List<LeaveTypeRequestDto>>(leaveTypes));
        }

        [HttpPut]
        [Route("{id:guid}")]
        [Authorize(Policy = Permission.Permission.LeaveType.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid id, LeaveTypeResponseDto leaveTypeResponseDto)
        {
            var leaveTypeDomain = mapper.Map<LeaveType>(leaveTypeResponseDto);
            var updatedResult = await leaveTypeService.UpdateAsync(id, leaveTypeDomain);
            if (updatedResult == null)
            {
                return NotFound();
            }
            return Ok(leaveTypeDomain);
        }

        [HttpPost]
        // [Route("")]
        [Authorize(Policy = Permission.Permission.LeaveType.Create)]
        public async Task<IActionResult> Create([FromBody] LeaveTypeResponseDto leaveTypeResponseDto)
        {
            var leaveTypeDomain = mapper.Map<LeaveType>(leaveTypeResponseDto);
            var createdResult = await leaveTypeService.AddAsync(leaveTypeDomain);

            if (createdResult == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<LeaveTypeResponseDto>(createdResult));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Policy = Permission.Permission.LeaveType.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedLeaveType = await leaveTypeService.DeleteAsync(id);
            if (deletedLeaveType == null)
            {
                return NotFound("Leave Type Not Found");
            }
            return Ok(mapper.Map<LeaveTypeResponseDto>(deletedLeaveType));
        }
    }
}