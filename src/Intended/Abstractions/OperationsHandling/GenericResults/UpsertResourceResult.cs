using Intended.Abstractions.Domain;

namespace Intended.Abstractions.OperationsHandling.GenericResults
{
    public class UpsertResourceResult<T>: OperationResult
        where T : IEntity
    {
        public UpsertResourceResult(T entity)
        {
            Entity = entity;
            EntityId = entity.Id;
        }

        public long EntityId { get; }
        public T Entity { get; }
    }
    
    public static class Upserted
    {
        public static UpsertResourceResult<T> Resource<T>(T resource) where T : IEntity
        {
            return new UpsertResourceResult<T>(resource).IsOk();
        }
    }
}