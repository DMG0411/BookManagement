using Application.DTOs;
using Application.Use_Cases.Commands;
using Application.Use_Cases.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Controllers
{
    [Route("api/v1/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator mediator;

        public BooksController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateBook(CreateBookCommand command)
        {
            var bookId = await mediator.Send(command);
            return Created(nameof(BookDto), bookId);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBookById(Guid id)
        {
            return await mediator.Send(new GetBookByIdQuery(id));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateBook(BookDto book)
        {
            await mediator.Send(new UpdateBookCommand(book));
            return Ok(book);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllBooks()
        {
           var books = await mediator.Send(new GetAllBooksQuery());
            return Ok(books);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(Guid id)
        {
            await mediator.Send(new DeleteBookCommand(id));
            return NoContent();
        }
    }
}
