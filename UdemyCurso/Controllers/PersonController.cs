using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UdemyCurso.Model;
using UdemyCurso.Services;

namespace UdemyCurso.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private IPersonService personsService;
        public PersonController(ILogger<PersonController> logger, IPersonService personsService)
        {
            _logger = logger;
            this.personsService = personsService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.personsService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = this.personsService.FindById(id);
            if(person == null) return NotFound();
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return Ok(this.personsService.Create(person));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return Ok(this.personsService.Update(person));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
             this.personsService.Delete(id);
            return NoContent(); ;
        }
    }
}
