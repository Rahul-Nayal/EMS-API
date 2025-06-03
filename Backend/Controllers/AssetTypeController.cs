using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
    public class AssetTypeController : ControllerBase
    {
        private readonly IAssetType assetType;
        private readonly IMapper mapper;
        public AssetTypeController(IAssetType assetType, IMapper mapper)
        {
            this.assetType = assetType;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize(Policy = Permission.Permission.AssetType.View)]
        public async Task<IActionResult> GetAll()
        {
            var result = await assetType.GetAllAsync();
            if (result != null)
            {
                return Ok(mapper.Map<List<AssetTypeRequestDto>>(result));
            }
            return NotFound("No Asset Type | Firstly Add Asset!");
        }

        // [HttpGet]
        // [Route("{id:guid}")]
        // public async Task<IActionResult> GetById([FromRoute] Guid id)
        // {
        //     var result = await assetType.GetByIdAsync(id);
        //     if (result != null)
        //     {
        //         return Ok(result);
        //     }
        //     return BadRequest("Something went wrong , Not able to fetch data");
        // }

        [HttpPut]
        [Route("{id:guid}")]
        [Authorize(Policy = Permission.Permission.Employee.Update)]
        public async Task<IActionResult> Update(Guid id, [FromForm] AssetTypeResponseDto assetTypeResponseDto)
        {
            // var assetsTypeDomainModel = mapper.Map<AssetType>(assetTypeRequestDto);
            // ClaimsIdentity? identity = HttpContext.User.Identity as ClaimsIdentity;
            // var currUser = identity.Claims.Where(a => a.Type == "user_id").Select(a => a.Value).SingleOrDefault() ?? "System";
            // var departmentDomain = mapper.Map<AssetType>(assetTypeRequestDto);
            // // departmentDomain.CreatedBy = currUser;
            // // departmentDomain.CreatedAt = DateTime.UtcNow;
            // departmentDomain.UpdatedBy = currUser;
            // departmentDomain.UpdatedAt = DateTime.Now;
            // departmentDomain.IsDeleted = false;

            var result = await assetType.UpdateAsync(id, assetTypeResponseDto);
            if (result != null)
            {
                return Ok(mapper.Map<AssetTypeRequestDto>(result));
            }
            return BadRequest("Something went wrong");
        }

        [HttpPost]
        // [Route("{}")]
        [Authorize(Policy = Permission.Permission.AssetType.View)]
        public async Task<IActionResult> Create([FromForm] AssetTypeResponseDto assetTypeResponseDto)
        {
            // var assetsTypeDomainModel = mapper.Map<AssetType>(assetTypeRequestDto);
            var assetsDomainResult = await assetType.CreateAsync(assetTypeResponseDto);
            if (assetsDomainResult != null)
            {
                return Ok(mapper.Map<AssetTypeRequestDto>(assetsDomainResult));
            }
            return BadRequest("Something went wrong");
        }


        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize(Policy = Permission.Permission.AssetType.Delete)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await assetType.DeleteAsync(id);
            if (result != null)
            {
                return Ok(mapper.Map<AssetTypeRequestDto>(result));
            }
            return NotFound("Asset Type Not Found");
        }
    }
}