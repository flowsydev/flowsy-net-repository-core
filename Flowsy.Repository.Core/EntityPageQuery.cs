namespace Flowsy.Repository.Core;

public class EntityPageQuery
{
    public EntityPageQuery() : this(new { }, 1, long.MaxValue, false)
    {
    }

    public EntityPageQuery(dynamic criteria, long pageNumber, long pageSize, bool countTotals)
    {
        Criteria = criteria;
        PageNumber = pageNumber;
        PageSize = pageSize;
        CountTotals = countTotals;
    }
    
    public dynamic? Criteria { get; set; }

    public long PageNumber { get; set; }
    public long PageSize { get; set; }
    public bool CountTotals { get; set; }
    
    public void Translate(out long offset, out long limit)
    {
        offset = (PageNumber - 1) * PageSize;
        limit = PageSize;
    }
}