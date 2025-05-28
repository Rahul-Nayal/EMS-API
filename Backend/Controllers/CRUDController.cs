using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Business;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    public class CRUDController<T> : Controller where T : class
    {
        private readonly IGenericService<T> repository;

        public CRUDController(IGenericService<T> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await repository.GetAllAsync();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Something went wrong , Not able to fetch data");
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await repository.GetByIdAsync(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Something went wrong , Not able to fetch data");
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] T entity)
        {
            var result = await repository.UpdateAsync(id, entity);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Something went wrong");
        }

        // [HttpPost]
        // [Route("{id:Guid}")]
        // public async Task<IActionResult> Add(Guid id)
        // {

        // }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = repository.DeleteAsync(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Something went wrong");
        }
    }
}