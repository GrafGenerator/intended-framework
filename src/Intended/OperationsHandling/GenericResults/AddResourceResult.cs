using Intended.Domain;

namespace Intended.OperationsHandling.GenericResults
{
    public class AddResourceResult<T>: OperationResult
        where T : IEntity
    {
        public AddResourceResult(T entity)
        {
            Entity = entity;
            EntityId = entity.Id;
        }

        public long EntityId { get; }
        public T Entity { get; }
    }

    public static class Added
    {
        public static AddResourceResult<T> Resource<T>(T resource) where T : IEntity
        {
            return new AddResourceResult<T>(resource).IsOk();
        }
    }
}