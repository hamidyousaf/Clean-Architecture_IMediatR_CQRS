using Application.Abstractions.UnitOfWork;
using Application.CQRS.Books.Commands;
using Application.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Books.Handlers;

public sealed class UpdateBookHandler : IRequestHandler<UpdateBookCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateBookHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        // Get book by id.
        var book = await _unitOfWork
            .BookRepository
            .Get(request.Book.Id);

        if (book is null)
        {
            return false;
        }

        book.Title = request.Book.Title;
        book.Description = request.Book.Description;
        book.Author = request.Book.Author;

        await _unitOfWork.BookRepository.Change(book);
        return true;
    }
}
