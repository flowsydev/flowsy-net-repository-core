namespace Flowsy.Repository.Core;

/// <summary>
/// Represents a group of operations to be persisted only when all of them are done successfully.
/// Any changes made during the process shall be rolled back in case of error. 
/// </summary>
public interface IUnitOfWork : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Persists all the changes made in the context of the unit of work.
    /// </summary>
    void Save();
    
    /// <summary>
    /// Asynchronously persists all the changes made in the context of the unit of work.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    Task SaveAsync(CancellationToken cancellationToken);
    
    /// <summary>
    /// Rolls back all the changes made in the context of the unit of work.
    /// This method shall be invoked when disposed.
    /// </summary>
    void Undo();
    
    /// <summary>
    /// Asynchronously rolls back all the changes made in the context of the unit of work.
    /// This method shall be invoked when disposed.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    Task UndoAsync(CancellationToken cancellationToken);
}