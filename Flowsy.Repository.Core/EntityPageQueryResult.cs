namespace Flowsy.Repository.Core;

/// <summary>
/// Represents the results of a query based on pagination.
/// </summary>
/// <typeparam name="TQuery">The original query.</typeparam>
/// <typeparam name="TResult">The result of the query.</typeparam>
public class EntityPageQueryResult<TQuery, TResult> 
    where TQuery : EntityPageQuery
    where TResult : class
{
    public EntityPageQueryResult(TQuery query, IEnumerable<TResult> results, long? totalResultCount)
    {
        Query = query;
        Results = results;
        TotalResultCount = totalResultCount;
    }

    /// <summary>
    /// The original query associated with this result.
    /// </summary>
    public TQuery Query { get; }
    
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
        Query.CountTotal && Query.PageSize > 0 && TotalResultCount.HasValue && TotalResultCount > 0
            ? (long) Math.Ceiling(TotalResultCount.Value / (decimal) Query.PageSize) 
            : default;
    
    /// <summary>
    /// Indicates if more data can be retrieved by requesting the next page of entities. 
    /// </summary>
    public bool HasMore 
        => Query.CountTotal && TotalResultCount.HasValue && TotalPageCount.HasValue 
            ? Query.PageNumber < TotalPageCount
            : Query.PageSize == ResultCount;
}