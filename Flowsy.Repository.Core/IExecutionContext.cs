namespace Flowsy.Repository.Core;

public interface IExecutionContext
{
    string Action { get; }
    object? Parameters { get; }
}