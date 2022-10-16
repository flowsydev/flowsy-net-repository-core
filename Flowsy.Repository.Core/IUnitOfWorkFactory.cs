namespace Flowsy.Repository.Core;

public interface IUnitOfWorkFactory
{
    T Create<T>(string configurationKey = "Default") where T : IUnitOfWork;
}