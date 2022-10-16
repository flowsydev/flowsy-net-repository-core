namespace Flowsy.Repository.Core;

public abstract class AbstractRepository<TEntity, TIdentity> : IRepository<TEntity, TIdentity> where TEntity : class, IEntity
{
    public virtual string EntityName => typeof(TEntity).Name;
    public virtual string IdentityPropertyName => $"{EntityName}Id";
    
    public virtual Task<TIdentity> CreateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }

    public virtual Task<TIdentity> CreateAsync<T>(T entity, CancellationToken cancellationToken) where T : class
    {
        throw new NotSupportedException();
    }

    public virtual Task<TIdentity> CreateAsync(dynamic entity, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }

    public virtual Task<TIdentity> CreateAsync(IReadOnlyDictionary<string, object?> entityData, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }

    public virtual Task<int> UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }

    public virtual Task<int> UpdateAsync<T>(T entity, CancellationToken cancellationToken) where T : class
    {
        throw new NotSupportedException();
    }

    public virtual Task<int> UpdateAsync(dynamic entity, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }

    public virtual Task<int> UpdateAsync(IReadOnlyDictionary<string, object?> entityData, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }

    public virtual Task<int> PatchAsync(TIdentity id, string propertyName, object value, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }

    public virtual Task<int> PatchAsync(dynamic entity, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }

    public virtual Task<int> PatchAsync(IReadOnlyDictionary<string, object?> entityData, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }

    public virtual Task<int> DeleteByIdAsync(TIdentity identity, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }

    public virtual Task<int> DeleteManyAsync(dynamic filter, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }

    public virtual Task<int> DeleteManyAsync(IReadOnlyDictionary<string, object?> filter, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }

    public virtual Task<TEntity?> GetByIdAsync(TIdentity id, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }

    public virtual Task<T?> GetByIdAsync<T>(TIdentity id, CancellationToken cancellationToken) where T : class
    {
        throw new NotSupportedException();
    }

    public virtual Task<TEntity?> GetByIdExtendedAsync(TIdentity id, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }

    public virtual Task<T?> GetByIdExtendedAsync<T>(TIdentity id, CancellationToken cancellationToken) where T : class
    {
        throw new NotSupportedException();
    }

    public virtual Task<TEntity?> GetOneAsync(dynamic filter, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }

    public virtual Task<TEntity?> GetOneAsync(IReadOnlyDictionary<string, object?> filter, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }

    public virtual Task<T?> GetOneAsync<T>(dynamic filter, CancellationToken cancellationToken) where T : class
    {
        throw new NotSupportedException();
    }

    public virtual Task<T?> GetOneAsync<T>(IReadOnlyDictionary<string, object?> filter, CancellationToken cancellationToken) where T : class
    {
        throw new NotSupportedException();
    }

    public virtual Task<TEntity?> GetOneExtendedAsync(dynamic filter, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }

    public virtual Task<TEntity?> GetOneExtendedAsync(IReadOnlyDictionary<string, object?> filter, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }

    public virtual Task<T?> GetOneExtendedAsync<T>(dynamic filter, CancellationToken cancellationToken) where T : class
    {
        throw new NotSupportedException();
    }

    public virtual Task<T?> GetOneExtendedAsync<T>(IReadOnlyDictionary<string, object?> filter, CancellationToken cancellationToken) where T : class
    {
        throw new NotSupportedException();
    }

    public virtual Task<IEnumerable<TEntity>> GetManyAsync(dynamic filter, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }

    public virtual Task<IEnumerable<TEntity>> GetManyAsync(IReadOnlyDictionary<string, object?> filter, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }

    public virtual Task<IEnumerable<T>> GetManyAsync<T>(dynamic filter, CancellationToken cancellationToken) where T : class
    {
        throw new NotSupportedException();
    }

    public virtual Task<IEnumerable<T>> GetManyAsync<T>(IReadOnlyDictionary<string, object?> filter, CancellationToken cancellationToken) where T : class
    {
        throw new NotSupportedException();
    }

    public virtual Task<IEnumerable<TEntity>> GetManyExtendedAsync(dynamic filter, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }

    public virtual Task<IEnumerable<TEntity>> GetManyExtendedAsync(IReadOnlyDictionary<string, object?> filter, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }

    public virtual Task<IEnumerable<T>> GetManyExtendedAsync<T>(dynamic filter, CancellationToken cancellationToken) where T : class
    {
        throw new NotSupportedException();
    }

    public virtual Task<IEnumerable<T>> GetManyExtendedAsync<T>(IReadOnlyDictionary<string, object?> filter, CancellationToken cancellationToken) where T : class
    {
        throw new NotSupportedException();
    }
}