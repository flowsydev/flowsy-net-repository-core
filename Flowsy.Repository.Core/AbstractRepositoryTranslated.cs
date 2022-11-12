namespace Flowsy.Repository.Core;

public abstract class AbstractRepositoryTranslated<TEntity, TEntityTranslated, TIdentity> 
    : AbstractRepository<TEntity, TIdentity>, IRepositoryTranslated<TEntity, TEntityTranslated, TIdentity>
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
    public virtual Task<T?> GetByIdAsync<T>(TIdentity id, string? cultureId, CancellationToken cancellationToken) where T : class
    {
        throw new NotSupportedException();
    }

    /// <summary>
    /// Gets the translated version of the entity identified by the provided value.
    /// </summary>
    /// <param name="id">The entity identifier</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The entity identified by the provided value or a null value if not found.</returns>    
    public virtual Task<TEntityTranslated?> GetByIdAsync(TIdentity id, string? cultureId, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }

    /// <summary>
    /// Gets the extended and translated version of the entity identified by the provided value.
    /// </summary>
    /// <param name="id">The entity identifier</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="T">Tye type of entity to return.</typeparam>
    /// <returns>The entity identified by the provided value or a null value if not found.</returns>
    public virtual Task<T?> GetByIdExtendedAsync<T>(TIdentity id, string? cultureId, CancellationToken cancellationToken) where T : class
    {
        throw new NotSupportedException();
    }

    /// <summary>
    /// Gets the extended and translated version of the entity identified by the provided value.
    /// </summary>
    /// <param name="id">The entity identifier</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The entity identified by the provided value or a null value if not found.</returns>
    public virtual Task<TEntityTranslated?> GetByIdExtendedAsync(TIdentity id, string? cultureId, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }

    /// <summary>
    /// Gets the translated version of an entity matching the specified criteria.
    /// </summary>
    /// <param name="criteria">An object with properties to be used as criteria to find the entity.</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="T">Tye type of entity to return.</typeparam>
    /// <returns>The entity matching the provided criteria.</returns>
    public virtual Task<T?> GetOneAsync<T>(dynamic criteria, string? cultureId, CancellationToken cancellationToken) where T : class
    {
        throw new NotSupportedException();
    }

    /// <summary>
    /// Gets the translated version of an entity matching the specified criteria.
    /// </summary>
    /// <param name="criteria">The property names and values of an object to be used as criteria to find the entity.</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="T">Tye type of entity to return.</typeparam>
    /// <returns>The entity matching the provided criteria.</returns>
    public virtual Task<T?> GetOneAsync<T>(IReadOnlyDictionary<string, object?> criteria, string? cultureId, CancellationToken cancellationToken) where T : class
    {
        throw new NotSupportedException();
    }

    /// <summary>
    /// Gets the translated version of an entity matching the specified criteria.
    /// </summary>
    /// <param name="criteria">An object with properties to be used as criteria to find the entity.</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The entity matching the provided criteria.</returns>
    public virtual Task<TEntityTranslated?> GetOneAsync(dynamic criteria, string? cultureId, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }

    /// <summary>
    /// Gets the translated version of an entity matching the specified criteria.
    /// </summary>
    /// <param name="criteria">The property names and values of an object to be used as criteria to find the entity.</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The entity matching the provided criteria.</returns>
    public virtual Task<TEntityTranslated?> GetOneAsync(IReadOnlyDictionary<string, object?> criteria, string? cultureId, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }

    /// <summary>
    /// Gets an extended and translated version of an entity matching the specified criteria.
    /// </summary>
    /// <param name="criteria">An object with properties to be used as criteria to find the entity.</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="T">Tye type of entity to return.</typeparam>
    /// <returns>The entity matching the provided criteria.</returns>
    public virtual Task<T?> GetOneExtendedAsync<T>(dynamic criteria, string? cultureId, CancellationToken cancellationToken) where T : class
    {
        throw new NotSupportedException();
    }

    /// <summary>
    /// Gets the extended version of an entity matching the specified criteria.
    /// </summary>
    /// <param name="criteria">The property names and values of an object to be used as criteria to find the entity.</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="T">Tye type of entity to return.</typeparam>
    /// <returns>The entity matching the provided criteria.</returns>
    public virtual Task<T?> GetOneExtendedAsync<T>(IReadOnlyDictionary<string, object?> criteria, string? cultureId, CancellationToken cancellationToken) where T : class
    {
        throw new NotSupportedException();
    }

    /// <summary>
    /// Gets the extended and translated version of an entity matching the specified criteria.
    /// </summary>
    /// <param name="criteria">An object with properties to be used as criteria to find the entity.</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The entity matching the provided criteria.</returns>
    public virtual Task<TEntityTranslated?> GetOneExtendedAsync(dynamic criteria, string? cultureId, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }

    /// <summary>
    /// Gets the extended and translated version of an entity matching the specified criteria.
    /// </summary>
    /// <param name="criteria">An object with properties to be used as criteria to find the entity.</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The entity matching the provided criteria.</returns>
    public virtual Task<TEntityTranslated?> GetOneExtendedAsync(IReadOnlyDictionary<string, object?> criteria, string? cultureId, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }

    /// <summary>
    /// Gets the translated version of one or more entities matching the specified criteria.
    /// </summary>
    /// <param name="criteria">An object with properties to be used as criteria to find the entities.</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="T">Tye type of entity to return.</typeparam>
    /// <returns>The entities matching the provided criteria.</returns>
    public virtual Task<IEnumerable<T>> GetManyAsync<T>(dynamic criteria, string? cultureId, CancellationToken cancellationToken) where T : class
    {
        throw new NotSupportedException();
    }

    /// <summary>
    /// Gets the translated version of one or more entities matching the specified criteria.
    /// </summary>
    /// <param name="criteria">The property names and values of an object to be used as criteria to find the entities.</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="T">Tye type of entity to return.</typeparam>
    /// <returns>The entities matching the provided criteria.</returns>
    public virtual Task<IEnumerable<T>> GetManyAsync<T>(IReadOnlyDictionary<string, object?> criteria, string? cultureId, CancellationToken cancellationToken) where T : class
    {
        throw new NotSupportedException();
    }

    /// <summary>
    /// Gets the translated version of one or more entities matching the specified criteria.
    /// </summary>
    /// <param name="criteria">An object with properties to be used as criteria to find the entities.</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The entities matching the provided criteria.</returns>
    public virtual Task<IEnumerable<TEntityTranslated>> GetManyAsync(dynamic criteria, string? cultureId, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }

    /// <summary>
    /// Gets the translated version of one or more entities matching the specified criteria.
    /// </summary>
    /// <param name="criteria">The property names and values of an object to be used as criteria to find the entities.</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The entities matching the provided criteria.</returns>
    public virtual Task<IEnumerable<TEntityTranslated>> GetManyAsync(IReadOnlyDictionary<string, object?> criteria, string? cultureId, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }

    /// <summary>
    /// Gets a page of the translated version of the entities matching the specified criteria.
    /// </summary>
    /// <param name="query">The criteria and paging options to find the entities.</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="TCriteria">The type of crieteria for the query.</typeparam>
    /// <typeparam name="TResult">The type of the entities expected as the result of the query.</typeparam>
    /// <returns>The page of entities matching the provided criteria.</returns>
    public virtual Task<EntityPageQueryResult<TCriteria, TResult>> GetManyAsync<TCriteria, TResult>(EntityPageQuery<TCriteria> query, string? cultureId, CancellationToken cancellationToken) 
        where TCriteria : class
        where TResult : class
    {
        throw new NotSupportedException();
    }

    /// <summary>
    /// Gets a page of the translated version of the entities matching the specified criteria.
    /// </summary>
    /// <param name="query">The criteria and paging options to find the entities.</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="TCriteria">The type of crieteria for the query.</typeparam>
    /// <returns>The page of entities matching the provided criteria.</returns>
    public virtual Task<EntityPageQueryResult<TCriteria, TEntity>> GetManyAsync<TCriteria>(EntityPageQuery<TCriteria> query, string? cultureId, CancellationToken cancellationToken)
        where TCriteria : class
    {
        throw new NotSupportedException();
    }


    /// <summary>
    /// Gets the extended and translated version of one or more entities matching the specified criteria.
    /// </summary>
    /// <param name="criteria">An object with properties to be used as criteria to find the entities.</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The entities matching the provided criteria.</returns>
    public virtual Task<IEnumerable<T>> GetManyExtendedAsync<T>(dynamic criteria, string? cultureId, CancellationToken cancellationToken) where T : class
    {
        throw new NotSupportedException();
    }

    /// <summary>
    /// Gets the extended and translated version of one or more entities matching the specified criteria.
    /// </summary>
    /// <param name="criteria">The property names and values of an object to be used as criteria to find the entities.</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The entities matching the provided criteria.</returns>
    public virtual Task<IEnumerable<T>> GetManyExtendedAsync<T>(IReadOnlyDictionary<string, object?> criteria, string? cultureId, CancellationToken cancellationToken) where T : class
    {
        throw new NotSupportedException();
    }

    /// <summary>
    /// Gets the extended and translated version of one or more entities matching the specified criteria.
    /// </summary>
    /// <param name="criteria">An object with properties to be used as criteria to find the entities.</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The entities matching the provided criteria.</returns>
    public virtual Task<IEnumerable<TEntityTranslated>> GetManyExtendedAsync(dynamic criteria, string? cultureId, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }

    /// <summary>
    /// Gets the extended and translated version of one or more entities matching the specified criteria.
    /// </summary>
    /// <param name="criteria">The property names and values of an object to be used as criteria to find the entities.</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The entities matching the provided criteria.</returns>
    public virtual Task<IEnumerable<TEntityTranslated>> GetManyExtendedAsync(IReadOnlyDictionary<string, object?> criteria, string? cultureId, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }

    /// <summary>
    /// Gets a page of the extended and translated version of one or more entities matching the specified criteria.
    /// </summary>
    /// <param name="query">The criteria and paging options to find the entities.</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="TCriteria">The type of crieteria for the query.</typeparam>
    /// <typeparam name="TResult">The type of the entities expected as the result of the query.</typeparam>
    /// <returns>The page of entities matching the provided criteria.</returns>
    public virtual Task<EntityPageQueryResult<TCriteria, TResult>> GetManyExtendedAsync<TCriteria, TResult>(EntityPageQuery<TCriteria> query, string? cultureId, CancellationToken cancellationToken)
        where TCriteria : class
        where TResult : class
    {
        throw new NotSupportedException();
    }

    /// <summary>
    /// Gets a page of the extended and translated version of one or more entities matching the specified criteria.
    /// </summary>
    /// <param name="query">The criteria and paging options to find the entities.</param>
    /// <param name="cultureId">The culture identifier.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="TCriteria">The type of crieteria for the query.</typeparam>
    /// <returns>The page of entities matching the provided criteria.</returns>
    public virtual Task<EntityPageQueryResult<TCriteria, TEntity>> GetManyExtendedAsync<TCriteria>(EntityPageQuery<TCriteria> query, string? cultureId, CancellationToken cancellationToken)
        where TCriteria : class
    {
        throw new NotSupportedException();
    }
}