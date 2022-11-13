namespace Flowsy.Repository.Core;

public class EntityPageQuery<TCriteria> : IEntityPageQuery<TCriteria> where TCriteria : class
{
    public EntityPageQuery(
        TCriteria? criteria = default,
        long pageNumber = 1,
        long pageSize = 50,
        bool countTotal = false,
        string? totalCountProperty = null
        )
    {
        Criteria = criteria;
        PageNumber = pageNumber;
        PageSize = pageSize;
        CountTotal = countTotal;
        TotalCountProperty = totalCountProperty;
    }

    public TCriteria? Criteria { get; set; }
    public long PageNumber { get; set; }
    public long PageSize { get; set; }
    public bool CountTotal { get; set; }
    public string? TotalCountProperty { get; set; }
    
    public void Translate(out long offset, out long limit)
    {
        offset = (PageNumber - 1) * PageSize;
        limit = PageSize;
    }
}