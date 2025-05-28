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
    public class ContactDetailsController : ControllerBase
    {
        private readonly IContactDetails contactDetails;
        private readonly IMapper mapper;
        public ContactDetailsController(IContactDetails contactDetails, IMapper mapper)
        {
            this.contactDetails = contactDetails;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var details = await contactDetails.GetAsync(id);
            if (details == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<ContactDetailsRequestDto>(details));
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] ContactDetailsRequestDto contactDetailsRequestDto)
        {
            var contactDetailsDomain = mapper.Map<ContactDetails>(contactDetailsRequestDto);
            var contactDetailsResult = await contactDetails.UpdateAsync(id, contactDetailsDomain);
            if (contactDetailsResult == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<ContactDetailsRequestDto>(contactDetailsResult));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var existedContactDetails = await contactDetails.DeleteAsync(id);
            if (existedContactDetails == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<ContactDetailsRequestDto>(existedContactDetails));
        }
    }
}

