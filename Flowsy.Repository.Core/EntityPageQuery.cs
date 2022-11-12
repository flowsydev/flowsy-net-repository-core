namespace Flowsy.Repository.Core;

public abstract class EntityPageQuery<TCriteria> : IEntityPageQuery<TCriteria> where TCriteria : class
{
    protected EntityPageQuery() : this(1, long.MaxValue, false)
    {
    }

    protected EntityPageQuery(long pageNumber, long pageSize, bool countTotals)
    {
        Criteria = default;
        PageNumber = pageNumber;
        PageSize = pageSize;
        CountTotals = countTotals;
    }
    
    public TCriteria? Criteria { get; set; }

    public long PageNumber { get; set; }
    public long PageSize { get; set; }
    public bool CountTotals { get; set; }
    
    public void Translate(out long offset, out long limit)
    {
        offset = (PageNumber - 1) * PageSize;
        limit = PageSize;
    }
}