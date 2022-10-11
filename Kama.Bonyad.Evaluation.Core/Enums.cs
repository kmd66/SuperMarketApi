using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kama.Bonyad.Evaluation.Core
{
    public enum WebServiceLocality : byte
    {
        Unknown = 0,

        Local = 1,
        MainServer = 2
    }

    public enum InternetMode : byte
    {
        Unknown = 0,

        داخلی = 1,
        اینترنتی = 2
    }
}
