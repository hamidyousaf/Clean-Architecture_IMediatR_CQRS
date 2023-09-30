using Application.CQRS.Books.Commands;
using Application.CQRS.Books.Queries;
using Application.DTOs.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace Web.Controllers
{
    public class BookController : ApiBaseController
    {
        private readonly IMediator _mediator;
        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet("GetAllBooks")]
        public async Task<IActionResult> GetAllBooks()
        {
            var result = await _mediator.Send(new GetAllBooksQuery());
            
            return Ok(result);
        }

        [AllowAnonymous]
        [EnableRateLimiting("fixedPolicy")]
        [HttpGet("GetBookById/{bookId}")]
        public async Task<IActionResult> GetBookById(int bookId)
        {
            var result = await _mediator.Send(new GetBookByIdQuery(bookId));
            
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("AddBook")]
        public async Task<IActionResult> AddBook([FromBody] AddBookRequest request)
        {
            var result = await _mediator.Send(new AddBookCommand(request));

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPut("UpdateBook")]
        public async Task<IActionResult> UpdateBook([FromBody] UpdateBookRequest request)
        {
            var result = await _mediator.Send(new UpdateBookCommand(request));

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpDelete("DeleteBook/{bookId}")]
        public async Task<IActionResult> DeleteBook(int bookId)
        {
            var result = await _mediator.Send(new DeleteBookCommand(bookId));

            return Ok(result);
        }
    }
}
