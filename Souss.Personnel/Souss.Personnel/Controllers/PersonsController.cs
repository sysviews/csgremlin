using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.AspNetCore.Mvc;
using Souss.DataLayer;
using Souss.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Souss.Personnel.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IRepository _repository;

        public PersonsController(IRepository repository)
        {
            _repository = repository;
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<Person>> Get()
        {
            return await _repository.GetAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Person> Get(string id)
        {
            return await _repository.GetAsync(id);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Person person)
        {
            var result = await _repository.AddAsync(person);
            return Created($"{Request.GetUri()}/{result.id}", result);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Person person)
        {
            await _repository.UpdateAsync(id, person);

            return Accepted();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _repository.DeleteAsync(id);

            return NoContent();
        }

        [HttpPost("{sourceId}/relateTo/{targetId}")]
        public async Task<IActionResult> PostRelationship(string sourceId, string targetId)
        {
            if (string.IsNullOrWhiteSpace(sourceId) ||
                string.IsNullOrWhiteSpace(targetId))
            {
                return BadRequest();
            }

            await _repository.RelateAsync(sourceId, targetId);

            return Accepted();
        }
    }
}
