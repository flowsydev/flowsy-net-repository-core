namespace Flowsy.Repository.Core;

/// <summary>
/// Represents a repository that can retrieve translated versions of its entities.
/// </summary>
/// <typeparam name="TEntity">The entity type.</typeparam>
/// <typeparam name="TEntityTranslated">The translated entity type</typeparam>
/// <typeparam name="TIdentity">The identity type.</typeparam>
public interface IRepositoryTranslated<TEntity, TEntityTranslated, TIdentity> :
    IRepository<TEntity, TIdentity>
    where TEntity : class, IEntity
    where TEntityTranslated : TEntity, IEntityTranslated
{
    /// <summary>
    /// Gets the translated version of the entity identified by the provided value.
    /// </summary>
    /// <param name="id">The entity identifier</param>
    /// /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="T">Tye type of entity to return.</typeparam>
    /// <returns>The entity identified by the provided value or a null value if not found.</returns>
    Task<T?> GetByIdAsync<T>(TIdentity id, string? cultureId, CancellationToken cancellationToken) where T : class;
    
    /// <summary>
    /// Gets the translated version of the entity identified by the provided value.
    /// </summary>
    /// <param name="id">The entity identifier</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The entity identified by the provided value or a null value if not found.</returns>
    Task<TEntityTranslated?> GetByIdAsync(TIdentity id, string? cultureId, CancellationToken cancellationToken);
    
    /// <summary>
    /// Gets the extended and translated version of the entity identified by the provided value.
    /// </summary>
    /// <param name="id">The entity identifier</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="T">Tye type of entity to return.</typeparam>
    /// <returns>The entity identified by the provided value or a null value if not found.</returns>
    Task<T?> GetByIdExtendedAsync<T>(TIdentity id, string? cultureId, CancellationToken cancellationToken) where T : class;
    
    /// <summary>
    /// Gets the extended and translated version of the entity identified by the provided value.
    /// </summary>
    /// <param name="id">The entity identifier</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The entity identified by the provided value or a null value if not found.</returns>
    Task<TEntityTranslated?> GetByIdExtendedAsync(TIdentity id, string? cultureId, CancellationToken cancellationToken);

    /// <summary>
    /// Gets the translated version of an entity matching the specified filter.
    /// </summary>
    /// <param name="filter">An object with properties to be used as a filter to find the entity.</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="T">Tye type of entity to return.</typeparam>
    /// <returns>The entity matching the provided filter.</returns>
    Task<T?> GetOneAsync<T>(dynamic filter, string? cultureId, CancellationToken cancellationToken) where T : class;
    
    /// <summary>
    /// Gets the translated version of an entity matching the specified filter.
    /// </summary>
    /// <param name="filter">The property names and values of an object to be used as a filter to find the entity.</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="T">Tye type of entity to return.</typeparam>
    /// <returns>The entity matching the provided filter.</returns>
    Task<T?> GetOneAsync<T>(IReadOnlyDictionary<string, object?> filter, string? cultureId, CancellationToken cancellationToken) where T : class;
    
    /// <summary>
    /// Gets the translated version of an entity matching the specified filter.
    /// </summary>
    /// <param name="filter">An object with properties to be used as a filter to find the entity.</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The entity matching the provided filter.</returns>
    Task<TEntityTranslated?> GetOneAsync(dynamic filter, string? cultureId, CancellationToken cancellationToken);
    
    /// <summary>
    /// Gets the translated version of an entity matching the specified filter.
    /// </summary>
    /// <param name="filter">The property names and values of an object to be used as a filter to find the entity.</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The entity matching the provided filter.</returns>
    Task<TEntityTranslated?> GetOneAsync(IReadOnlyDictionary<string, object?> filter, string? cultureId, CancellationToken cancellationToken);
    
    /// <summary>
    /// Gets an extended and translated version of an entity matching the specified filter.
    /// </summary>
    /// <param name="filter">An object with properties to be used as a filter to find the entity.</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="T">Tye type of entity to return.</typeparam>
    /// <returns>The entity matching the provided filter.</returns>
    Task<T?> GetOneExtendedAsync<T>(dynamic filter, string? cultureId, CancellationToken cancellationToken) where T : class;
    
    /// <summary>
    /// Gets the extended version of an entity matching the specified filter.
    /// </summary>
    /// <param name="filter">The property names and values of an object to be used as a filter to find the entity.</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="T">Tye type of entity to return.</typeparam>
    /// <returns>The entity matching the provided filter.</returns>
    Task<T?> GetOneExtendedAsync<T>(IReadOnlyDictionary<string, object?> filter, string? cultureId, CancellationToken cancellationToken) where T : class;
    
    /// <summary>
    /// Gets the extended and translated version of an entity matching the specified filter.
    /// </summary>
    /// <param name="filter">An object with properties to be used as a filter to find the entity.</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The entity matching the provided filter.</returns>
    Task<TEntityTranslated?> GetOneExtendedAsync(dynamic filter, string? cultureId, CancellationToken cancellationToken);
    
    /// <summary>
    /// Gets the extended and translated version of an entity matching the specified filter.
    /// </summary>
    /// <param name="filter">An object with properties to be used as a filter to find the entity.</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The entity matching the provided filter.</returns>
    Task<TEntityTranslated?> GetOneExtendedAsync(IReadOnlyDictionary<string, object?> filter, string? cultureId, CancellationToken cancellationToken);
    
    /// <summary>
    /// Gets the translated version of one or more entities matching the specified filter.
    /// </summary>
    /// <param name="filter">An object with properties to be used as a filter to find the entities.</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="T">Tye type of entity to return.</typeparam>
    /// <returns>The entities matching the provided filter.</returns>
    Task<IEnumerable<T>> GetManyAsync<T>(dynamic filter, string? cultureId, CancellationToken cancellationToken) where T : class;
    
    /// <summary>
    /// Gets the translated version of one or more entities matching the specified filter.
    /// </summary>
    /// <param name="filter">The property names and values of an object to be used as a filter to find the entities.</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="T">Tye type of entity to return.</typeparam>
    /// <returns>The entities matching the provided filter.</returns>
    Task<IEnumerable<T>> GetManyAsync<T>(IReadOnlyDictionary<string, object?> filter, string? cultureId, CancellationToken cancellationToken) where T : class;
    
    /// <summary>
    /// Gets the translated version of one or more entities matching the specified filter.
    /// </summary>
    /// <param name="filter">An object with properties to be used as a filter to find the entities.</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The entities matching the provided filter.</returns>
    Task<IEnumerable<TEntityTranslated>> GetManyAsync(dynamic filter, string? cultureId, CancellationToken cancellationToken);
    
    /// <summary>
    /// Gets the translated version of one or more entities matching the specified filter.
    /// </summary>
    /// <param name="filter">The property names and values of an object to be used as a filter to find the entities.</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The entities matching the provided filter.</returns>
    Task<IEnumerable<TEntityTranslated>> GetManyAsync(IReadOnlyDictionary<string, object?> filter, string? cultureId, CancellationToken cancellationToken);

    /// <summary>
    /// Gets the extended and translated version of one or more entities matching the specified filter.
    /// </summary>
    /// <param name="filter">An object with properties to be used as a filter to find the entities.</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The entities matching the provided filter.</returns>
    Task<IEnumerable<T>> GetManyExtendedAsync<T>(dynamic filter, string? cultureId, CancellationToken cancellationToken) where T : class;
    
    /// <summary>
    /// Gets the extended and translated version of one or more entities matching the specified filter.
    /// </summary>
    /// <param name="filter">The property names and values of an object to be used as a filter to find the entities.</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The entities matching the provided filter.</returns>
    Task<IEnumerable<T>> GetManyExtendedAsync<T>(IReadOnlyDictionary<string, object?> filter, string? cultureId, CancellationToken cancellationToken) where T : class;
    
    /// <summary>
    /// Gets the extended and translated version of one or more entities matching the specified filter.
    /// </summary>
    /// <param name="filter">An object with properties to be used as a filter to find the entities.</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The entities matching the provided filter.</returns>
    Task<IEnumerable<TEntityTranslated>> GetManyExtendedAsync(dynamic filter, string? cultureId, CancellationToken cancellationToken);

    /// <summary>
    /// Gets the extended and translated version of one or more entities matching the specified filter.
    /// </summary>
    /// <param name="filter">The property names and values of an object to be used as a filter to find the entities.</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The entities matching the provided filter.</returns>
    Task<IEnumerable<TEntityTranslated>> GetManyExtendedAsync(IReadOnlyDictionary<string, object?> filter, string? cultureId, CancellationToken cancellationToken);
}