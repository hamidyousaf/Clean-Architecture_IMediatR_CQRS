using Application.Abstractions.UnitOfWork;
using Application.CQRS.Books.Commands;
using Application.CQRS.Books.Queries;
using Application.Entities;
using MediatR;

namespace Application.CQRS.Books.Handlers;

public sealed class AddBookHandler : IRequestHandler<AddBookCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddBookHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(AddBookCommand request, CancellationToken cancellationToken)
    {
        var book = new Book()
        {
            Title = request.Book.Title,
            Author = request.Book.Author,
            Description = request.Book.Description
        };
        await _unitOfWork.BookRepository.Add(book);
        await _unitOfWork.IsCompleted();
    
        return book.Id;
    }
}
