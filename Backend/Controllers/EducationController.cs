using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
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
    public class EducationController : ControllerBase
    {
        private readonly IEducationService educationService;
        private readonly IMapper mapper;
        public EducationController(IEducationService educationService, IMapper mapper)
        {
            this.educationService = educationService;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var educationDetails = await educationService.GetAsync(id);
            if (educationDetails == null)
            {
                return NotFound();
            }
            return Ok(educationDetails);
        }

        [HttpPost]
        [Route("{id:Guid}")]
        public async Task<IActionResult> AddUpdate([FromRoute] Guid id, [FromBody] EducationResponseDto educationResponseDto)
        {
            var educationDomain = mapper.Map<Education>(educationResponseDto);
            // var educationDomain = new Education
            // {
            //     Course = educationResponseDto.Course,
            //     Title = educationResponseDto.Title,
            //     CGPA = Convert.ToInt64(educationResponseDto.CGPA)
            // };
            var resultDomain = await educationService.AddUpdateAsync(id, educationDomain);
            if (resultDomain != null)
            {
                return Ok(mapper.Map<EducationResponseDto>(resultDomain));
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedEducationResult = await educationService.DeleteAsync(id);
            if (deletedEducationResult != null)
            {
                return Ok(mapper.Map<EducationResponseDto>(deletedEducationResult));
            }
            return NotFound();
        }

    }
}