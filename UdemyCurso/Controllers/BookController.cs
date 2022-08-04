using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UdemyCurso.Model;
using UdemyCurso.Services;

namespace UdemyCurso.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private IBookService bookService;
        public BookController(ILogger<BookController> logger, IBookService bookService)
        {
            _logger = logger;
            this.bookService = bookService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.bookService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var book = this.bookService.FindById(id);
            if(book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            if (book == null) return BadRequest();
            return Ok(this.bookService.Create(book));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Book book)
        {
            if (book == null) return BadRequest();
            return Ok(this.bookService.Update(book));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
             this.bookService.Delete(id);
            return NoContent(); ;
        }
    }
}
