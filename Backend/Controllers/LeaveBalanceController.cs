using System;
using System.Collections.Generic;
using System.Linq;
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
    public class LeaveBalanceController : ControllerBase
    {
        private readonly ILeaveBalanceService leaveBalanceService;
        private readonly IMapper mapper;
        public LeaveBalanceController(ILeaveBalanceService leaveBalanceService, IMapper mapper)
        {
            this.leaveBalanceService = leaveBalanceService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var leaveBalanceList = await leaveBalanceService.GetAllAsync();
            if (leaveBalanceList == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<List<LeaveBalanceRequestDto>>(leaveBalanceList));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LeaveBalanceResponseDto leaveBalanceResponseDto)
        {
            // var leaveBalanceDomain = mapper.Map<LeaveBalance>(leaveBalanceResponseDto);
            var newLeaveBalanceDetail = await leaveBalanceService.AddAsync(leaveBalanceResponseDto);
            if (newLeaveBalanceDetail == null)
            {
                return StatusCode(500, "Unable to add new leave balance rn");
            }
            return Ok(mapper.Map<LeaveBalanceResponseDto>(newLeaveBalanceDetail));
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] LeaveBalanceResponseDto leaveBalanceResponseDto)
        {
            var leaveBalanceDomain = mapper.Map<LeaveBalance>(leaveBalanceResponseDto);
            var updatedLeaveBalance = await leaveBalanceService.UpdateAsync(id, leaveBalanceDomain);
            if (updatedLeaveBalance == null)
            {
                return StatusCode(500, "Something getting wrong");
            }
            return Ok(mapper.Map<LeaveBalanceResponseDto>(updatedLeaveBalance));
        }
        

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedLeaveBalance = await leaveBalanceService.DeleteAsync(id);
            if (deletedLeaveBalance == null)
            {
                return StatusCode(500, "Something went wrong");
            }
            return Ok(mapper.Map<LeaveBalanceResponseDto>(deletedLeaveBalance));
        }
    }
}