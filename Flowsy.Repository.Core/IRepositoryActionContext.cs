namespace Flowsy.Repository.Core;

public interface IRepositoryActionContext
{
    IRepository Repository { get; }
    string ActionName { get; }
    object? Parameters { get; }
    IDictionary<string, object?> Details { get; }
}