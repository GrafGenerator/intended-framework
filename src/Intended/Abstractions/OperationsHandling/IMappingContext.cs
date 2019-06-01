using AutoMapper;

namespace Intended.Abstractions.OperationsHandling
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