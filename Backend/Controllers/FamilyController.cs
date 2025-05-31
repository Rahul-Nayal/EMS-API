using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Business;
using Backend.Model.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FamilyController : ControllerBase
    {
        private readonly IFamilyService familyService;
        private readonly IMapper mapper;

        public FamilyController(IFamilyService familyService, IMapper mapper)
        {
            this.familyService = familyService;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var familyDetails = await familyService.GetAsync(id);
            if (familyDetails != null)
            {
                return Ok(familyDetails);
            }
            return NotFound();
        }

        [HttpPost]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Add([FromRoute] Guid id, [FromBody] FamilyDetailResponseDto familyDetailResponseDto)
        {
            var result = await familyService.AddUpdateAsync(id, familyDetailResponseDto);
            if (result != null)
            {
                return CreatedAtAction(nameof(Get), new { id = id }, result);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedMember = await familyService.DeleteAsync(id);
            if (deletedMember != null)
            {
                return Ok(mapper.Map<FamilyMemberResponseDto>(deletedMember));
            }
            return NotFound();
        }
    }
}