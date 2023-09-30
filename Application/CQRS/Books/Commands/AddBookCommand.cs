using Application.DTOs.Requests;
using MediatR;

namespace Application.CQRS.Books.Commands;

public sealed class AddBookCommand : IRequest<int>
{
    public AddBookRequest Book { get; }
    public AddBookCommand(AddBookRequest book)
    {
        Book = book;
    }
}
