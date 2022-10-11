using System;
using System.Web;
using DeviceDetectorNET;
using DeviceDetectorNET.Parser;
using Kama.Bonyad.Evaluation.Core.Model;

namespace Kama.Bonyad.Evaluation.API.Tools
{
    public class Platform
    {
        private static OperationSystems GetInfoOS(HttpRequest request)
        {
            DeviceDetector.SetVersionTruncation(VersionTruncation.VERSION_TRUNCATION_NONE);
            DeviceDetector device = new DeviceDetector(request.UserAgent);
            device.Parse();

            var result = DeviceDetector.GetInfoFromUserAgent(request.UserAgent);
            if (result.Success && device.IsDesktop())
            {
                OperationSystems os = new OperationSystems();
                os.Version = result.Match.Os.Version.ToLower();
                os.Name = result.Match.Os.Name.ToLower();

                return os;
            }
            return null;
        }
        private static OperationSystems GetInfoPhone(HttpRequest request)
        {
            DeviceDetector.SetVersionTruncation(VersionTruncation.VERSION_TRUNCATION_NONE);
            DeviceDetector device = new DeviceDetector(request.UserAgent);
            device.Parse();

            var result = DeviceDetector.GetInfoFromUserAgent(request.UserAgent);
            if (result.Success && (device.IsMobile() || device.IsTablet()))
            {
                OperationSystems os = new OperationSystems();
                os.Version = result.Match.Os.Version.ToLower();
                os.Name = result.Match.Os.Name.ToLower();

                return os;
            }
            return null;
        }

        private static Browsers GetInfoBrowser(HttpRequest request)
        {
            var browser = request.Browser;
            Browsers browsers = new Browsers();
            browsers.Name = browser.Browser.ToLower();
            browsers.Version = browser.Version.ToLower();

            return browsers;
        }

        public static Device GetUserPlatform(HttpRequest request)
        {
            Device model = new Device();

            DeviceDetector.SetVersionTruncation(VersionTruncation.VERSION_TRUNCATION_NONE);
            DeviceDetector device = new DeviceDetector(request.UserAgent);
            device.Parse();

            var result = DeviceDetector.GetInfoFromUserAgent(request.UserAgent);
            if (result.Success)
            {
                if (device.IsDesktop())
                {
                    OperationSystems os = GetInfoOS(request);
                    Browsers browser = GetInfoBrowser(request);
                    model.Browser = browser;
                    model.OS = os;
                    model.DeviceType = result.Match.DeviceType.ToLower();
                }
                else if (device.IsMobile() || device.IsTablet())
                {
                    OperationSystems os = GetInfoPhone(request);
                    Browsers browser = GetInfoBrowser(request);
                    model.Browser = browser;
                    model.OS = os;
                    model.DeviceType = (result.Match.DeviceType != null ? result.Match.DeviceType : "mobile");
                }
            }

            return model;
        }
    }
}