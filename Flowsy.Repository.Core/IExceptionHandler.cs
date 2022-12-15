namespace Flowsy.Repository.Core;

/// <summary>
/// Provides a mechanism to handle repository exceptions. 
/// </summary>
public interface IExceptionHandler
{
    /// <summary>
    /// Takes in an exception to be handled and returns a new one appropriate to a specific use case.
    /// </summary>
    /// <param name="exception">The input exception.</param>
    /// <param name="context">The execution context for the exception.</param>
    /// <returns>A new exception</returns>
    Exception Translate(Exception exception, IExecutionContext context);
}