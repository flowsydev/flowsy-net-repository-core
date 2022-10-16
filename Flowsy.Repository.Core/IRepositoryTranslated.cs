namespace Flowsy.Repository.Core;

public interface IRepositoryTranslated<TEntity, TTranslatedEntity, TIdentity> :
    IRepository<TEntity, TIdentity>
    where TEntity : class, IEntity
    where TTranslatedEntity : TEntity, IEntityTranslated
{
    Task<T?> GetByIdAsync<T>(TIdentity id, string? cultureId, CancellationToken cancellationToken) where T : class;
    Task<TTranslatedEntity?> GetByIdAsync(TIdentity id, string? cultureId, CancellationToken cancellationToken);
    
    Task<T?> GetByIdExtendedAsync<T>(TIdentity id, string? cultureId, CancellationToken cancellationToken) where T : class;
    Task<TTranslatedEntity?> GetByIdExtendedAsync(TIdentity id, string? cultureId, CancellationToken cancellationToken);
    
    Task<T?> GetOneAsync<T>(dynamic filter, string? cultureId, CancellationToken cancellationToken) where T : class;
    Task<T?> GetOneAsync<T>(IReadOnlyDictionary<string, object?> filter, string? cultureId, CancellationToken cancellationToken) where T : class;
    Task<TTranslatedEntity?> GetOneAsync(dynamic filter, string? cultureId, CancellationToken cancellationToken);
    Task<TTranslatedEntity?> GetOneAsync(IReadOnlyDictionary<string, object?> filter, string? cultureId, CancellationToken cancellationToken);
    
    Task<T?> GetOneExtendedAsync<T>(dynamic filter, string? cultureId, CancellationToken cancellationToken) where T : class;
    Task<T?> GetOneExtendedAsync<T>(IReadOnlyDictionary<string, object?> filter, string? cultureId, CancellationToken cancellationToken) where T : class;
    Task<TTranslatedEntity?> GetOneExtendedAsync(dynamic filter, string? cultureId, CancellationToken cancellationToken);
    Task<TTranslatedEntity?> GetOneExtendedAsync(IReadOnlyDictionary<string, object?> filter, string? cultureId, CancellationToken cancellationToken);
    
    Task<IEnumerable<T>> GetManyAsync<T>(dynamic filter, string? cultureId, CancellationToken cancellationToken) where T : class;
    Task<IEnumerable<T>> GetManyAsync<T>(IReadOnlyDictionary<string, object?> filter, string? cultureId, CancellationToken cancellationToken) where T : class;
    Task<IEnumerable<TTranslatedEntity>> GetManyAsync(dynamic filter, string? cultureId, CancellationToken cancellationToken);
    Task<IEnumerable<TTranslatedEntity>> GetManyAsync(IReadOnlyDictionary<string, object?> filter, string? cultureId, CancellationToken cancellationToken);

    Task<IEnumerable<T>> GetManyExtendedAsync<T>(dynamic filter, string? cultureId, CancellationToken cancellationToken) where T : class;
    Task<IEnumerable<T>> GetManyExtendedAsync<T>(IReadOnlyDictionary<string, object?> filter, string? cultureId, CancellationToken cancellationToken) where T : class;
    Task<IEnumerable<TTranslatedEntity>> GetManyExtendedAsync(IReadOnlyDictionary<string, object?> filter, string? cultureId, CancellationToken cancellationToken);
    Task<IEnumerable<TTranslatedEntity>> GetManyExtendedAsync(dynamic filter, string? cultureId, CancellationToken cancellationToken);
}