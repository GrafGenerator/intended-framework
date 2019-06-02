using AutoMapper;

namespace Intended.OperationsHandling
{
    public interface IContextualMapper<T>
        where T : class, IMappingContext
    {
        IMapper Spawn();
    }
}