using Application.Abstractions.UnitOfWork;
using Application.CQRS.Books.Queries;
using Application.DTOs.ProjectToDTOs;
using Application.DTOs.Responces;
using Application.Extensions.ProjectTo;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Books.Handlers;

public sealed class GetAllBooksHandler : IRequestHandler<GetAllBooksQuery, Result<List<BookProjectTo_V1>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllBooksHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    async Task<Result<List<BookProjectTo_V1>>> IRequestHandler<GetAllBooksQuery, Result<List<BookProjectTo_V1>>>.Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.BookRepository
            .GetAllReadOnly()
            .ProjectTo_V1()
            .ToListAsync(cancellationToken);

        return Result<List<BookProjectTo_V1>>.Success(result);
    }
}
