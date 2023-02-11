using Kama.Bonyad.Evaluation.Core.DataSource;
using Kama.Bonyad.Evaluation.Core.Model;
using Kama.Bonyad.Evaluation.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kama.Bonyad.Evaluation.Domain.Services
{
    class DepoService : Service<IDepoDataSource>, IDepoService
    {
        public DepoService(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        #region ورود به انبار

        public async Task<AppCore.Result<Depo>> EnterStorageAsync(Depo model)
        {
            var validation = await _ValidateForSave(model);
            if (!validation.Success)
                return AppCore.Result<Depo>.Failure(message: validation.Message);

            List<Guid> documentGuID = new List<Guid>();
            for (int i = 0; i < model.Number; i++)
                documentGuID.Add(Guid.NewGuid());

            return await _dataSource.EnterStorageAsync(model, documentGuID);
        }


        private async Task<AppCore.Result<Depo>> AddAsync(Depo model)
        {
            var validation = await _ValidateForSave(model);
            if (!validation.Success)
                return AppCore.Result<Depo>.Failure(message: validation.Message);
            return await _dataSource.AddAsync(model);
        }

        #endregion

        public Task<AppCore.Result> DeleteAsync(Depo model)
            => _dataSource.DeleteAsync(model);

        public Task<AppCore.Result<Depo>> GetAsync(Depo model)
            => _dataSource.GetAsync(model);

        public Task<AppCore.Result<IEnumerable<Depo>>> ListAsync(DepoVM model)
            => _dataSource.ListAsync(model);

        public Task<AppCore.Result<IEnumerable<DepoIndex>>> DepoIndexListAsync(DepoVM model)
            => _dataSource.DepoIndexListAsync(model);

        private async Task<AppCore.Result<Depo>> _ValidateForSave(Depo model)
        {
            if (model.ItemID == 0)
                return AppCore.Result<Depo>.Failure(message: "ItemID null");

            if (model.Number == 0)
                return AppCore.Result<Depo>.Failure(message: "Number null");

            if (model.PriceBuy == 0)
                return AppCore.Result<Depo>.Failure(message: "PriceBuy null");

            if (model.Expired < DateTime.Now.AddDays(1))
                return AppCore.Result<Depo>.Failure(message: "Expired null");

            return AppCore.Result<Depo>.Successful();
        }
    }
}
