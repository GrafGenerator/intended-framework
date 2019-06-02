using Intended.DependencyInjection;

namespace Intended.Di.SimpleInjector
{
    public static class SimpleInjectorDiExtensions
    {
        public static IDiContainerConfigurator UseSimpleInjectorDi(this IDiContainerConfigurator configurator)
        {
            return configurator
                .UseDiContainer<SimpleInjectorDiProvider, SimpleInjectorDiProvider>();
        }
    }
}