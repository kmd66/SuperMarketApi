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
    class InformationService : Service<IInformationDataSource>, IInformationService
    {
        public InformationService(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        private static int _maxCount = 50;

        public async Task<AppCore.Result<Information>> AddAsync(Information model)
        {
            var validation = await _ValidateForSave(model);
            if (!validation.Success)
                return AppCore.Result<Information>.Failure(message: validation.Message);

            return await _dataSource.AddAsync(model);
        }

        public Task<Result<IEnumerable<Information>>> ListAsync(InformationVM model)
            => _dataSource.ListAsync(model);

        private async Task<AppCore.Result<Information>> _ValidateForSave(Information model)
        {
            if (string.IsNullOrEmpty(model.Text))
                return AppCore.Result<Information>.Failure(message: "Text null");

            return AppCore.Result<Information>.Successful();
        }

    }
}
