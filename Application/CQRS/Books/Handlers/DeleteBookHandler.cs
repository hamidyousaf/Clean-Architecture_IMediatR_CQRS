using Application.Abstractions.UnitOfWork;
using Application.CQRS.Books.Commands;
using Application.DTOs.ProjectToDTOs;
using Application.DTOs.Responces;
using MediatR;

namespace Application.CQRS.Books.Handlers;

public sealed class DeleteBookHandler : IRequestHandler<DeleteBookCommand, Result<bool>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteBookHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<bool>> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        // Get book by id.
        var book = await _unitOfWork.BookRepository.GetById(request.BookId);

        if (book is null)
        {
            return Result<bool>.Fail($"There is no book found with id: {request.BookId}");
        }

        await _unitOfWork.BookRepository.DeleteById(request.BookId);
        await _unitOfWork.SaveChangesAsync();

        return Result<bool>.Success(true, message: "Book deleted successfully.");
    }
}
