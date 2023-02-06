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
            var validation = await _ValidateForSave(model, true);
            if (!validation.Success)
                return AppCore.Result<Product>.Failure(message: validation.Message);
            return await _dataSource.AddAsync(model);
        }

        public Task<AppCore.Result<Product>> EditAsync(Product model)
        {
            var validation = _ValidateForSave(model,false);
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

        private async Task<AppCore.Result<Product>> _ValidateForSave(Product model,bool addState)
        {
            if (string.IsNullOrEmpty(model.FaName))
                return AppCore.Result<Product>.Failure(message: "نام وارد نشده است");
            if (string.IsNullOrEmpty(model.EnName))
                return AppCore.Result<Product>.Failure(message: "نام انگلیسی وارد نشده است");

            if (model.ClassificationID == 0 && addState)
                return AppCore.Result<Product>.Failure(message: "والد وارد نشده است");
            if (model.BrandID == 0 && addState)
                return AppCore.Result<Product>.Failure(message: "برند وارد نشده است");

            if (string.IsNullOrEmpty(model.Information))
                model.Information = "{}";

                return AppCore.Result<Product>.Successful();
        }
    }
}
