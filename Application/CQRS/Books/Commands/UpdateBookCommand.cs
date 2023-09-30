using Application.DTOs.Requests;
using MediatR;

namespace Application.CQRS.Books.Commands;

public sealed class UpdateBookCommand : IRequest<bool>
{
    public UpdateBookRequest Book { get; }
    public UpdateBookCommand(UpdateBookRequest book)
    {
        Book = book;
    }
}
