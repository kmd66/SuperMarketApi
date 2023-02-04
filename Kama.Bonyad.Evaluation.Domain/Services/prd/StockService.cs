using Kama.AppCore;
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

        private static int _maxCount = 50;

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

        public async Task<AppCore.Result> AddListAsync(List<Stock> model)
        {
            if(model.Count == 0 || model.Count > _maxCount)
                return AppCore.Result<Stock>.Failure(message: "modelCount null");

            foreach (var item in model)
            {
                var validation = await _ValidateForSave(item);
                if (!validation.Success)
                    return AppCore.Result<Stock>.Failure(message: validation.Message);
            }

            List<List<Guid>> guids = new List<List<Guid>>();
            foreach (var item in model)
            {
                List<Guid> guid = new List<Guid>();
                for (int i = 0; i < item.Count; i++)
                    guid.Add(Guid.NewGuid());
                guids.Add(guid);
            }


            return await _dataSource.AddListAsync(model, guids);
        }

        public Task<Result> ChangeState(StockChengState model)
        {
            if (model.ID == 0)
                return AppCore.Result.FailureAsync(message: "ID null");
            if (model.State != DocState.مرجوع_به_تولید_کننده && model.State != DocState.دورریز)
                return AppCore.Result.FailureAsync(message: "State null");

            return _dataSource.ChangeState(model);
        }

        public Task<AppCore.Result<IEnumerable<Stock>>> GetAsync(Stock model)
            => _dataSource.GetAsync(model);

        public Task<AppCore.Result<IEnumerable<Stock>>> ListAsync(StockVM model)
        {
            switch (model.ActionState)
            {
                case StockActionState.موجودی_انبار:
                case StockActionState.انقضا:
                    return _dataSource.ListAsync(model);
                case StockActionState.هشدار_موجودی:
                case StockActionState.هشدار_انقضا:
                    return _dataSource.ListMinimumToAlertAsync(model);
                default:
                    return _dataSource.ListAsync(model);
            }
        }


        public async Task<Result> SaleInPerson(List<Stock> model)
        {
            if (model.Count == 0 || model.Count > _maxCount)
                return AppCore.Result<Stock>.Failure(message: "modelCount null");

            foreach (var item in model)
            {
                if (item.Count < 1)
                    return AppCore.Result<Stock>.Failure(message: "Count null");
            }

            return await _dataSource.SaleInPerson(model);
        }
        private async Task<AppCore.Result<Stock>> _ValidateForSave(Stock model)
        {
            if (model.Count < 1)
                return AppCore.Result<Stock>.Failure(message: "Count null");
            if (model.ID < 1)
                return AppCore.Result<Stock>.Failure(message: "ID null");
            if (model.Expired == null || model.Expired < DateTime.Now.AddDays(1))
                return AppCore.Result<Stock>.Failure(message: "Expired null");

            return AppCore.Result<Stock>.Successful();
        }
    }
}
