using Application.Abstractions.UnitOfWork;
using Application.CQRS.Books.Commands;
using Application.CQRS.Books.Queries;
using Application.DTOs.Responces;
using Application.Entities;
using MediatR;

namespace Application.CQRS.Books.Handlers;

public sealed class AddBookHandler : IRequestHandler<AddBookCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddBookHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(AddBookCommand request, CancellationToken cancellationToken)
    {
        var book = new Book()
        {
            Title = request.Book.Title,
            Author = request.Book.Author,
            Description = request.Book.Description
        };
        await _unitOfWork.BookRepository.Add(book);
        await _unitOfWork.SaveChangesAsync();

        return Result<int>.Success(book.Id, "Book saved successfully");
    }
}
