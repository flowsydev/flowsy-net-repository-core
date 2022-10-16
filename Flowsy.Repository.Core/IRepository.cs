namespace Flowsy.Repository.Core;

public interface IRepository
{
}

public interface IRepository<TEntity, TIdentity> : IRepository where TEntity : class, IEntity
{
    string EntityName { get; }
    string IdentityPropertyName { get; }
    
    Task<TIdentity> CreateAsync(TEntity entity, CancellationToken cancellationToken);
    Task<TIdentity> CreateAsync<T>(T entity, CancellationToken cancellationToken) where T : class;
    Task<TIdentity> CreateAsync(dynamic entity, CancellationToken cancellationToken);
    Task<TIdentity> CreateAsync(IReadOnlyDictionary<string, object?> entityData, CancellationToken cancellationToken);
    
    Task<int> UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    Task<int> UpdateAsync<T>(T entity, CancellationToken cancellationToken) where T : class;
    Task<int> UpdateAsync(dynamic entity, CancellationToken cancellationToken);
    Task<int> UpdateAsync(IReadOnlyDictionary<string, object?> entityData, CancellationToken cancellationToken);
    
    Task<int> PatchAsync(TIdentity id, string propertyName, object value, CancellationToken cancellationToken);
    Task<int> PatchAsync(dynamic entity, CancellationToken cancellationToken);
    Task<int> PatchAsync(IReadOnlyDictionary<string, object?> entityData, CancellationToken cancellationToken);
    
    Task<int> DeleteByIdAsync(TIdentity identity, CancellationToken cancellationToken);
    Task<int> DeleteManyAsync(dynamic filter, CancellationToken cancellationToken);
    Task<int> DeleteManyAsync(IReadOnlyDictionary<string, object?> filter, CancellationToken cancellationToken);
    
    Task<TEntity?> GetByIdAsync(TIdentity id, CancellationToken cancellationToken);
    Task<T?> GetByIdAsync<T>(TIdentity id, CancellationToken cancellationToken) where T : class;

    Task<TEntity?> GetByIdExtendedAsync(TIdentity id, CancellationToken cancellationToken);
    Task<T?> GetByIdExtendedAsync<T>(TIdentity id, CancellationToken cancellationToken) where T : class;
    
    Task<TEntity?> GetOneAsync(dynamic filter, CancellationToken cancellationToken);
    Task<TEntity?> GetOneAsync(IReadOnlyDictionary<string, object?> filter, CancellationToken cancellationToken);
    Task<T?> GetOneAsync<T>(dynamic filter, CancellationToken cancellationToken) where T : class;
    Task<T?> GetOneAsync<T>(IReadOnlyDictionary<string, object?> filter, CancellationToken cancellationToken) where T : class;
    
    Task<TEntity?> GetOneExtendedAsync(dynamic filter, CancellationToken cancellationToken);
    Task<TEntity?> GetOneExtendedAsync(IReadOnlyDictionary<string, object?> filter, CancellationToken cancellationToken);
    Task<T?> GetOneExtendedAsync<T>(dynamic filter, CancellationToken cancellationToken) where T : class;
    Task<T?> GetOneExtendedAsync<T>(IReadOnlyDictionary<string, object?> filter, CancellationToken cancellationToken) where T : class;

    Task<IEnumerable<TEntity>> GetManyAsync(dynamic filter, CancellationToken cancellationToken);
    Task<IEnumerable<TEntity>> GetManyAsync(IReadOnlyDictionary<string, object?> filter, CancellationToken cancellationToken);
    Task<IEnumerable<T>> GetManyAsync<T>(dynamic filter, CancellationToken cancellationToken) where T : class;
    Task<IEnumerable<T>> GetManyAsync<T>(IReadOnlyDictionary<string, object?> filter, CancellationToken cancellationToken) where T : class;

    Task<IEnumerable<TEntity>> GetManyExtendedAsync(dynamic filter, CancellationToken cancellationToken);
    Task<IEnumerable<TEntity>> GetManyExtendedAsync(IReadOnlyDictionary<string, object?> filter, CancellationToken cancellationToken);
    Task<IEnumerable<T>> GetManyExtendedAsync<T>(dynamic filter, CancellationToken cancellationToken) where T : class;
    Task<IEnumerable<T>> GetManyExtendedAsync<T>(IReadOnlyDictionary<string, object?> filter, CancellationToken cancellationToken) where T : class;
}