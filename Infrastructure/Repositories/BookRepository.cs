using Application.Abstractions;
using Application.Entities;
using TP.Upgrade.Infrastructure.DataManagers;

namespace Infrastructure.Repositories;

internal sealed class BookRepository : GenericRepository<Book>, IBookRepository
{
    public BookRepository(ApplicationDbContext dbContext) : base(dbContext) { }
}
