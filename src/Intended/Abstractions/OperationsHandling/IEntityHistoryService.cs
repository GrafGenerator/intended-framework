using System.Threading.Tasks;
using Intended.Abstractions.Domain;

namespace Intended.Abstractions.OperationsHandling
{
    public interface IEntityHistoryService
    {
        Task Event<T>(T entity, string description = null) where T : IEntity;
    }
}