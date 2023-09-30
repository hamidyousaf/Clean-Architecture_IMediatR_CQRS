using Application.Abstractions.UnitOfWork;
using Application.CQRS.Books.Commands;
using MediatR;

namespace Application.CQRS.Books.Handlers;

public sealed class DeleteBookHandler : IRequestHandler<DeleteBookCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteBookHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        // Get book by id.
        //var book = await _unitOfWork
        //    .BookRepository
        //    .Get(request.BookId);

        //if (book is null)
        //{
        //    return false;
        //}

        await _unitOfWork.BookRepository.Delete(request.BookId);
        return true;
    }
}
