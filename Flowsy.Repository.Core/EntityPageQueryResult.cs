namespace Flowsy.Repository.Core;

public class EntityPageQueryResult<TEntity> where TEntity : class
{
    public EntityPageQueryResult(EntityPageQuery query, IEnumerable<TEntity> items, long? totalItemCount)
    {
        Query = query;
        Items = items;
        TotalItemCount = totalItemCount;
    }

    public EntityPageQuery Query { get; }
    
    public IEnumerable<TEntity> Items { get; }
    
    public long PageSize => Items.Count();
    public long? TotalItemCount { get; }
    
    public long TotalPageCount => 
        Query?.PageSize > 0 && TotalItemCount > 0
            ? (long) Math.Ceiling(TotalItemCount.Value / (decimal) Query.PageSize) 
            : default;
}