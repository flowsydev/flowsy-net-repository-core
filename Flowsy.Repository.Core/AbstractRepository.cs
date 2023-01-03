namespace Flowsy.Repository.Core;

/// <summary>
/// Provides a default implementantion of a repository which methods throw a NotSupportedException exception.
/// This abstract class is intended to be inherited by classes that will override the required virtual methods for the specific use case of the repository.   
/// </summary>
/// <typeparam name="TEntity">The entity type.</typeparam>
/// <typeparam name="TIdentity">The identity type.</typeparam>
public abstract class AbstractRepository<TEntity, TIdentity> : IRepository<TEntity, TIdentity> where TEntity : class, IEntity
{
    protected AbstractRepository(IExceptionHandler? exceptionHandler = null)
    {
        ExceptionHandler = exceptionHandler;
    }

    /// <summary>
    /// The name used to identify entities of type TEntity.
    /// It is highly recommended to stick to a PascalCase convention, so specific implementations will be able to perform tasks in a consistent way.
    /// The entity name can be thought of as the noun used to describe that real world object or concept being modeled: Product, Customer, Invoice, PurchaseOrder, etc.
    /// The simplest way to implement this property would be to return the value of typeof(TEntity).Name. 
    /// </summary>
    public virtual string EntityName => typeof(TEntity).Name;
    
    /// <summary>
    /// The name of the property that holds unique identifiers for entities of the repository.
    /// It is highly recommended to use consistent values for all the entities handled by the application.
    /// The simplest way to implement this property would be to return the value of $"{EntityName}Id" or something of the sort.
    /// </summary>
    public virtual string IdentityPropertyName => $"{EntityName}Id";
    
    protected virtual IExceptionHandler? ExceptionHandler { get; }
    
    /// <summary>
    /// Creates a new entity in the underlying data store.
    /// </summary>
    /// <param name="entity">The entity to be created.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="T">The type of the entity.</typeparam>
    /// <returns>The identifier of the new entity.</returns>
    public virtual Task<TIdentity> CreateAsync<T>(T entity, CancellationToken cancellationToken) where T : class
    {
        throw new NotSupportedException();
    }
    
    /// <summary>
    /// Creates a new entity in the underlying data store.
    /// </summary>
    /// <param name="entity">The entity to be created.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The identifier of the new entity.</returns>
    public virtual Task<TIdentity> CreateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }

    /// <summary>
    /// Creates a new entity in the underlying data store.
    /// </summary>
    /// <param name="entity">The entity to be created.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The identifier of the new entity.</returns>
    public virtual Task<TIdentity> CreateAsync(dynamic entity, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }

    /// <summary>
    /// Creates a new entity in the underlying data store.
    /// </summary>
    /// <param name="properties">The property names and values of the entity to be created.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The identifier of the new entity.</returns>
    public virtual Task<TIdentity> CreateAsync(IReadOnlyDictionary<string, object?> properties, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }

    /// <summary>
    /// Updates an entitiy in the underlying data store.
    /// </summary>
    /// <param name="entity">The entity to be updated.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="T">The type of the entity.</typeparam>
    /// <returns>The number of affected entities.</returns>
    public virtual Task<int> UpdateAsync<T>(T entity, CancellationToken cancellationToken) where T : class
    {
        throw new NotSupportedException();
    }
    
    /// <summary>
    /// Updates an entitiy in the underlying data store.
    /// </summary>
    /// <param name="entity">The entity to be updated.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The number of affected entities.</returns>
    public virtual Task<int> UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }

    /// <summary>
    /// Updates an entitiy in the underlying data store.
    /// </summary>
    /// <param name="entity">The entity to be updated.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The number of affected entities.</returns>
    public virtual Task<int> UpdateAsync(dynamic entity, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }

    /// <summary>
    /// Updates an entitiy in the underlying data store.
    /// </summary>
    /// <param name="properties">The property names and values of the entity to be updated.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The number of affected entities.</returns>
    public virtual Task<int> UpdateAsync(IReadOnlyDictionary<string, object?> properties, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }

    /// <summary>
    /// Updates only one property of the entity identified by the provided value.
    /// </summary>
    /// <param name="id">The entity identifier.</param>
    /// <param name="propertyName">The name of the property to be updated.</param>
    /// <param name="value">The new value for the property to be updated.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The number of affected entities.</returns>
    public virtual Task<int> PatchAsync(TIdentity id, string propertyName, object value, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }
    
    /// <summary>
    /// Updates only certain properties of an entity.
    /// </summary>
    /// <param name="entity">An object with properties used to identify and update an entity.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The number of affected entities.</returns>
    public virtual Task<int> PatchAsync(dynamic entity, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }

    /// <summary>
    /// Updates only certain properties of an entity.
    /// </summary>
    /// <param name="properties">The property names and values of an object used to identify and update an entity.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The number of affected entities.</returns>
    public virtual Task<int> PatchAsync(IReadOnlyDictionary<string, object?> properties, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }

    /// <summary>
    /// Deletes the entity identified by the provided value.
    /// </summary>
    /// <param name="id">The entity identifier.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>The number of affected entities.</returns>
    public virtual Task<int> DeleteByIdAsync(TIdentity id, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }

    /// <summary>
    /// Deletes one or more entities matching the specified criteria.
    /// </summary>
    /// <param name="criteria">An object with properties to be used as criteria to delete entities.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The number of affected entities.</returns>
    public virtual Task<int> DeleteManyAsync(dynamic criteria, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }

    /// <summary>
    /// Deletes one or more entities matching the specified criteria.
    /// </summary>
    /// <param name="criteria">The property names and values of an object that will be used as criteria to delete entities.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The number of affected entities.</returns>
    public virtual Task<int> DeleteManyAsync(IReadOnlyDictionary<string, object?> criteria, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }
    
    /// <summary>
    /// Gets the entity identified by the provided value.
    /// </summary>
    /// <param name="id">The entity identifier</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="T">Tye type of entity to return.</typeparam>
    /// <returns>The entity identified by the provided value or a null value if not found.</returns>
    public virtual Task<T?> GetByIdAsync<T>(TIdentity id, CancellationToken cancellationToken) where T : class
    {
        throw new NotSupportedException();
    }

    /// <summary>
    /// Gets the entity identified by the provided value.
    /// </summary>
    /// <param name="id">The entity identifier</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The entity identified by the provided value or a null value if not found.</returns>
    public virtual Task<TEntity?> GetByIdAsync(TIdentity id, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }

    /// <summary>
    /// Gets an extended version of the entity identified by the provided value.
    /// </summary>
    /// <param name="id">The entity identifier</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="T">Tye type of entity to return.</typeparam>
    /// <returns>The entity identified by the provided value or a null value if not found.</returns>
    public virtual Task<T?> GetByIdExtendedAsync<T>(TIdentity id, CancellationToken cancellationToken) where T : class
    {
        throw new NotSupportedException();
    }
    
    /// <summary>
    /// Gets an extended version of the entity identified by the provided value.
    /// </summary>
    /// <param name="id">The entity identifier</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The entity identified by the provided value or a null value if not found.</returns>
    public virtual Task<TEntity?> GetByIdExtendedAsync(TIdentity id, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }
    
    /// <summary>
    /// Gets an entity matching the specified criteria.
    /// </summary>
    /// <param name="criteria">An object with properties to be used as criteria to find the entity.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="T">Tye type of entity to return.</typeparam>
    /// <returns>The entity matching the provided criteria.</returns>
    public virtual Task<T?> GetOneAsync<T>(dynamic criteria, CancellationToken cancellationToken) where T : class
    {
        throw new NotSupportedException();
    }

    /// <summary>
    /// Gets an entity matching the specified criteria.
    /// </summary>
    /// <param name="criteria">An object with properties to be used as criteria to find the entity.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The entity matching the provided criteria.</returns>
    public virtual Task<TEntity?> GetOneAsync(dynamic criteria, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }

    /// <summary>
    /// Gets an entity matching the specified criteria.
    /// </summary>
    /// <param name="criteria">The property names and values of an object to be used as criteria to find the entity.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The entity matching the provided criteria.</returns>
    public virtual Task<TEntity?> GetOneAsync(IReadOnlyDictionary<string, object?> criteria, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }

    /// <summary>
    /// Gets the extended version of an entity matching the specified criteria.
    /// </summary>
    /// <param name="criteria">An object with properties to be used as criteria to find the entity.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="T">Tye type of entity to return.</typeparam>
    /// <returns>The entity matching the provided criteria.</returns>
    public virtual Task<T?> GetOneAsync<T>(IReadOnlyDictionary<string, object?> criteria, CancellationToken cancellationToken) where T : class
    {
        throw new NotSupportedException();
    }
    
    /// <summary>
    /// Gets the extended version of an entity matching the specified criteria.
    /// </summary>
    /// <param name="criteria">An object with properties to be used as criteria to find the entity.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="T">Tye type of entity to return.</typeparam>
    /// <returns>The entity matching the provided criteria.</returns>
    public virtual Task<T?> GetOneExtendedAsync<T>(dynamic criteria, CancellationToken cancellationToken) where T : class
    {
        throw new NotSupportedException();
    }

    /// <summary>
    /// Gets the extended version of an entity matching the specified criteria.
    /// </summary>
    /// <param name="criteria">The property names and values of an object to be used as criteria to find the entity.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="T">Tye type of entity to return.</typeparam>
    /// <returns>The entity matching the provided criteria.</returns>
    public virtual Task<T?> GetOneExtendedAsync<T>(IReadOnlyDictionary<string, object?> criteria, CancellationToken cancellationToken) where T : class
    {
        throw new NotSupportedException();
    }
    
    /// <summary>
    /// Gets the extended version of an entity matching the specified criteria.
    /// </summary>
    /// <param name="criteria">An object with properties to be used as criteria to find the entity.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The entity matching the provided criteria.</returns>
    public virtual Task<TEntity?> GetOneExtendedAsync(dynamic criteria, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }

    /// <summary>
    /// Gets the extended version of an entity matching the specified criteria.
    /// </summary>
    /// <param name="criteria">The property names and values of an object to be used as criteria to find the entity.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The entity matching the provided criteria.</returns>
    public virtual Task<TEntity?> GetOneExtendedAsync(IReadOnlyDictionary<string, object?> criteria, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }

    /// <summary>
    /// Gets one or more entities matching the specified criteria.
    /// </summary>
    /// <param name="criteria">An object with properties to be used as criteria to find the entities.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="T">Tye type of entity to return.</typeparam>
    /// <returns>The entities matching the provided criteria.</returns>
    public virtual Task<IEnumerable<T>> GetManyAsync<T>(dynamic criteria, CancellationToken cancellationToken) where T : class
    {
        throw new NotSupportedException();
    }

    /// <summary>
    /// Gets one or more entities matching the specified criteria.
    /// </summary>
    /// <param name="criteria">The property names and values of an object to be used as criteria to find the entities.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="T">Tye type of entity to return.</typeparam>
    /// <returns>The entities matching the provided criteria.</returns>
    public virtual Task<IEnumerable<T>> GetManyAsync<T>(IReadOnlyDictionary<string, object?> criteria, CancellationToken cancellationToken) where T : class
    {
        throw new NotSupportedException();
    }
    
    /// <summary>
    /// Gets one or more entities matching the specified criteria.
    /// </summary>
    /// <param name="criteria">An object with properties to be used as criteria to find the entities.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The entities matching the provided criteria.</returns>
    public virtual Task<IEnumerable<TEntity>> GetManyAsync(dynamic criteria, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }

    /// <summary>
    /// Gets one or more entities matching the specified criteria.
    /// </summary>
    /// <param name="criteria">The property names and values of an object to be used as criteria to find the entities.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The entities matching the provided criteria.</returns>
    public virtual Task<IEnumerable<TEntity>> GetManyAsync(IReadOnlyDictionary<string, object?> criteria, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }

    /// <summary>
    /// Gets a page of one or more entities matching the specified criteria.
    /// </summary>
    /// <param name="criteria">The criteria and paging options to find the entities.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="TCriteria">The type of the criteria and pagination options.</typeparam>
    /// <typeparam name="TResult">The type of the entities expected as the result of the query.</typeparam>
    /// <returns>The page of entities matching the provided criteria.</returns>
    public virtual Task<EntityPage<TCriteria, TResult>> GetPageAsync<TCriteria, TResult>(
        TCriteria criteria,
        CancellationToken cancellationToken
        )
        where TCriteria : EntityPageCriteria
        where TResult : class
    {
        throw new NotSupportedException();
    }

    /// <summary>
    /// Gets a page of one or more entities matching the specified criteria.
    /// </summary>
    /// <param name="criteria">The criteria and paging options to find the entities.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="TCriteria">The type of the criteria and pagination options.</typeparam>
    /// <returns>The page of entities matching the provided criteria.</returns>
    public virtual Task<EntityPage<TCriteria, TEntity>> GetPageAsync<TCriteria>(TCriteria criteria, CancellationToken cancellationToken)
        where TCriteria : EntityPageCriteria
    {
        throw new NotSupportedException();
    }

    /// <summary>
    /// Gets the extended version of one or more entities matching the specified criteria.
    /// </summary>
    /// <param name="criteria">An object with properties to be used as criteria to find the entities.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="T">Tye type of entity to return.</typeparam>
    /// <returns>The entities matching the provided criteria.</returns>
    public virtual Task<IEnumerable<T>> GetManyExtendedAsync<T>(dynamic criteria, CancellationToken cancellationToken) where T : class
    {
        throw new NotSupportedException();
    }
    
    /// <summary>
    /// Gets the extended version of one or more entities matching the specified criteria.
    /// </summary>
    /// <param name="criteria">The property names and values of an object to be used as criteria to find the entities.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="T">Tye type of entity to return.</typeparam>
    /// <returns>The entities matching the provided criteria.</returns>
    public virtual Task<IEnumerable<T>> GetManyExtendedAsync<T>(IReadOnlyDictionary<string, object?> criteria, CancellationToken cancellationToken) where T : class
    {
        throw new NotSupportedException();
    }
    
    /// <summary>
    /// Gets the extended version of one or more entities matching the specified criteria.
    /// </summary>
    /// <param name="criteria">An object with properties to be used as criteria to find the entities.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The entities matching the provided criteria.</returns>
    public virtual Task<IEnumerable<TEntity>> GetManyExtendedAsync(dynamic criteria, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }

    /// <summary>
    /// Gets the extended version of one or more entities matching the specified criteria.
    /// </summary>
    /// <param name="criteria">The property names and values of an object to be used as criteria to find the entities.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <returns>The entities matching the provided criteria.</returns>
    public virtual Task<IEnumerable<TEntity>> GetManyExtendedAsync(IReadOnlyDictionary<string, object?> criteria, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }

    /// <summary>
    /// Gets a page of the extended version of one or more entities matching the specified criteria.
    /// </summary>
    /// <param name="criteria">The criteria and paging options to find the entities.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="TCriteria">The type of the criteria and pagination options.</typeparam>
    /// <typeparam name="TResult">The type of the entities expected as the result of the query.</typeparam>
    /// <returns>The page of entities matching the provided criteria.</returns>
    public virtual Task<EntityPage<TCriteria, TResult>> GetPageExtendedAsync<TCriteria, TResult>(TCriteria criteria, CancellationToken cancellationToken)
        where TCriteria : EntityPageCriteria
        where TResult : class
    {
        throw new NotSupportedException();
    }

    /// <summary>
    /// Gets a page of the extended version of one or more entities matching the specified criteria.
    /// </summary>
    /// <param name="criteria">The criteria and paging options to find the entities.</param>
    /// <param name="cancellationToken">The cancellation token for the operation.</param>
    /// <typeparam name="TCriteria">The type of the criteria and pagination options.</typeparam>
    /// <returns>The page of entities matching the provided criteria.</returns>
    public virtual Task<EntityPage<TCriteria, TEntity>> GetPageExtendedAsync<TCriteria>(TCriteria criteria, CancellationToken cancellationToken)
        where TCriteria : EntityPageCriteria
    {
        throw new NotSupportedException();
    }
}