namespace Flowsy.Repository.Core;

/// <summary>
/// Represents a group of operations to be persisted only when all of them are done successfully.
/// Any changes made during the process shall be rolled back in case of error. 
/// </summary>
public interface IUnitOfWork : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Persists all the changes made during the unit of work.
    /// </summary>
    void Commit();
    
    /// <summary>
    /// Asynchronously persists all the changes made during the unit of work.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    Task CommitAsync(CancellationToken cancellationToken);
}