using Autofac;

using Autofac.Integration.WebApi;
using Risk.Core.Services;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Risk
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Autofac
            var builder = new ContainerBuilder();            
            var config = GlobalConfiguration.Configuration;
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(config);
            builder.RegisterWebApiModelBinderProvider();
            builder.RegisterType<FinanceManager>().As<IFinanceManager>();
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            //

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
