using Application.DTOs.Requests;
using Application.DTOs.Responces;
using MediatR;

namespace Application.CQRS.Books.Commands;

public sealed class AddBookCommand : IRequest<Result<int>>
{
    public AddBookRequest Book { get; }
    public AddBookCommand(AddBookRequest book)
    {
        Book = book;
    }
}
