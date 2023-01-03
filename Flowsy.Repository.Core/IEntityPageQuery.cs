namespace Flowsy.Repository.Core;

public interface IEntityPageQuery
{
    long PageNumber { get; set; }
    long PageSize { get; set; }
    bool CountTotal { get; set; }
    
    void Translate(out long offset, out long limit);
}