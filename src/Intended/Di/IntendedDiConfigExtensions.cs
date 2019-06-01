using System;
using System.Reflection;
using Intended.Abstractions.Dal;
using Intended.Abstractions.OperationsHandling;
using Intended.DAL.DalGenericImpl.Readers;
using Intended.DAL.DalGenericImpl.Repositories;
using Intended.DependencyInjection;
using Intended.OperationsHandling;

namespace Intended.Di
{
    public static class IntendedDiConfigExtensions
    {
        public static IDiContainerConfigurator UseIntended(this IDiContainerConfigurator configurator)
        {
            return configurator
                .UseGenericDal()
                .UseOperations()
                .UseMapping();
        }
        
        public static IDiContainerConfigurator UseGenericDal(this IDiContainerConfigurator configurator)
        {
            configurator.Register(typeof(IRepository<>), typeof(GenericEntityRepository<>), ContainerEntityLifestyle.Scoped);
            configurator.Register(typeof(IEntityReader<>), typeof(EntityReader<>), ContainerEntityLifestyle.Scoped);

            return configurator;
        }
        
        public static IDiContainerConfigurator UseDalAccessors(this IDiContainerConfigurator configurator, Type dbContextAccessorType, Type dbSetAccessorType)
        {
            configurator.Register(typeof(IDbContextAccessor), dbContextAccessorType, ContainerEntityLifestyle.Scoped);
            configurator.Register(typeof(IDbSetAccessor<>), dbSetAccessorType, ContainerEntityLifestyle.Scoped);

            return configurator;
        }
        
        public static IDiContainerConfigurator UseMapping(this IDiContainerConfigurator configurator)
        {
            configurator.Register(typeof(IContextualMapper<>), typeof(ContextualMapper<>), ContainerEntityLifestyle.Scoped);
            
            return configurator; 
        }
        
        public static IDiContainerConfigurator UseMappingContextConfigs(this IDiContainerConfigurator configurator, Assembly assembly)
        {
            configurator.Register(typeof(IMappingContextConfig<>), assembly, ContainerEntityLifestyle.Singleton);
            
            return configurator; 
        }
        
        public static IDiContainerConfigurator UseOperationServices(this IDiContainerConfigurator configurator, params Assembly[] assemblies)
        {
            configurator.Register(typeof(IOperationService<,>), assemblies, ContainerEntityLifestyle.Scoped);

            return configurator;
        }
        
        public static IDiContainerConfigurator UseEntityUnixTimeIdentity(this IDiContainerConfigurator configurator)
        {
            configurator.RegisterSingleton<IEntityIdentityService, UnixTimeEntityIdentityService>();

            return configurator;
        }
        
        public static IDiContainerConfigurator UseOperations(this IDiContainerConfigurator configurator)
        {
            configurator.Register<IOperationServicesFactory, OperationServicesFactory>(ContainerEntityLifestyle.Scoped);

            configurator.Register<IHandlingScopeFactory, HandlingScopeFactory>(ContainerEntityLifestyle.Scoped);
            configurator.Register<IHandlingScopesStack<HandlingScope>, HandlingScopesStack>(ContainerEntityLifestyle.Scoped);
            configurator.Register<IHandlingScopesAnalyzer, HandlingScopesAnalyzer>(ContainerEntityLifestyle.Scoped);

            return configurator;
        }
    }
}