using Application.Abstractions.UnitOfWork;
using Application.CQRS.Books.Queries;
using Application.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Books.Handlers;

public sealed class GetAllBooksHandler : IRequestHandler<GetAllBooksQuery, List<Book>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllBooksHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    async Task<List<Book>> IRequestHandler<GetAllBooksQuery, List<Book>>.Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.BookRepository
            .GetAll()
            .ToListAsync(cancellationToken);
        return result;
    }
}
