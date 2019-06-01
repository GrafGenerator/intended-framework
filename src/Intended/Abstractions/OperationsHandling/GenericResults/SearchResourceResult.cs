using System.Collections.Generic;
using Intended.Abstractions.Domain;

namespace Intended.Abstractions.OperationsHandling.GenericResults
{
    public class SearchResourceResult<T>: OperationResult
        where T : IEntity
    {
        public SearchResourceResult(ICollection<T> entities)
        {
            Entities = entities;
        }

        public ICollection<T> Entities { get; set; }
    }

    public static class Found
    {
        public static SearchResourceResult<T> Resources<T>(params T[] entities) where T : IEntity
        {
            return new SearchResourceResult<T>(entities).IsOk();
        }

        public static SearchResourceResult<T> Resources<T>(ICollection<T> entities) where T : IEntity
        {
            return new SearchResourceResult<T>(entities).IsOk();
        }

        public static SearchResourceResult<T> Nothing<T>() where T : IEntity
        {
            return new SearchResourceResult<T>(new T[0]).IsFailed();
        }
    }
}