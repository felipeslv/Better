using System;
using System.Web;
using Better.Application;
using Better.Application.Interface;
using Better.Domain.Interfaces.Repositories;
using Better.Domain.Interfaces.Services;
using Better.Domain.Services;
using Better.Infra.Data.Repositories;
using Better.MVC.App_Start;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using WebActivatorEx;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: ApplicationShutdownMethod(typeof(NinjectWebCommon), "Stop")]

namespace Better.MVC.App_Start
{
    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            //inicializando o appservice
            kernel.Bind(typeof (IAppServiceBase<>)).To(typeof (AppServiceBase<>));
            kernel.Bind<IEstacionamentoAppService>().To<EstacionamentoAppService>();
            kernel.Bind<ITabelaValorAppService>().To<TabelaValorAppService>();

            //inicializando o service do dominio
            kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            kernel.Bind<IEstacionamentoService>().To<EstacionamentoService>();
            kernel.Bind<ITabelaValorService>().To<TabelaValorService>();

            //inicializando o repositorio da infra 
            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(IRepositoryBase<>));
            //criar mais uma camada pra separar o vinculo da apresentgação com a infra
            kernel.Bind<IEstacionamentoRepository>().To<EstacionamentoRepository>();
            kernel.Bind<ITabelaValorRepository>().To<TabelaValorRepository>();

        }        
    }
}
