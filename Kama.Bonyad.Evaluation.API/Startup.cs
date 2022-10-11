using Kama.Bonyad.Evaluation.API.Exceptions.Filters;
using Kama.Bonyad.Evaluation.API.Filters;
using Kama.Bonyad.Evaluation.Core;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(Kama.Bonyad.Evaluation.API.Startup), "Started")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(Kama.Bonyad.Evaluation.API.Startup), "Stop")]
[assembly: Microsoft.Owin.OwinStartup(typeof(Kama.Bonyad.Evaluation.API.Startup))]

namespace Kama.Bonyad.Evaluation.API
{
    public class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            ConfigureOAuth(app);

            ConfigureIoC(config);

            SwaggerConfig.Register(config);

            WebApiConfig.Register(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);

        }

        private void ConfigureOAuth(IAppBuilder app)
        {
            //Token Consumption
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions
            {
            });
        }

        private static void RegisterTools(AppCore.IOC.IContainer container)
        {
            container.RegisterType<AppCore.IObjectSerializer, Tools.ObjectSerializer>();
            container.RegisterType<IRequestInfo, Tools.RequestInfo>();
            container.RegisterType<IAppSetting, Tools.AppSetting>();
            container.RegisterType<IEventLogger, Tools.Logger>();

            container.RegisterType<Organization.ApiClient.Interface.IOrganizationHostInfo, ServiceHost.OrganizationHost>();
            //container.RegisterType<PdfService.ApiClient.Interface.IPdfServiceHostInfo, ServiceHost.PdfServiceHost>();

            var orgHostInfo = container.TryResolve<Organization.ApiClient.Interface.IOrganizationHostInfo>();
        }

        private static void RegisterFilters(AppCore.IOC.IContainer container, HttpConfiguration httpConfig)
        {
            //regsiter Filters
            //container.RegisterType(typeof(AuthFilter));
            //container.RegisterType(typeof(ValidationFilter));
            //container.RegisterType(typeof(KamaExceptionHandler));
            container.RegisterType(typeof(KamaExceptionLogger));


            //register command filters in httConfig
            //httpConfig.Filters.Add(container.Resolve<AzmoonAuthFilter>());
            //httpConfig.Filters.Add(container.Resolve<ValidationFilter>());
            
            //Register Exception Loggers and Exception Handler
            httpConfig.Services.Replace(typeof(IExceptionHandler), container.Resolve<KamaExceptionHandler>());
            //httpConfig.Services.Replace(typeof(IExceptionLogger), container.Resolve<KamaExceptionLogger>());
        }

        public void ConfigureIoC(HttpConfiguration httpConfig)
        {
            var container = IOC.Activator.Instance.ActiveWebApi(httpConfig, new System.Reflection.Assembly[] { System.Reflection.Assembly.GetExecutingAssembly() });

            RegisterTools(container);

            AppCore.IOC.Loader.Load(container, System.Web.Hosting.HostingEnvironment.MapPath("~/bin"));
        }

        public static void Started()
        {
        }

        public static void Stop()
            => IOC.Activator.Instance.Deactivate();
    }
}