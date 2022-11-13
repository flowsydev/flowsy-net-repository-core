namespace Flowsy.Repository.Core;

public abstract class EntityPageQuery<TCriteria> : IEntityPageQuery<TCriteria> where TCriteria : class
{
    protected EntityPageQuery(long pageNumber = 1, long pageSize = long.MaxValue, bool countTotals = false, string? totalProperty = null)
    {
        Criteria = default;
        PageNumber = pageNumber;
        PageSize = pageSize;
        CountTotals = countTotals;
        TotalProperty = totalProperty;
    }
    
    public TCriteria? Criteria { get; set; }

    public long PageNumber { get; set; }
    public long PageSize { get; set; }
    public bool CountTotals { get; set; }
    public string? TotalProperty { get; set; }
    
    public void Translate(out long offset, out long limit)
    {
        offset = (PageNumber - 1) * PageSize;
        limit = PageSize;
    }
}