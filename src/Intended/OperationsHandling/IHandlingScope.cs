using System;
using System.Threading.Tasks;
using Intended.DAL;
using Intended.Domain;

namespace Intended.OperationsHandling
{
    public interface IHandlingScope : IDisposable
    {
        HandlerIdentity Identity { get; }

        IRepository<T> Repo<T>()
            where T : class, IEntity;

        Task Commit();
    }
}