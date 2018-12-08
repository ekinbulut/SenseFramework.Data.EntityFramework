/*
 * Project : SenseFramework - Database module
 * Author : Ekin Bulut 
 * Date : 25.02.2017
 * 
 * Desc : EntityFrameworkModule windsor intaller. Registers repository pattern, dbcontext, interceptors.
 * 
 */

using System.Data.Entity;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;


namespace SenseFramework.Data.EntityFramework
{
    using Core.Configuration;
    using Attributes;
    using Context;
    using Repositories;
    internal class EntityFrameworkModuleInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //register interceptor
            container.Register(Component.For<CustomErrorHandlerInterceptor>().LifestyleSingleton());


            //register Context
            //container.Register(Component.For<DbContext>().ImplementedBy<BaseContext>().LifestyleSingleton());

            container.Register(
                Classes.FromAssemblyInDirectory(new AssemblyFilter(AssemblyInstaller.AssemblyDirectory))
                    .BasedOn(typeof(IDbContext))
                    .WithServices(typeof(BaseContext)).LifestyleTransient().Configure(x => x.Interceptors<CustomErrorHandlerInterceptor>()));


            //register repositories with interceptor
            container.Register(
                Classes.FromAssemblyInDirectory(new AssemblyFilter(AssemblyInstaller.AssemblyDirectory))
                    .BasedOn(typeof(IReadonlyRepository<,>))
                    .WithServiceDefaultInterfaces().LifestyleTransient().Configure(x => x.Interceptors<CustomErrorHandlerInterceptor>()));

            container.Register(
                Classes.FromAssemblyInDirectory(new AssemblyFilter(AssemblyInstaller.AssemblyDirectory))
                    .BasedOn(typeof(IRepository<,>))
                    .WithServiceDefaultInterfaces().LifestyleTransient().Configure(x => x.Interceptors<CustomErrorHandlerInterceptor>()));

            container.Register(
                Classes.FromAssemblyInDirectory(new AssemblyFilter(AssemblyInstaller.AssemblyDirectory))
                    .BasedOn(typeof(IUnitOfWork<,>))
                    .WithServiceDefaultInterfaces().LifestyleTransient().Configure(x => x.Interceptors<CustomErrorHandlerInterceptor>()));




        }
    }
}