using Intended.DependencyInjection;
using Intended.Di;

namespace Intended.Dal.EntityFrameworkCore
{
    public static class EntityFrameworkCoreDiExtensions
    {
        public static IDiContainerConfigurator UseEfCore(this IDiContainerConfigurator configurator)
        {
            return configurator
                .UseDalAccessors<EfCoreDbContextAccessor>();
        }
    }
}   