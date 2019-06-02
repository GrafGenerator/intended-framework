using AutoMapper;

namespace Intended.OperationsHandling
{
    public interface IMappingContext
    {
    }

    public interface IMappingContextConfig<TContext>
        where TContext : class, IMappingContext
    {
        MapperConfiguration GetConfiguration();
    }
}