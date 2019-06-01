using Intended.Abstractions.Domain;

namespace Intended.Abstractions.OperationsHandling.GenericResults
{
    public class DeleteResourceResult<T>: OperationResult
        where T : IEntity
    {
        public DeleteResourceResult(T entity)
        {
            Entity = entity;
            EntityId = entity.Id;
        }

        public long EntityId { get; }
        public T Entity { get; }
    }
    
    public static class Deleted
    {
        public static DeleteResourceResult<T> Resource<T>(T resource) where T : IEntity
        {
            return new DeleteResourceResult<T>(resource).IsOk();
        }
    }
}