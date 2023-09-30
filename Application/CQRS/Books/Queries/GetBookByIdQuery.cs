using Application.DTOs.ProjectToDTOs;
using Application.DTOs.Responces;
using MediatR;

namespace Application.CQRS.Books.Queries;
public sealed class GetBookByIdQuery : IRequest<Result<BookProjectTo_V1>>
{
    public int BookId { get; }
    public GetBookByIdQuery(int bookId)
    {
        BookId = bookId;
    }
}
