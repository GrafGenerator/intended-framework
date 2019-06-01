using AutoMapper;

namespace Intended.Abstractions.OperationsHandling
{
    public interface IContextualMapper<T>
        where T : class, IMappingContext
    {
        IMapper Spawn();
    }
}