using Kama.Bonyad.Evaluation.Core.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Bonyad.Evaluation.Core.DataSource
{
    public interface IFlowDataSource : IDataSource
    {
        Task<AppCore.Result> AddAsync(RecognitionFlow flow, AppCore.IActivityLog log);

        Task<AppCore.Result<IEnumerable<T>>> ListAsync<T>(int documentId) where T : class, new();
    }
}
