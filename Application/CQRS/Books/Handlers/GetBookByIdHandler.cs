using Application.Abstractions.UnitOfWork;
using Application.CQRS.Books.Queries;
using Application.DTOs.ProjectToDTOs;
using Application.Entities;
using Application.Extensions.ProjectTo;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Books.Handlers;

public sealed class GetBookByIdHandler : IRequestHandler<GetBookByIdQuery, BookProjectTo_V1?>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetBookByIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<BookProjectTo_V1?> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        var book = await _unitOfWork
            .BookRepository
            .GetAll()
            .ProjectTo_V1()
            .FirstOrDefaultAsync(x => x.Id == request.BookId, cancellationToken);

        return book;
    }
}
