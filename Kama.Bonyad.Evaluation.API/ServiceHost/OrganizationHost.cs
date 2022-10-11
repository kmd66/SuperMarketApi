using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Routing;
using WebConfig = System.Web.Configuration.WebConfigurationManager;

namespace Kama.Bonyad.Evaluation.API.ServiceHost
{

    public class OrganizationHost : Organization.ApiClient.Interface.IOrganizationHostInfo
    {
        public OrganizationHost(Core.IRequestInfo requestInfo,
            Core.IAppSetting appSetting)
        {
            _requestInfo = requestInfo;
            _appSetting = appSetting;
        }

        readonly Core.IRequestInfo _requestInfo;
        readonly Core.IAppSetting _appSetting;

        public string Host
            => _appSetting.OrganizationHost;

        public IDictionary<string, string> GetDefaultHeaders()
        {
            var headers = new Dictionary<string, string>();

            //var strHeaders = WebConfig.AppSettings["OrganizationHostHeaders"];
            //var items = strHeaders.Split(',')
            //                      .Select(e => { var segments = e.Split(':'); return new Tuple<string, string>(segments[0], segments[1]); });
            //foreach (var item in items)
            //    headers.Add(item.Item1, item.Item2);

            headers.Add("X-Forwarded-For", _requestInfo.RemoteIP);
            headers.Add("App-URL", _requestInfo.AppURL);
            headers.Add("ApplicationID", _appSetting.ApplicationID.ToString());

            var authHeader = HttpContext.Current?.Request?.Headers["Authorization"];
            if (!string.IsNullOrEmpty(authHeader))
                headers.Add("Authorization", $"{authHeader}");

            return headers;
        }

        protected string GetHedaerValue(string key)
        {
            HttpRequestMessage request = HttpContext.Current.Items["MS_HttpRequestMessage"] as HttpRequestMessage;

            IEnumerable<string> values = new string[] { };
            request.Headers.TryGetValues(key, out values);
            if (values == null)
                return null;
            return string.Join(",", values);
        }
    }
}