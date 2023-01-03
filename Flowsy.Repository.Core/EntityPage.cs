namespace Flowsy.Repository.Core;

/// <summary>
/// Represents the results of a query based on the given criteria and pagination options.
/// </summary>
/// <typeparam name="TCriteria">The type of criteria and pagination options.</typeparam>
/// <typeparam name="TEntity">The type of entities in the page.</typeparam>
public class EntityPage<TCriteria, TEntity> 
    where TCriteria : EntityPageCriteria
    where TEntity : class
{
    public EntityPage(TCriteria criteria, IEnumerable<TEntity> entities, long? totalEntityCount)
    {
        Criteria = criteria;
        Entities = entities;
        TotalEntityCount = totalEntityCount;
    }

    /// <summary>
    /// The criteria and pagination options used to obtain the entity page.
    /// </summary>
    public TCriteria Criteria { get; }
    
    /// <summary>
    /// The list of entities matching to the criteria and pagination options. 
    /// </summary>
    public IEnumerable<TEntity> Entities { get; }
    
    /// <summary>
    /// The number of entities in the current page.
    /// </summary>
    public long EntityCount => Entities.Count();
    
    /// <summary>
    /// If the value of Criteria.CountTotal is true, it contains the total number of entities in the repository for the specified criteria. 
    /// </summary>
    public long? TotalEntityCount { get; }

    /// <summary>
    /// If the value of Criteria.CountTotal is true, it gets the total number of pages available for the specified criteria.
    /// </summary>
    public long? TotalPageCount => 
        Criteria is {CountTotal: true, PageSize: > 0} && TotalEntityCount is > 0
            ? (long) Math.Ceiling(TotalEntityCount.Value / (decimal) Criteria.PageSize) 
            : default;
    
    /// <summary>
    /// Indicates if more data can be retrieved by requesting the next page of entities. 
    /// </summary>
    public bool HasMore 
        => Criteria.CountTotal && TotalEntityCount.HasValue && TotalPageCount.HasValue 
            ? Criteria.PageNumber < TotalPageCount
            : Criteria.PageSize == EntityCount;
}