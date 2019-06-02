using System;
using System.Reflection;
using Intended.DependencyInjection;
using Intended.Exceptions;
using SimpleInjector;

namespace Intended.Di.SimpleInjector
{
    internal class SimpleInjectorDiProvider : IDiContainerConfigurator, IDiContainerAccessor
    {
        private readonly Container _container;

        public SimpleInjectorDiProvider(Container container)
        {
            _container = container;
        }

        public T GetInstance<T>() where T : class
        {
            return _container.GetInstance<T>();
        }

        public void Register(Type serviceType, Type implementationType, ContainerEntityLifestyle lifestyle)
        {
            _container.Register(serviceType, implementationType, LifestyleMap(lifestyle));
        }

        public void Register(Type serviceType, Assembly assembly, ContainerEntityLifestyle lifestyle)
        {
            _container.Register(serviceType, assembly, LifestyleMap(lifestyle));
        }

        public void Register(Type serviceType, Assembly[] assemblies, ContainerEntityLifestyle lifestyle)
        {
            _container.Register(serviceType, assemblies, LifestyleMap(lifestyle));
        }

        public void Register<TService, TImplementation>(ContainerEntityLifestyle lifestyle)
            where TService : class 
            where TImplementation : class, TService
        {
            _container.Register<TService, TImplementation>(LifestyleMap(lifestyle));
        }

        public void RegisterSingleton<TService, TImplementation>() 
            where TService : class 
            where TImplementation : class, TService
        {
            _container.Register<TService, TImplementation>();
        }

        private Lifestyle LifestyleMap(ContainerEntityLifestyle containerEntityLifestyle)
        {
            switch (containerEntityLifestyle)
            {
                case ContainerEntityLifestyle.Scoped:
                    return Lifestyle.Scoped;

                case ContainerEntityLifestyle.Singleton:
                    return Lifestyle.Singleton;

                case ContainerEntityLifestyle.Transient:
                    return Lifestyle.Transient;

                case ContainerEntityLifestyle.Unknown:
                default:
                    throw new ContainerConfigurationException(
                        $"Lifestyle {containerEntityLifestyle} is not supported by container.");
            }
        }
    }
}