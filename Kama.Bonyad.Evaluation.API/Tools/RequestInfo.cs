using Kama.Bonyad.Evaluation.Core;
using System;
using System.Web;

namespace Kama.Bonyad.Evaluation.API.Tools
{
    class RequestInfo : AppCore.RequestInfo, IRequestInfo
    {
        public Organization.Core.Model.UserType UserType
        {
            get
            {
                byte val = 0;
                byte.TryParse(GetValueFromToken("UserType"), out val);
                return (Organization.Core.Model.UserType)val;
            }
        }
    }
}
