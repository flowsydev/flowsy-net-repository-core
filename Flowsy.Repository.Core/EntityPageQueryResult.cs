namespace Flowsy.Repository.Core;

public class EntityPageQueryResult<TCriteria, TResult> 
    where TCriteria : class
    where TResult : class
{
    public EntityPageQueryResult(EntityPageQuery<TCriteria> query, IEnumerable<TResult> results, long? totalResultCount)
    {
        Query = query;
        Results = results;
        TotalResultCount = totalResultCount;
    }

    public EntityPageQuery<TCriteria> Query { get; }
    
    public IEnumerable<TResult> Results { get; }
    
    public long PageSize => Results.Count();
    public long? TotalResultCount { get; }
    
    public long TotalPageCount => 
        Query?.PageSize > 0 && TotalResultCount > 0
            ? (long) Math.Ceiling(TotalResultCount.Value / (decimal) Query.PageSize) 
            : default;
}