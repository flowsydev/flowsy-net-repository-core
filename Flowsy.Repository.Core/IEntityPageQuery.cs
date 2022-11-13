namespace Flowsy.Repository.Core;

public interface IEntityPageQuery<T> where T : class
{
    T? Criteria { get; set; }
    long PageNumber { get; set; }
    long PageSize { get; set; }
    bool CountTotal { get; set; }
    
    void Translate(out long offset, out long limit);
}