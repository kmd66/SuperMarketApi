using Kama.Bonyad.Evaluation.Core.DataSource;
using Kama.Bonyad.Evaluation.Core.Model;
using Kama.Bonyad.Evaluation.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kama.Bonyad.Evaluation.Domain.Services
{
    class BrandService : Service<IBrandDataSource>, IBrandService
    {
        public BrandService(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        public async Task<AppCore.Result<Brand>> AddAsync(Brand model)
        {
            var validation = await _ValidateForSave(model, true);
            if (!validation.Success)
                return AppCore.Result<Brand>.Failure(message: validation.Message);
            return await _dataSource.AddAsync(model);
        }

        public Task<AppCore.Result<Brand>> EditAsync(Brand model)
        {
            var validation = _ValidateForSave(model,false);
            if (!validation.Result.Success)
                return AppCore.Result<Brand>.FailureAsync(message: validation.Result.Message);

            return _dataSource.EditAsync(model);
        }

        public Task<AppCore.Result> DeleteAsync(Brand model)
            => _dataSource.DeleteAsync(model);

        public Task<AppCore.Result<Brand>> GetAsync(Brand model)
            => _dataSource.GetAsync(model);

        public Task<AppCore.Result<IEnumerable<Brand>>> ListAsync(BrandVM model)
            => _dataSource.ListAsync(model);

        private async Task<AppCore.Result<Brand>> _ValidateForSave(Brand model,bool addState)
        {
            if (string.IsNullOrEmpty(model.Name))
                return AppCore.Result<Brand>.Failure(message: "نام وارد نشده است");

            if (model.ParentID == 0 && addState)
                return AppCore.Result<Brand>.Failure(message: "والد وارد نشده است");
            
                return AppCore.Result<Brand>.Successful();
        }
    }
}
