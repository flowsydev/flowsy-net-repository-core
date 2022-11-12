namespace Flowsy.Repository.Core;

public class EntityPageQueryResult<TCriteria, TResult> 
    where TCriteria : class
    where TResult : class
{
    public EntityPageQueryResult(EntityPageQuery<TCriteria> query, IEnumerable<TResult> results, long? totalItemCount)
    {
        Query = query;
        Results = results;
        TotalItemCount = totalItemCount;
    }

    public EntityPageQuery<TCriteria> Query { get; }
    
    public IEnumerable<TResult> Results { get; }
    
    public long PageSize => Results.Count();
    public long? TotalItemCount { get; }
    
    public long TotalPageCount => 
        Query?.PageSize > 0 && TotalItemCount > 0
            ? (long) Math.Ceiling(TotalItemCount.Value / (decimal) Query.PageSize) 
            : default;
}