namespace Flowsy.Repository.Core;

/// <summary>
/// Represents a query to retrieve only a set of entities matching the specified criteria and pagination options.
/// </summary>
public abstract class EntityPageQuery : IEntityPageQuery
{
   protected EntityPageQuery(
        long pageNumber = 1,
        long pageSize = 50,
        bool countTotal = false,
        string? totalCountProperty = null
        )
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        CountTotal = countTotal;
        TotalCountProperty = totalCountProperty;
    }
   
    /// <summary>
    /// The number of the page of entities to retrieve.
    /// </summary>
    public long PageNumber { get; set; }
    
    /// <summary>
    /// The number of entities to retrieve.
    /// </summary>
    public long PageSize { get; set; }
    
    /// <summary>
    /// Whether or not to count the total of entities in the repository.
    /// </summary>
    public bool CountTotal { get; set; }
    
    /// <summary>
    /// The name of the property within the results holding the total entity count.
    /// </summary>
    public string? TotalCountProperty { get; set; }
    
    /// <summary>
    /// Translates the PageNumber and PageSize properties to a pair of values based on offset and limit like the ones used in most relational databases.
    /// </summary>
    /// <param name="offset">The number of entities to skip.</param>
    /// <param name="limit">The number of entities to retrieve.</param>
    public void Translate(out long offset, out long limit)
    {
        offset = (PageNumber - 1) * PageSize;
        limit = PageSize;
    }
}