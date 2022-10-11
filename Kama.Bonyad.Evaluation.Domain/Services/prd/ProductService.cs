using Kama.Bonyad.Evaluation.Core.DataSource;
using Kama.Bonyad.Evaluation.Core.Model;
using Kama.Bonyad.Evaluation.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kama.Bonyad.Evaluation.Domain.Services
{
    class ProductService : Service<IProductDataSource>, IProductService
    {
        public ProductService(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        public async Task<AppCore.Result<Product>> AddAsync(Product model)
        {
            var validation = await _ValidateForSave(model);
            if (!validation.Success)
                return AppCore.Result<Product>.Failure(message: validation.Message);
            return await _dataSource.AddAsync(model);
        }

        public Task<AppCore.Result<Product>> EditAsync(Product model)
        {
            var validation = _ValidateForSave(model);
            if (!validation.Result.Success)
                return AppCore.Result<Product>.FailureAsync(message: validation.Result.Message);

            return _dataSource.EditAsync(model);
        }

        public Task<AppCore.Result> DeleteAsync(Product model)
            => _dataSource.DeleteAsync(model);

        public Task<AppCore.Result<Product>> GetAsync(Product model)
            => _dataSource.GetAsync(model);

        public Task<AppCore.Result<IEnumerable<Product>>> ListAsync(ProductVM model)
            => _dataSource.ListAsync(model);

        private async Task<AppCore.Result<Product>> _ValidateForSave(Product model)
        {
            if (string.IsNullOrEmpty(model.Name))
                return AppCore.Result<Product>.Failure(message: "نام وارد نشده است");
            if (string.IsNullOrEmpty(model.Comment))
                return AppCore.Result<Product>.Failure(message: "توضیح وارد نشده است");
            if (model.ParentID == 0)
                return AppCore.Result<Product>.Failure(message: "والد وارد نشده است");
            if (model.Price == 0)
                return AppCore.Result<Product>.Failure(message: "قیمت وارد نشده است");
            if (model.Price < model.Discount)
                return AppCore.Result<Product>.Failure(message: "قیمت کمتر از تخفیف است");

            if (string.IsNullOrEmpty(model.Information))
                model.Information = "{}";

                return AppCore.Result<Product>.Successful();
        }
    }
}
