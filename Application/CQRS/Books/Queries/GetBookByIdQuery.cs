using Application.DTOs.ProjectToDTOs;
using Application.Entities;
using MediatR;

namespace Application.CQRS.Books.Queries;
public sealed class GetBookByIdQuery : IRequest<BookProjectTo_V1>
{
    public int BookId { get; }
    public GetBookByIdQuery(int bookId)
    {
        BookId = bookId;
    }
}
