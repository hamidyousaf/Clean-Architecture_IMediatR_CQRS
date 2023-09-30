using MediatR;

namespace Application.CQRS.Books.Commands;

public sealed class DeleteBookCommand : IRequest<bool>
{
    public int BookId { get; }
    public DeleteBookCommand(int bookId)
    {
        BookId = bookId;
    }
}
