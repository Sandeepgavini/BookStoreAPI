using BookStoreAPI.Exceptions;
using BookStoreAPI.Modals;
using BookStoreAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookStoreController : ControllerBase
    {
        private readonly IBookStoreService _service;

        public BookStoreController(IBookStoreService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await  _service.GetAll();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById([FromRoute] int id)
        {
            var book = await _service.GetById(id);
            if (book == null)
                return NotFound(ServiceExceptionConstants.NO_USER);
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] Book books)
        {
            int statusCode = await _service.AddBook(books);
            if (statusCode == -1)
                return BadRequest(ServiceExceptionConstants.INVALID_TITLE);
            return CreatedAtAction(nameof(AddBook),books);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook([FromRoute]int id, [FromBody] Book books)
        {
           
           int statusCode =  _service.UpdateBook(id, books);
            if(statusCode == -1)
                return BadRequest(ServiceExceptionConstants.UPDATE_ERROR);

            return Ok(books);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook([FromRoute] int id)
        {
            int statusCode = _service.DeleteBook(id);
            if(statusCode == 0)
                return BadRequest(ServiceExceptionConstants.NO_USER);
            return NoContent(); 
        }
    }
}
