using System;
using System.Reflection;

namespace Intended.DependencyInjection
{
    public interface IDiContainerConfigurator
    {
        void Register(Type serviceType, Type implementationType, ContainerEntityLifestyle lifestyle);
        void Register(Type serviceType, Assembly assembly, ContainerEntityLifestyle lifestyle);
        void Register(Type serviceType, Assembly[] assemblies, ContainerEntityLifestyle lifestyle);
        void Register<TService, TImplementation>(ContainerEntityLifestyle lifestyle);
        void RegisterSingleton<TService, TImplementation>();
    }
}