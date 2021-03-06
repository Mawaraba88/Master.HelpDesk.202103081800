[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(HelpDeskWeb.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(HelpDeskWeb.App_Start.NinjectWebCommon), "Stop")]

namespace HelpDeskWeb.App_Start
{
    using HelpDeskWeb.Infrastructure.Caching;
    using HelpDeskWeb.Infrastructure.Populator;
    using HelpDeskWeb.Service;
    using Metier;
    using Metier.Interfaces;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using System;
    using System.Data.Entity;
    using System.Web;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

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
            kernel.Bind<DbContext>().To<ModeleHelpDesk>();
            kernel.Bind<IHelpDeskData>().To<HelpDeskData>();

            kernel.Bind<ICacheService>().To<InMemoryCache>();

            kernel.Bind<IHomeServices>().To<HomeServices>();
            kernel.Bind<IDropDownListPopulator>().To<DropDownListPopulator>();
        }

    }
   
}