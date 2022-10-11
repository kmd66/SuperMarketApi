using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kama.Bonyad.Evaluation.Core
{
    public interface IRequestInfo : AppCore.IRequestInfo
    {
        Organization.Core.Model.UserType UserType { get; }

    }
}
