using Application.Abstractions.GenericRepository;
using Application.Entities;

namespace Application.Abstractions;

public interface IBookRepository : IGenericRepository<Book>
{
}
