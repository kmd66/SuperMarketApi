using Kama.AppCore;
using Kama.Bonyad.Evaluation.Core.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Bonyad.Evaluation.Core.DataSource
{
    public interface IStockDataSource : IDataSource
    {
        Task<Result<Stock>> AddAsync(Stock model, List<Guid> ids);
        Task<Result> AddListAsync(List<Stock> model, List<List<Guid>> listIds);

        Task<Result<IEnumerable<Stock>>> GetAsync(Stock model);

        Task<Result<IEnumerable<Stock>>> ListAsync(StockVM model);

        Task<Result<IEnumerable<Stock>>> ListMinimumToAlertAsync(StockVM model);

        Task<Result> ChangeState(StockChengState model);
    }
}
