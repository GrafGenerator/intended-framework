using Intended.Domain;

namespace Intended.OperationsHandling.GenericResults
{
    public class UpdateResourceResult<T>: OperationResult
        where T : IEntity
    {
        public UpdateResourceResult(T entity)
        {
            Entity = entity;
            EntityId = entity.Id;
        }

        public long EntityId { get; }
        public T Entity { get; }
    }
    
    public static class Updated
    {
        public static UpdateResourceResult<T> Resource<T>(T resource) where T : IEntity
        {
            return new UpdateResourceResult<T>(resource).IsOk();
        }
    }
}