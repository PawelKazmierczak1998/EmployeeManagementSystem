using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerLibrary.Repositories.Contracts;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController<T>(IGenericRepository<T> genericRepository) : Controller where T : class
    {
        [HttpGet("all")]       
        public async Task<IActionResult> GetAll()=> Ok(await genericRepository.GetAll());

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest("Invalid request");
            return Ok(await genericRepository.DeleteById(id));
        }

        [HttpGet("single/{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0) return BadRequest("Invalid request");
            return Ok(await genericRepository.GetById(id));

        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(T model)
        {
            if (model is null) return BadRequest("Invalid request");
            return Ok(await genericRepository.Insert(model));

        }
        [HttpPut("update")]
        public async Task<IActionResult> Upddate(T model)
        {
            if (model is null) return BadRequest("Invalid request");
            return Ok(await genericRepository.Update(model));

        }


    }
}
