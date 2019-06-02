using System;
using System.Reflection;
using Intended.DependencyInjection;
using Intended.Exceptions;
using SimpleInjector;

namespace Intended.Di.SimpleInjector
{
    internal class SimpleInjectorContainerAccessor : IDiContainerAccessor
    {
        private readonly Container _container;

        public SimpleInjectorContainerAccessor(Container container)
        {
            _container = container;
        }

        public T GetInstance<T>() where T : class
        {
            return _container.GetInstance<T>();
        }
    }
}