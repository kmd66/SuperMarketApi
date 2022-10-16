using Kama.AppCore;
using Kama.Bonyad.Evaluation.Core.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Bonyad.Evaluation.Core.Service
{
    public interface IStockService : IService
    {
        Task<Result<Stock>> AddAsync(Stock model);

        Task<Result<IEnumerable<Stock>>> GetAsync(Stock model);

        Task<Result<IEnumerable<Stock>>> ListAsync(Stock model);
    }
}
