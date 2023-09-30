using Application.DTOs.Requests;
using Application.DTOs.Responces;
using MediatR;

namespace Application.CQRS.Books.Commands;

public sealed class UpdateBookCommand : IRequest<Result<bool>>
{
    public UpdateBookRequest Book { get; }
    public UpdateBookCommand(UpdateBookRequest book)
    {
        Book = book;
    }
}
