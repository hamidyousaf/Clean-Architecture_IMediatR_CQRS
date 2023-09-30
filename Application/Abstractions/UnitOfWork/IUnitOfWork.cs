namespace Application.Abstractions.UnitOfWork;

public interface IUnitOfWork
{
    #region Add repositories here
    IBookRepository BookRepository { get; }
    #endregion
    Task<bool> IsCompleted();
    bool HasChanges();

}
