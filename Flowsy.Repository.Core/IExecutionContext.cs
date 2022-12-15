namespace Flowsy.Repository.Core;

public interface IExecutionContext
{
    IRepository Repository { get; }
    string Action { get; }
    object? Parameters { get; }
}