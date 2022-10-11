//using Kama.Bonyad.Evaluation.API.Tools;
//using Kama.Bonyad.Evaluation.Core.Model;
//using System;
//using System.Linq;
//using System.Net.Http;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Web;
//using System.Web.Http.Controllers;
//using System.Web.Http.Filters;
//using AppActivator = Kama.Bonyad.Evaluation.API.IOC.Activator;


//namespace Kama.Bonyad.Evaluation.API.Attributes
//{
//    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
//    public class ActivityLogAttribute : ActionFilterAttribute
//    {
//        DateTime startTime;
//        Core.Model.Model model;
//        private Core.IRequestInfo _requestInfo;
//        private string ActionPersianName = null;
//        private string ControllerPersianName = null;

//        public override void OnActionExecuting(HttpActionContext actionContext)
//        {
//            startTime = DateTime.Now;
//            _requestInfo = AppActivator.Container.TryResolve<Core.IRequestInfo>();
//            var controllerName = actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<PersianNameAttribute>().FirstOrDefault();
//            var actionName = actionContext.ActionDescriptor.GetCustomAttributes<PersianNameAttribute>().FirstOrDefault();
//            if (controllerName != null)
//                ControllerPersianName = controllerName.Name;
//            if (actionName != null)
//                ActionPersianName = actionName.Name;

//            base.OnActionExecuting(actionContext);
//        }

//        //public async override Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
//        //{
//        //    var model = new Core.Model.ActivityLog();

//        //    model.Duration = (DateTime.Now - startTime).Milliseconds;

//        //    if (actionExecutedContext.Response != null)
//        //    {
//        //        var objectContent = actionExecutedContext.Response.Content as ObjectContent;

//        //        var result = objectContent.Value as AppCore.Result;
//        //        var returnType = actionExecutedContext.ActionContext.ActionDescriptor.ReturnType.FullName;

//        //        if (!returnType.Contains("IEnumerable"))
//        //            this.model = (result.GetData() as Core.Model.Model);

//        //        model.ObjectID = this.model == null ? null : this.model.ID != Guid.Empty ? this.model.ID : (Guid?)null;
//        //        model.Success = result.Success;
//        //        model.Object = result.GetData();
//        //    }

//        //    model.ControllerName = actionExecutedContext.ActionContext.ControllerContext.ControllerDescriptor.ControllerName;
//        //    model.ActionName = actionExecutedContext.ActionContext.ActionDescriptor.ActionName;

//        //    var clientDeviceInfo = new Tools.Platform(HttpContext.Current.Request);
//        //    model.OS = clientDeviceInfo.Os;
//        //    model.OSVersion = clientDeviceInfo.OsVersion;
//        //    model.Browser = clientDeviceInfo.Browser;
//        //    model.BrowserVersion = clientDeviceInfo.BrowserVersion;
//        //    model.DeviceType = clientDeviceInfo.DeviceType;

//        //    var activityLogService = IOC.Activator.Container.TryResolve<Core.Service.IActivityLogService>();
//        //    await activityLogService.AddAsync(model);

//        //    //return base.OnActionExecutedAsync(actionExecutedContext, cancellationToken);
//        //}

//        public override Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
//        {
//            var log = new ActivityLog();
//            log.Duration = (DateTime.Now - startTime).Milliseconds;

//            if (actionExecutedContext.Response != null)
//            {
//                var objectContent = actionExecutedContext.Response.Content as ObjectContent;
//                var result = objectContent.Value as AppCore.Result;
//                var returnType = actionExecutedContext.ActionContext.ActionDescriptor.ReturnType.FullName;
//                if (!returnType.Contains("IEnumerable"))
//                    model = (result.GetData() as Core.Model.Model);
//                log.ObjectID = model == null ? null : model.ID != 0/*Guid.Empty*/ ? model.ID : 0/*(Guid?)null*/;
//                log.Success = result.Success;
//                log.Object = result.GetData();
//            }

//            log.ControllerName = actionExecutedContext.ActionContext.ControllerContext.ControllerDescriptor.ControllerName;
//            log.ActionName = actionExecutedContext.ActionContext.ActionDescriptor.ActionName;
//            log.ControllerTitle = ControllerPersianName;
//            log.ActionTitle = ActionPersianName;

//            var device = Platform.GetUserPlatform(HttpContext.Current.Request);
//            #region ValidateInformation
//            if (device != null)
//            {
//                log.OSVersion = device.OS?.Version;
//                log.BrowserVersion = device.Browser?.Version;
//            }
//            try
//            {
//                if (device.OS != null)
//                    log.OS = (OS)Enum.Parse(typeof(OS), device.OS.Name.Replace(' ', '_'), false); //match string by enum
//                else
//                {
//                    log.OS = OS.سایر;
//                    log.OSVersion = "-";
//                }
//            }
//            catch
//            {
//                log.OS = OS.سایر;
//                log.OSVersion = "-";
//            }
//            try
//            {
//                if (device.Browser != null)
//                    log.Browser = (Browser)Enum.Parse(typeof(Browser), device.Browser.Name.Replace(' ', '_'), false);
//                else
//                {
//                    log.Browser = Browser.سایر;
//                    log.BrowserVersion = "-";
//                }
//            }
//            catch
//            {
//                log.Browser = Browser.سایر;
//                log.BrowserVersion = "-";
//            }
//            try
//            {
//                if (device.DeviceType != null)
//                    log.DeviceType = (DeviceType)Enum.Parse(typeof(DeviceType), device.DeviceType, false);
//                else
//                    log.DeviceType = DeviceType.سایر;
//            }
//            catch
//            {
//                log.DeviceType = DeviceType.سایر;
//            }
//            #endregion

//            log.PositionID = _requestInfo.PositionId != null ? _requestInfo.PositionId.Value : Guid.Empty;
//            log.UserID = _requestInfo.UserId != null ? _requestInfo.UserId.Value : Guid.Empty;
//            log.UserName = _requestInfo.UserName;
//            log.UserIP = _requestInfo.RemoteIP;

//            //var _activityLogService = IOC.Activator.Container.TryResolve<Core.Service.IActivityLogService>();

//            //var logResult = Task.Run(() => _activityLogService.AddAsync(log)).Result;

//            return base.OnActionExecutedAsync(actionExecutedContext, cancellationToken);
//        }

//    }

//}