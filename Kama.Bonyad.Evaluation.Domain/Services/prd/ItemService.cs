using Kama.Bonyad.Evaluation.Core.DataSource;
using Kama.Bonyad.Evaluation.Core.Model;
using Kama.Bonyad.Evaluation.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kama.Bonyad.Evaluation.Domain.Services
{
    class ItemService : Service<IItemDataSource>, IItemService
    {
        public ItemService(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        public async Task<AppCore.Result<Item>> AddAsync(Item model)
        {
            var validation = await _ValidateForSave(model, true);
            if (!validation.Success)
                return AppCore.Result<Item>.Failure(message: validation.Message);
            return await _dataSource.AddAsync(model);
        }

        public Task<AppCore.Result<Item>> EditAsync(Item model)
        {
            var validation = _ValidateForSave(model,false);
            if (!validation.Result.Success)
                return AppCore.Result<Item>.FailureAsync(message: validation.Result.Message);

            return _dataSource.EditAsync(model);
        }

        public Task<AppCore.Result> DeleteAsync(Item model)
            => _dataSource.DeleteAsync(model);

        public Task<AppCore.Result<Item>> GetAsync(Item model)
            => _dataSource.GetAsync(model);

        public Task<AppCore.Result<IEnumerable<Item>>> ListAsync(ItemVM model)
            => _dataSource.ListAsync(model);

        private async Task<AppCore.Result<Item>> _ValidateForSave(Item model,bool addState)
        {
            if (string.IsNullOrEmpty(model.FaName))
                return AppCore.Result<Item>.Failure(message: "نام وارد نشده است");
            if (string.IsNullOrEmpty(model.EnName))
                return AppCore.Result<Item>.Failure(message: "نام انگلیسی وارد نشده است");

            if (model.ClassificationID == 0 && addState)
                return AppCore.Result<Item>.Failure(message: "والد وارد نشده است");
            if (model.BrandID == 0 && addState)
                return AppCore.Result<Item>.Failure(message: "برند وارد نشده است");

            if (string.IsNullOrEmpty(model.Information))
                model.Information = "{}";

                return AppCore.Result<Item>.Successful();
        }
    }
}
