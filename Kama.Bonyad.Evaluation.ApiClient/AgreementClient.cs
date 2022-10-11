using System;
using System.Collections.Generic;

namespace Kama.Bonyad.Evaluation.ApiClient
{
    class EvaluationClient : Library.ApiClient.Client, Interface.IEvaluationClient
    {
        public EvaluationClient(AppCore.IObjectSerializer objectSerializer, string host)
            :base(objectSerializer, host)
        {
        }

        public EvaluationClient(AppCore.IObjectSerializer objectSerializer, string host, Func<IDictionary<string, string>> defaultHeaders)
            :base(objectSerializer, host, defaultHeaders)
        {
        }
    }
}
