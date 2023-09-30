using Application.Abstractions;
using Application.Abstractions.UnitOfWork;

namespace Infrastructure.Repositories.UnitOfWork;

internal class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;

    public UnitOfWork(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public IBookRepository BookRepository => new BookRepository(_dbContext);

    public bool HasChanges()
    {
        return _dbContext.ChangeTracker.HasChanges();
    }

    public async Task<bool> IsCompleted()
    {
        return await _dbContext.SaveChangesAsync() > 0;
    }
}
