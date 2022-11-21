namespace Flowsy.Repository.Core;

/// <summary>
/// Represents a repository that can retrieve translated versions of its entities.
/// </summary>
/// <typeparam name="TEntity">The entity type.</typeparam>
/// <typeparam name="TEntityTranslated">The type of the translated entity.</typeparam>
/// <typeparam name="TIdentity">The identity type.</typeparam>
public  interface IRepository<TEntity, TEntityTranslated, TIdentity>
    : IRepository<TEntity, TIdentity>
    where TEntity : class, IEntity
    where TEntityTranslated : class, TEntity, IEntityTranslation
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
    /// Gets the translated version of an entity matching the specified criteria.
    /// </summary>
    /// <param name="criteria">An object with properties to be used as criteria to find the entity.</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="T">Tye type of entity to return.</typeparam>
    /// <returns>The entity matching the provided criteria.</returns>
    Task<T?> GetOneAsync<T>(dynamic criteria, string? cultureId, CancellationToken cancellationToken) where T : class;
    
    /// <summary>
    /// Gets the translated version of an entity matching the specified criteria.
    /// </summary>
    /// <param name="criteria">The property names and values of an object to be used as criteria to find the entity.</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="T">Tye type of entity to return.</typeparam>
    /// <returns>The entity matching the provided criteria.</returns>
    Task<T?> GetOneAsync<T>(IReadOnlyDictionary<string, object?> criteria, string? cultureId, CancellationToken cancellationToken) where T : class;
    
    /// <summary>
    /// Gets the translated version of an entity matching the specified criteria.
    /// </summary>
    /// <param name="criteria">An object with properties to be used as criteria to find the entity.</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The entity matching the provided criteria.</returns>
    Task<TEntityTranslated?> GetOneAsync(dynamic criteria, string? cultureId, CancellationToken cancellationToken);
    
    /// <summary>
    /// Gets the translated version of an entity matching the specified criteria.
    /// </summary>
    /// <param name="criteria">The property names and values of an object to be used as criteria to find the entity.</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The entity matching the provided criteria.</returns>
    Task<TEntityTranslated?> GetOneAsync(IReadOnlyDictionary<string, object?> criteria, string? cultureId, CancellationToken cancellationToken);
    
    /// <summary>
    /// Gets an extended and translated version of an entity matching the specified criteria.
    /// </summary>
    /// <param name="criteria">An object with properties to be used as criteria to find the entity.</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="T">Tye type of entity to return.</typeparam>
    /// <returns>The entity matching the provided criteria.</returns>
    Task<T?> GetOneExtendedAsync<T>(dynamic criteria, string? cultureId, CancellationToken cancellationToken) where T : class;
    
    /// <summary>
    /// Gets the extended version of an entity matching the specified criteria.
    /// </summary>
    /// <param name="criteria">The property names and values of an object to be used as criteria to find the entity.</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="T">Tye type of entity to return.</typeparam>
    /// <returns>The entity matching the provided criteria.</returns>
    Task<T?> GetOneExtendedAsync<T>(IReadOnlyDictionary<string, object?> criteria, string? cultureId, CancellationToken cancellationToken) where T : class;
    
    /// <summary>
    /// Gets the extended and translated version of an entity matching the specified criteria.
    /// </summary>
    /// <param name="criteria">An object with properties to be used as criteria to find the entity.</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The entity matching the provided criteria.</returns>
    Task<TEntityTranslated?> GetOneExtendedAsync(dynamic criteria, string? cultureId, CancellationToken cancellationToken);
    
    /// <summary>
    /// Gets the extended and translated version of an entity matching the specified criteria.
    /// </summary>
    /// <param name="criteria">An object with properties to be used as criteria to find the entity.</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The entity matching the provided criteria.</returns>
    Task<TEntityTranslated?> GetOneExtendedAsync(IReadOnlyDictionary<string, object?> criteria, string? cultureId, CancellationToken cancellationToken);
    
    /// <summary>
    /// Gets the translated version of one or more entities matching the specified criteria.
    /// </summary>
    /// <param name="criteria">An object with properties to be used as criteria to find the entities.</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="T">Tye type of entity to return.</typeparam>
    /// <returns>The entities matching the provided criteria.</returns>
    Task<IEnumerable<T>> GetManyAsync<T>(dynamic criteria, string? cultureId, CancellationToken cancellationToken) where T : class;
    
    /// <summary>
    /// Gets the translated version of one or more entities matching the specified criteria.
    /// </summary>
    /// <param name="criteria">The property names and values of an object to be used as criteria to find the entities.</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="T">Tye type of entity to return.</typeparam>
    /// <returns>The entities matching the provided criteria.</returns>
    Task<IEnumerable<T>> GetManyAsync<T>(IReadOnlyDictionary<string, object?> criteria, string? cultureId, CancellationToken cancellationToken) where T : class;
    
    /// <summary>
    /// Gets the translated version of one or more entities matching the specified criteria.
    /// </summary>
    /// <param name="criteria">An object with properties to be used as criteria to find the entities.</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The entities matching the provided criteria.</returns>
    Task<IEnumerable<TEntityTranslated>> GetManyAsync(dynamic criteria, string? cultureId, CancellationToken cancellationToken);
    
    /// <summary>
    /// Gets the translated version of one or more entities matching the specified criteria.
    /// </summary>
    /// <param name="criteria">The property names and values of an object to be used as criteria to find the entities.</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The entities matching the provided criteria.</returns>
    Task<IEnumerable<TEntityTranslated>> GetManyAsync(IReadOnlyDictionary<string, object?> criteria, string? cultureId, CancellationToken cancellationToken);

    /// <summary>
    /// Gets a page of the translated version of the entities matching the specified criteria.
    /// </summary>
    /// <param name="query">The criteria and paging options to find the entities.</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="TCriteria">The type of crieteria for the query.</typeparam>
    /// <typeparam name="TResult">The type of the entities expected as the result of the query.</typeparam>
    /// <returns>The page of entities matching the provided criteria.</returns>
    Task<EntityPageQueryResult<TCriteria, TResult>> GetPageAsync<TCriteria, TResult>(EntityPageQuery<TCriteria> query, string? cultureId, CancellationToken cancellationToken) 
        where TCriteria : class
        where TResult : class;

    /// <summary>
    /// Gets a page of the translated version of the entities matching the specified criteria.
    /// </summary>
    /// <param name="query">The criteria and paging options to find the entities.</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="TCriteria">The type of crieteria for the query.</typeparam>
    /// <returns>The page of entities matching the provided criteria.</returns>
    Task<EntityPageQueryResult<TCriteria, TEntityTranslated>> GetPageAsync<TCriteria>(EntityPageQuery<TCriteria> query, string? cultureId, CancellationToken cancellationToken)
        where TCriteria : class;

    /// <summary>
    /// Gets the extended and translated version of one or more entities matching the specified criteria.
    /// </summary>
    /// <param name="criteria">An object with properties to be used as criteria to find the entities.</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The entities matching the provided criteria.</returns>
    Task<IEnumerable<T>> GetManyExtendedAsync<T>(dynamic criteria, string? cultureId, CancellationToken cancellationToken) where T : class;
    
    /// <summary>
    /// Gets the extended and translated version of one or more entities matching the specified criteria.
    /// </summary>
    /// <param name="criteria">The property names and values of an object to be used as criteria to find the entities.</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The entities matching the provided criteria.</returns>
    Task<IEnumerable<T>> GetManyExtendedAsync<T>(IReadOnlyDictionary<string, object?> criteria, string? cultureId, CancellationToken cancellationToken) where T : class;
    
    /// <summary>
    /// Gets the extended and translated version of one or more entities matching the specified criteria.
    /// </summary>
    /// <param name="criteria">An object with properties to be used as criteria to find the entities.</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The entities matching the provided criteria.</returns>
    Task<IEnumerable<TEntityTranslated>> GetManyExtendedAsync(dynamic criteria, string? cultureId, CancellationToken cancellationToken);

    /// <summary>
    /// Gets the extended and translated version of one or more entities matching the specified criteria.
    /// </summary>
    /// <param name="criteria">The property names and values of an object to be used as criteria to find the entities.</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The entities matching the provided criteria.</returns>
    Task<IEnumerable<TEntityTranslated>> GetManyExtendedAsync(IReadOnlyDictionary<string, object?> criteria, string? cultureId, CancellationToken cancellationToken);

    /// <summary>
    /// Gets a page of the extended and translated version of one or more entities matching the specified criteria.
    /// </summary>
    /// <param name="query">The criteria and paging options to find the entities.</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="TCriteria">The type of crieteria for the query.</typeparam>
    /// <typeparam name="TResult">The type of the entities expected as the result of the query.</typeparam>
    /// <returns>The page of entities matching the provided criteria.</returns>
    Task<EntityPageQueryResult<TCriteria, TResult>> GetPageExtendedAsync<TCriteria, TResult>(EntityPageQuery<TCriteria> query, string? cultureId, CancellationToken cancellationToken)
        where TCriteria : class
        where TResult : class;

    /// <summary>
    /// Gets a page of the extended and translated version of one or more entities matching the specified criteria.
    /// </summary>
    /// <param name="query">The criteria and paging options to find the entities.</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="TCriteria">The type of crieteria for the query.</typeparam>
    /// <returns>The page of entities matching the provided criteria.</returns>
    Task<EntityPageQueryResult<TCriteria, TEntityTranslated>> GetPageExtendedAsync<TCriteria>(EntityPageQuery<TCriteria> query, string? cultureId, CancellationToken cancellationToken)
        where TCriteria : class;
}