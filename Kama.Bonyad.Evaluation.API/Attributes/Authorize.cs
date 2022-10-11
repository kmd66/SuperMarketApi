using System;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using AppActivator = Kama.Bonyad.Evaluation.API.IOC.Activator;

namespace Kama.Bonyad.Evaluation.API.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]

    public class AuthorizeAttribute : System.Web.Http.AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var _appSetting = AppActivator.Container.TryResolve<Core.IAppSetting>();

            if (_appSetting.DeploymentMode == AppCore.DeploymentMode.Development)
                return;

            //if (_appSetting.ApiMode == AppCore.ApiMode.WebServiceMode)
            //{
            //    var webServicePermissionAttribute = actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<Attributes.WebServiceAttribute>().FirstOrDefault();
            //    if (webServicePermissionAttribute == null)  // is not WebService action
            //    {
            //        HttpResponseMessage response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.NonAuthoritativeInformation, AppCore.Result.Failure(-397, "امکان انجام عملیات فراهم نیست."));
            //        actionContext.Response = response;
            //        return;
            //    }
            //    else   // do not authorize WebService actions
            //        return;
            //}

            //if (actionContext.Request.Headers.Any(h => h.Key == "Authorization")  // has token
            //    && !HttpContext.Current.User.Identity.IsAuthenticated)           // expired
            //{
            //    HttpResponseMessage response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.NonAuthoritativeInformation, AppCore.Result.Failure(-397, "توکن منقضی شده است."));
            //    actionContext.Response = response;
            //    return;
            //}

            base.OnAuthorization(actionContext);
        }
    }
}