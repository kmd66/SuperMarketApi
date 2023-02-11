using Kama.AppCore;
using Kama.Bonyad.Evaluation.Core.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Bonyad.Evaluation.Core.Service
{
    public interface IDepoService : IService
    {
        Task<Result<Depo>> EnterStorageAsync(Depo model);

        Task<Result> DeleteAsync(Depo model);

        Task<Result<Depo>> GetAsync(Depo model);

        Task<Result<IEnumerable<Depo>>> ListAsync(DepoVM model);

        Task<Result<IEnumerable<DepoIndex>>> DepoIndexListAsync(DepoVM model);
    }
}
