using Kama.Bonyad.Evaluation.Core.DataSource;
using Kama.Bonyad.Evaluation.Core.Model;
using Kama.Bonyad.Evaluation.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kama.Bonyad.Evaluation.Domain.Services
{
    class ClassificationService : Service<IClassificationDataSource>, IClassificationService
    {
        public ClassificationService(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        public async Task<AppCore.Result<Classification>> AddAsync(Classification model)
        {
            var validation = await _ValidateForSave(model);
            if (!validation.Success)
                return AppCore.Result<Classification>.Failure(message: validation.Message);
            return await _dataSource.AddAsync(model);
        }

        public Task<AppCore.Result<Classification>> EditAsync(Classification model)
        {
            var validation = _ValidateForSave(model);
            if (!validation.Result.Success)
                return AppCore.Result<Classification>.FailureAsync(message: validation.Result.Message);

            return _dataSource.EditAsync(model);
        }

        public Task<AppCore.Result> DeleteAsync(Classification model)
            => _dataSource.DeleteAsync(model);

        public Task<AppCore.Result<Classification>> GetAsync(Classification model)
            => _dataSource.GetAsync(model);

        public Task<AppCore.Result<IEnumerable<Classification>>> ListAsync(ClassificationVM model)
            => _dataSource.ListAsync(model);

        private async Task<AppCore.Result<Classification>> _ValidateForSave(Classification model)
        {
            if(string.IsNullOrEmpty(model.Name))
                return AppCore.Result<Classification>.Failure(message: "نام وارد نشده است");

            return AppCore.Result<Classification>.Successful();
        }
    }
}
