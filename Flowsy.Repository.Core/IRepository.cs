namespace Flowsy.Repository.Core;

/// <summary>
/// Represents an entity repository.
/// </summary>
public interface IRepository
{
}

/// <summary>
/// Defines the behavior of a repository for storing, retrieving, updating and deleting entities.
/// </summary>
/// <typeparam name="TEntity">The type of entity handled by the repository.</typeparam>
/// <typeparam name="TIdentity">The type of the property that uniquely identifies each entity of the repository.</typeparam>
public interface IRepository<TEntity, TIdentity> : IRepository where TEntity : class, IEntity
{
    /// <summary>
    /// A string to identify the type of entity handled for the repository.
    /// It is highly recommended to stick to a PascalCase convention, so specific implementations will be able to perform tasks in a consistent way.
    /// The entity name can be thought of as the noun used to describe that real world object or concept being modeled: Product, Customer, Invoice, PurchaseOrder, etc.
    /// The simplest way to implement this property would be to return the value of typeof(TEntity).Name. 
    /// </summary>
    string EntityName { get; }
    
    /// <summary>
    /// The name of the property that holds unique identifiers for entities of the repository.
    /// It is highly recommended to use consistent values in PascalCase format for all of the entities handled by the application.
    /// The simplest way to implement this property would be to return the value of $"{EntityName}Id" or something of the sort.
    /// </summary>
    string IdentityPropertyName { get; }
    
    /// <summary>
    /// Creates a new entity in the underlying data store.
    /// </summary>
    /// <param name="entity">The entity to be created.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="T">The type of the entity.</typeparam>
    /// <returns>The identifier of the new entity.</returns>
    Task<TIdentity> CreateAsync<T>(T entity, CancellationToken cancellationToken) where T : class;
    
    /// <summary>
    /// Creates a new entity in the underlying data store.
    /// </summary>
    /// <param name="entity">The entity to be created.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The identifier of the new entity.</returns>
    Task<TIdentity> CreateAsync(TEntity entity, CancellationToken cancellationToken);

    /// <summary>
    /// Creates a new entity in the underlying data store.
    /// </summary>
    /// <param name="entity">The entity to be created.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The identifier of the new entity.</returns>
    Task<TIdentity> CreateAsync(dynamic entity, CancellationToken cancellationToken);
    
    /// <summary>
    /// Creates a new entity in the underlying data store.
    /// </summary>
    /// <param name="properties">The property names and values of the entity to be created.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The identifier of the new entity.</returns>
    Task<TIdentity> CreateAsync(IReadOnlyDictionary<string, object?> properties, CancellationToken cancellationToken);
    
    /// <summary>
    /// Updates an entitiy in the underlying data store.
    /// </summary>
    /// <param name="entity">The entity to be updated.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="T">The type of the entity.</typeparam>
    /// <returns>The number of affected entities.</returns>
    Task<int> UpdateAsync<T>(T entity, CancellationToken cancellationToken) where T : class;
    
    /// <summary>
    /// Updates an entitiy in the underlying data store.
    /// </summary>
    /// <param name="entity">The entity to be updated.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The number of affected entities.</returns>
    Task<int> UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    
    /// <summary>
    /// Updates an entitiy in the underlying data store.
    /// </summary>
    /// <param name="entity">The entity to be updated.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The number of affected entities.</returns>
    Task<int> UpdateAsync(dynamic entity, CancellationToken cancellationToken);
    
    /// <summary>
    /// Updates an entitiy in the underlying data store.
    /// </summary>
    /// <param name="properties">The property names and values of the entity to be updated.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The number of affected entities.</returns>
    Task<int> UpdateAsync(IReadOnlyDictionary<string, object?> properties, CancellationToken cancellationToken);
    
    /// <summary>
    /// Updates only one property of the entity identified by the provided value.
    /// </summary>
    /// <param name="id">The entity identifier.</param>
    /// <param name="propertyName">The name of the property to be updated.</param>
    /// <param name="value">The new value for the property to be updated.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The number of affected entities.</returns>
    Task<int> PatchAsync(TIdentity id, string propertyName, object value, CancellationToken cancellationToken);
    
    /// <summary>
    /// Updates only certain properties of an entity.
    /// </summary>
    /// <param name="entity">An object with properties used to identify and update an entity.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The number of affected entities.</returns>
    Task<int> PatchAsync(dynamic entity, CancellationToken cancellationToken);
    
    /// <summary>
    /// Updates only certain properties of an entity.
    /// </summary>
    /// <param name="properties">The property names and values of an object used to identify and update an entity.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The number of affected entities.</returns>
    Task<int> PatchAsync(IReadOnlyDictionary<string, object?> properties, CancellationToken cancellationToken);
    
    /// <summary>
    /// Deletes the entity identified by the provided value.
    /// </summary>
    /// <param name="id">The entity identifier.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>The number of affected entities.</returns>
    Task<int> DeleteByIdAsync(TIdentity id, CancellationToken cancellationToken);
    
    /// <summary>
    /// Deletes one or more entities matching the specified criteria.
    /// </summary>
    /// <param name="criteria">An object with properties to be used as criteria to delete entities.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The number of affected entities.</returns>
    Task<int> DeleteManyAsync(dynamic criteria, CancellationToken cancellationToken);
    
    /// <summary>
    /// Deletes one or more entities matching the specified criteria.
    /// </summary>
    /// <param name="criteria">The property names and values of an object that will be used as criteria to delete entities.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The number of affected entities.</returns>
    Task<int> DeleteManyAsync(IReadOnlyDictionary<string, object?> criteria, CancellationToken cancellationToken);
    
    /// <summary>
    /// Gets the entity identified by the provided value.
    /// </summary>
    /// <param name="id">The entity identifier</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="T">Tye type of entity to return.</typeparam>
    /// <returns>The entity identified by the provided value or a null value if not found.</returns>
    Task<T?> GetByIdAsync<T>(TIdentity id, CancellationToken cancellationToken) where T : class;
    
    /// <summary>
    /// Gets the entity identified by the provided value.
    /// </summary>
    /// <param name="id">The entity identifier</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The entity identified by the provided value or a null value if not found.</returns>
    Task<TEntity?> GetByIdAsync(TIdentity id, CancellationToken cancellationToken);
    
    /// <summary>
    /// Gets an extended version of the entity identified by the provided value.
    /// </summary>
    /// <param name="id">The entity identifier</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="T">Tye type of entity to return.</typeparam>
    /// <returns>The entity identified by the provided value or a null value if not found.</returns>
    Task<T?> GetByIdExtendedAsync<T>(TIdentity id, CancellationToken cancellationToken) where T : class;

    /// <summary>
    /// Gets an extended version of the entity identified by the provided value.
    /// </summary>
    /// <param name="id">The entity identifier</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The entity identified by the provided value or a null value if not found.</returns>
    Task<TEntity?> GetByIdExtendedAsync(TIdentity id, CancellationToken cancellationToken);

    /// <summary>
    /// Gets an entity matching the specified criteria.
    /// </summary>
    /// <param name="criteria">An object with properties to be used as criteria to find the entity.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="T">Tye type of entity to return.</typeparam>
    /// <returns>The entity matching the provided criteria.</returns>
    Task<T?> GetOneAsync<T>(dynamic criteria, CancellationToken cancellationToken) where T : class;
    
    /// <summary>
    /// Gets an entity matching the specified criteria.
    /// </summary>
    /// <param name="criteria">An object with properties to be used as criteria to find the entity.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="T">Tye type of entity to return.</typeparam>
    /// <returns>The entity matching the provided criteria.</returns>
    Task<T?> GetOneAsync<T>(IReadOnlyDictionary<string, object?> criteria, CancellationToken cancellationToken) where T : class;
    
    /// <summary>
    /// Gets an entity matching the specified criteria.
    /// </summary>
    /// <param name="criteria">An object with properties to be used as criteria to find the entity.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The entity matching the provided criteria.</returns>
    Task<TEntity?> GetOneAsync(dynamic criteria, CancellationToken cancellationToken);
    
    /// <summary>
    /// Gets an entity matching the specified criteria.
    /// </summary>
    /// <param name="criteria">The property names and values of an object to be used as criteria to find the entity.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The entity matching the provided criteria.</returns>
    Task<TEntity?> GetOneAsync(IReadOnlyDictionary<string, object?> criteria, CancellationToken cancellationToken);

    /// <summary>
    /// Gets the extended version of an entity matching the specified criteria.
    /// </summary>
    /// <param name="criteria">An object with properties to be used as criteria to find the entity.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="T">Tye type of entity to return.</typeparam>
    /// <returns>The entity matching the provided criteria.</returns>
    Task<T?> GetOneExtendedAsync<T>(dynamic criteria, CancellationToken cancellationToken) where T : class;

    /// <summary>
    /// Gets the extended version of an entity matching the specified criteria.
    /// </summary>
    /// <param name="criteria">The property names and values of an object to be used as criteria to find the entity.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="T">Tye type of entity to return.</typeparam>
    /// <returns>The entity matching the provided criteria.</returns>
    Task<T?> GetOneExtendedAsync<T>(IReadOnlyDictionary<string, object?> criteria, CancellationToken cancellationToken) where T : class;
    
    /// <summary>
    /// Gets the extended version of an entity matching the specified criteria.
    /// </summary>
    /// <param name="criteria">An object with properties to be used as criteria to find the entity.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The entity matching the provided criteria.</returns>
    Task<TEntity?> GetOneExtendedAsync(dynamic criteria, CancellationToken cancellationToken);
    
    /// <summary>
    /// Gets the extended version of an entity matching the specified criteria.
    /// </summary>
    /// <param name="criteria">The property names and values of an object to be used as criteria to find the entity.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The entity matching the provided criteria.</returns>
    Task<TEntity?> GetOneExtendedAsync(IReadOnlyDictionary<string, object?> criteria, CancellationToken cancellationToken);

    /// <summary>
    /// Gets one or more entities matching the specified criteria.
    /// </summary>
    /// <param name="criteria">An object with properties to be used as criteria to find the entities.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="T">Tye type of entity to return.</typeparam>
    /// <returns>The entities matching the provided criteria.</returns>
    Task<IEnumerable<T>> GetManyAsync<T>(dynamic criteria, CancellationToken cancellationToken) where T : class;
    
    /// <summary>
    /// Gets one or more entities matching the specified criteria.
    /// </summary>
    /// <param name="criteria">The property names and values of an object to be used as criteria to find the entities.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="T">Tye type of entity to return.</typeparam>
    /// <returns>The entities matching the provided criteria.</returns>
    Task<IEnumerable<T>> GetManyAsync<T>(IReadOnlyDictionary<string, object?> criteria, CancellationToken cancellationToken) where T : class;
    
    /// <summary>
    /// Gets one or more entities matching the specified criteria.
    /// </summary>
    /// <param name="criteria">An object with properties to be used as criteria to find the entities.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The entities matching the provided criteria.</returns>
    Task<IEnumerable<TEntity>> GetManyAsync(dynamic criteria, CancellationToken cancellationToken);
    
    /// <summary>
    /// Gets one or more entities matching the specified criteria.
    /// </summary>
    /// <param name="criteria">The property names and values of an object to be used as criteria to find the entities.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The entities matching the provided criteria.</returns>
    Task<IEnumerable<TEntity>> GetManyAsync(IReadOnlyDictionary<string, object?> criteria, CancellationToken cancellationToken);

    /// <summary>
    /// Gets a page of one or more entities matching the specified criteria.
    /// </summary>
    /// <param name="query">The criteria and paging options to find the entities.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="TCriteria">The type of crieteria for the query.</typeparam>
    /// <typeparam name="TResult">The type of the entities expected as the result of the query.</typeparam>
    /// <returns>The page of entities matching the provided criteria.</returns>
    Task<EntityPageQueryResult<TCriteria, TResult>> GetPageAsync<TCriteria, TResult>(EntityPageQuery<TCriteria> query, CancellationToken cancellationToken)
        where TCriteria : class
        where TResult : class;

    /// <summary>
    /// Gets a page of one or more entities matching the specified criteria.
    /// </summary>
    /// <param name="query">The criteria and paging options to find the entities.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="TCriteria">The type of crieteria for the query.</typeparam>
    /// <returns>The page of entities matching the provided criteria.</returns>
    Task<EntityPageQueryResult<TCriteria, TEntity>> GetPageAsync<TCriteria>(EntityPageQuery<TCriteria> query, CancellationToken cancellationToken)
        where TCriteria : class;
    
    /// <summary>
    /// Gets the extended version of one or more entities matching the specified criteria.
    /// </summary>
    /// <param name="criteria">An object with properties to be used as criteria to find the entities.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="T">Tye type of entity to return.</typeparam>
    /// <returns>The entities matching the provided criteria.</returns>
    Task<IEnumerable<T>> GetManyExtendedAsync<T>(dynamic criteria, CancellationToken cancellationToken) where T : class;
    
    /// <summary>
    /// Gets the extended version of one or more entities matching the specified criteria.
    /// </summary>
    /// <param name="criteria">The property names and values of an object to be used as criteria to find the entities.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="T">Tye type of entity to return.</typeparam>
    /// <returns>The entities matching the provided criteria.</returns>
    Task<IEnumerable<T>> GetManyExtendedAsync<T>(IReadOnlyDictionary<string, object?> criteria, CancellationToken cancellationToken) where T : class;

    /// <summary>
    /// Gets the extended version of one or more entities matching the specified criteria.
    /// </summary>
    /// <param name="criteria">An object with properties to be used as criteria to find the entities.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The entities matching the provided criteria.</returns>
    Task<IEnumerable<TEntity>> GetManyExtendedAsync(dynamic criteria, CancellationToken cancellationToken);
    
    /// <summary>
    /// Gets the extended version of one or more entities matching the specified criteria.
    /// </summary>
    /// <param name="criteria">The property names and values of an object to be used as criteria to find the entities.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The entities matching the provided criteria.</returns>
    Task<IEnumerable<TEntity>> GetManyExtendedAsync(IReadOnlyDictionary<string, object?> criteria, CancellationToken cancellationToken);

    /// <summary>
    /// Gets a page of the extended version of one or more entities matching the specified criteria.
    /// </summary>
    /// <param name="query">The criteria and paging options to find the entities.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="TCriteria">The type of crieteria for the query.</typeparam>
    /// <typeparam name="TResult">The type of the entities expected as the result of the query.</typeparam>
    /// <returns>The page of entities matching the provided criteria.</returns>
    Task<EntityPageQueryResult<TCriteria, TResult>> GetPageExtendedAsync<TCriteria, TResult>(EntityPageQuery<TCriteria> query, CancellationToken cancellationToken)
        where TCriteria : class
        where TResult : class;

    /// <summary>
    /// Gets a page of the extended version of one or more entities matching the specified criteria.
    /// </summary>
    /// <param name="query">The criteria and paging options to find the entities.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="TCriteria">The type of crieteria for the query.</typeparam>
    /// <returns>The page of entities matching the provided criteria.</returns>
    Task<EntityPageQueryResult<TCriteria, TEntity>> GetPageExtendedAsync<TCriteria>(EntityPageQuery<TCriteria> query, CancellationToken cancellationToken)
        where TCriteria : class;
}