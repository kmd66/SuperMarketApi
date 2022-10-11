using Kama.Bonyad.Evaluation.Core;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Web.Hosting;

namespace Kama.Bonyad.Evaluation.API.Tools
{
    public class AppSetting : IAppSetting
    {
        public string ConnectionString => ConfigurationManager.ConnectionStrings["Evaluation"].ConnectionString;

        public Guid ApplicationID => Guid.Parse(GetValue<string>("ApplicationID"));

        public AppCore.DeploymentMode DeploymentMode => (AppCore.DeploymentMode)GetValue<byte>("DeploymentMode");

        public string MailServiceHost => GetValue<string>("MailServiceHost");

        public string SmsServiceHost => GetValue<string>("SmsServiceHost");

        public string OrganizationHost => GetValue<string>("OrganizationHost");

        public string PdfServiceHost => GetValue<string>("PdfServiceHost");

        public string H2pjsHost => GetValue<string>("H2pjsHost");

        public WebServiceLocality WebServiceLocality
        {
            get
            {
                var val = GetValue<string>("WebServiceLocality");

                if (val.ToLower() == "local")
                    return WebServiceLocality.Local;
                else
                    return WebServiceLocality.MainServer;
            }
        }

        public string AutomationServiceUrl => GetValue<string>("AutomationServiceUrl");


        public int FollowingLetterAutomationTimerInterval
        {
            get
            {
                var interval = GetValue<int>("FollowingLetterAutomationTimerInterval");
                if (interval != 0)
                    return interval * 60000;   // convert to minute
                else
                    return Int32.MaxValue;
            }
        }

        public int TimerToUpdateIncomingLettersInterval
        {
            get
            {
                var interval = GetValue<int>("TimerToUpdateIncomingLettersInterval");
                if (interval != 0)
                    return interval * 60000;   // convert to minute
                else
                    return Int32.MaxValue;
            }
        }

        public string PathForAutomationLetterTemplates=> System.IO.Path.Combine(System.Web.HttpRuntime.AppDomainAppPath, $"Files\\AutomationLetterTemplates");

        public string PathForFilesFolder => System.IO.Path.Combine(System.Web.HttpRuntime.AppDomainAppPath, $"Files");


        private static T GetValue<T>(string key)
        {
            var value = (object)ConfigurationManager.AppSettings[key];

            if (value is T)
                return (T)value;

            try
            {
                if (Nullable.GetUnderlyingType(typeof(T)) != null)
                {
                    return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFrom(value);
                }

                return (T)Convert.ChangeType(value, typeof(T));
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        public InternetMode InternetMode
            => (InternetMode)GetValue<byte>("InternetMode");
                
    }
}