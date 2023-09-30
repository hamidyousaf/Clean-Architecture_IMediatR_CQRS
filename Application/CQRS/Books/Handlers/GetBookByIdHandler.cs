using Application.Abstractions.UnitOfWork;
using Application.CQRS.Books.Queries;
using Application.DTOs.ProjectToDTOs;
using Application.DTOs.Responces;
using Application.Entities;
using Application.Extensions.ProjectTo;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Books.Handlers;

public sealed class GetBookByIdHandler : IRequestHandler<GetBookByIdQuery, Result<BookProjectTo_V1>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetBookByIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<BookProjectTo_V1>> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        var book = await _unitOfWork.BookRepository
            .GetAllReadOnly()
            .ProjectTo_V1()
            .FirstOrDefaultAsync(x => x.Id == request.BookId, cancellationToken);

        if (book is null)
        {
            return Result<BookProjectTo_V1>.Fail($"There is no book found with id: {request.BookId}");
        }

        return Result<BookProjectTo_V1>.Success(book);
    }
}
