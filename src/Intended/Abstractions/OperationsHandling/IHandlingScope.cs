using System;
using System.Threading.Tasks;
using Intended.Abstractions.Dal;
using Intended.Abstractions.Domain;

namespace Intended.Abstractions.OperationsHandling
{
    public interface IHandlingScope : IDisposable
    {
        HandlerIdentity Identity { get; }

        IRepository<T> Repo<T>()
            where T : class, IEntity;

        Task Commit();
    }
}