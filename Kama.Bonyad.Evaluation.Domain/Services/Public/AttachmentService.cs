using Kama.Bonyad.Evaluation.Core.DataSource;
using Kama.Bonyad.Evaluation.Core.Model;
using Kama.Bonyad.Evaluation.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kama.Bonyad.Evaluation.Domain.Services
{
    class AttachmentService : Service<IAttachmentDataSource>, IAttachmentService
    {
        public AttachmentService(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        public async Task<AppCore.Result<Attachment>> AddAsync(Attachment model)
        {
            var validation = await _ValidateForSave(model);
            if (!validation.Success)
                return AppCore.Result<Attachment>.Failure(message: validation.Message);

            return await _dataSource.AddAsync(model);
        }

        public Task<AppCore.Result<Attachment>> EditAsync(Attachment model)
        {
            var validation = _ValidateForSave(model);
            if (!validation.Result.Success)
                return AppCore.Result<Attachment>.FailureAsync(message: validation.Result.Message);

            return _dataSource.EditAsync(model);
        }

        public Task<AppCore.Result> DeleteAsync(long id)
            => _dataSource.DeleteAsync(id);

        public Task<AppCore.Result<Attachment>> GetAsync(long id)
            => _dataSource.GetAsync(id);

        public Task<AppCore.Result<IEnumerable<Attachment>>> ListAsync(AttachmentListVM model)
            => _dataSource.ListAsync(model);

        private async Task<AppCore.Result<Attachment>> _ValidateForSave(Attachment model)
        {
            if (string.IsNullOrEmpty(model.Url) || string.IsNullOrEmpty(model.FileName) || model.ParentID == null)
                return AppCore.Result<Attachment>.Failure(message: "اطلاعات کامل نیست");

            return AppCore.Result<Attachment>.Successful();
        }
    }
}
