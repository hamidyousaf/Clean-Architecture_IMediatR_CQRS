using Application.DTOs.ProjectToDTOs;
using Application.DTOs.Responces;
using Application.Entities;
using MediatR;

namespace Application.CQRS.Books.Queries;

public sealed class GetAllBooksQuery : IRequest<Result<List<BookProjectTo_V1>>>
{
}
