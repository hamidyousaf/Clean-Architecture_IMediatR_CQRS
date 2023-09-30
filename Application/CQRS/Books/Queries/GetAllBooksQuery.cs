using Application.Entities;
using MediatR;

namespace Application.CQRS.Books.Queries;

public sealed class GetAllBooksQuery : IRequest<List<Book>>
{
}
