using Kama.Bonyad.Evaluation.Core.DataSource;
using Kama.Bonyad.Evaluation.Core.Model;
using Kama.Bonyad.Evaluation.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kama.Bonyad.Evaluation.Domain.Services
{
    class StockService : Service<IStockDataSource>, IStockService
    {
        public StockService(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        public async Task<AppCore.Result<Stock>> AddAsync(Stock model)
        {
            var validation = await _ValidateForSave(model);
            if (!validation.Success)
                return AppCore.Result<Stock>.Failure(message: validation.Message);

            List<Guid> guid = new List<Guid>();
            for (int i = 0; i < model.Count; i++)
                guid.Add(Guid.NewGuid());

            return await _dataSource.AddAsync(model, guid);
        }

        public Task<AppCore.Result<IEnumerable<Stock>>> GetAsync(Stock model)
            => _dataSource.GetAsync(model);

        public Task<AppCore.Result<IEnumerable<Stock>>> ListAsync(Stock model)
            => _dataSource.ListAsync(model);

        private async Task<AppCore.Result<Stock>> _ValidateForSave(Stock model)
        {
            if (model.Count == 0)
                return AppCore.Result<Stock>.Failure(message: "Count null");
            if (model.ID == 0)
                return AppCore.Result<Stock>.Failure(message: "ID null");

            return AppCore.Result<Stock>.Successful();
        }
    }
}
