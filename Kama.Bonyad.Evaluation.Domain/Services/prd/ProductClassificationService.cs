using Kama.Bonyad.Evaluation.Core.DataSource;
using Kama.Bonyad.Evaluation.Core.Model;
using Kama.Bonyad.Evaluation.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kama.Bonyad.Evaluation.Domain.Services
{
    class ProductClassificationService : Service<IProductClassificationDataSource>, IProductClassificationService
    {
        public ProductClassificationService(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        public async Task<AppCore.Result<ProductClassification>> AddAsync(ProductClassification model)
        {
            var validation = await _ValidateForSave(model);
            if (!validation.Success)
                return AppCore.Result<ProductClassification>.Failure(message: validation.Message);
            return await _dataSource.AddAsync(model);
        }

        public Task<AppCore.Result<ProductClassification>> EditAsync(ProductClassification model)
        {
            var validation = _ValidateForSave(model);
            if (!validation.Result.Success)
                return AppCore.Result<ProductClassification>.FailureAsync(message: validation.Result.Message);

            return _dataSource.EditAsync(model);
        }

        public Task<AppCore.Result> DeleteAsync(ProductClassification model)
            => _dataSource.DeleteAsync(model);

        public Task<AppCore.Result<ProductClassification>> GetAsync(ProductClassification model)
            => _dataSource.GetAsync(model);

        public Task<AppCore.Result<IEnumerable<ProductClassification>>> ListAsync(ProductClassificationVM model)
            => _dataSource.ListAsync(model);

        private async Task<AppCore.Result<ProductClassification>> _ValidateForSave(ProductClassification model)
        {
            if(string.IsNullOrEmpty(model.Name))
                return AppCore.Result<ProductClassification>.Failure(message: "نام وارد نشده است");

            return AppCore.Result<ProductClassification>.Successful();
        }
    }
}
