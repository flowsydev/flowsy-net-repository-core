namespace Flowsy.Repository.Core;

/// <summary>
/// Represents the results of a query based on pagination.
/// </summary>
/// <typeparam name="TCriteria">The type of criteria and pagination options.</typeparam>
/// <typeparam name="TResult">The result of the query.</typeparam>
public class EntityPage<TCriteria, TResult> 
    where TCriteria : EntityPageCriteria
    where TResult : class
{
    public EntityPage(TCriteria criteria, IEnumerable<TResult> results, long? totalResultCount)
    {
        Criteria = criteria;
        Results = results;
        TotalResultCount = totalResultCount;
    }

    /// <summary>
    /// The criteria and pagination options used to obtain the entity page.
    /// </summary>
    public TCriteria Criteria { get; }
    
    /// <summary>
    /// The list of entities matching to the criteria and pagination options. 
    /// </summary>
    public IEnumerable<TResult> Results { get; }
    
    /// <summary>
    /// The number of entities in the current result.
    /// </summary>
    public long ResultCount => Results.Count();
    
    /// <summary>
    /// If the value of Query.CountTotal is true, it contains the total number of entities in the repository for the specified query. 
    /// </summary>
    public long? TotalResultCount { get; }

    /// <summary>
    /// If the value of Query.CountTotal is true, it gets the total number of pages for the specified query.
    /// </summary>
    public long? TotalPageCount => 
        Criteria.CountTotal && Criteria.PageSize > 0 && TotalResultCount.HasValue && TotalResultCount > 0
            ? (long) Math.Ceiling(TotalResultCount.Value / (decimal) Criteria.PageSize) 
            : default;
    
    /// <summary>
    /// Indicates if more data can be retrieved by requesting the next page of entities. 
    /// </summary>
    public bool HasMore 
        => Criteria.CountTotal && TotalResultCount.HasValue && TotalPageCount.HasValue 
            ? Criteria.PageNumber < TotalPageCount
            : Criteria.PageSize == ResultCount;
}