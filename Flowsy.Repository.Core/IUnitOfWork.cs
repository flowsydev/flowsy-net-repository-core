namespace Flowsy.Repository.Core;

public interface IUnitOfWork : IDisposable, IAsyncDisposable
{
    void Commit();
    Task CommitAsync(CancellationToken cancellationToken);
}