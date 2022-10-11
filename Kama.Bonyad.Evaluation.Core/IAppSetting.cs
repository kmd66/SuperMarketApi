using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kama.Bonyad.Evaluation.Core
{
    public interface IAppSetting
    {
        string ConnectionString { get; }

        Guid ApplicationID { get; }

        AppCore.DeploymentMode DeploymentMode { get; }

        string OrganizationHost { get; }

        string MailServiceHost { get; }

        string SmsServiceHost { get; }

        string PdfServiceHost { get; }

        string H2pjsHost { get; }

        WebServiceLocality WebServiceLocality { get; }

        string AutomationServiceUrl { get; }

        int FollowingLetterAutomationTimerInterval { get; }

        string PathForFilesFolder { get;  }

        string PathForAutomationLetterTemplates { get; }

       InternetMode InternetMode { get; }
    }
}
