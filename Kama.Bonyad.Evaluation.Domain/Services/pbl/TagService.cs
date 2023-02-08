using Kama.Bonyad.Evaluation.Core.DataSource;
using Kama.Bonyad.Evaluation.Core.Model;
using Kama.Bonyad.Evaluation.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kama.Bonyad.Evaluation.Domain.Services
{
    class TagService : Service<ITagDataSource>, ITagService
    {
        public TagService(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        public async Task<AppCore.Result<Tag>> AddAsync(Tag model)
        {
            var validation = await _ValidateForSave(model);
            if (!validation.Success)
                return AppCore.Result<Tag>.Failure(message: validation.Message);
            return await _dataSource.AddAsync(model);
        }

        public Task<AppCore.Result> DeleteAsync(Tag model)
            => _dataSource.DeleteAsync(model);

        public Task<AppCore.Result<IEnumerable<Tag>>> ListAsync(TagVM model)
            => _dataSource.ListAsync(model);

        private async Task<AppCore.Result<Tag>> _ValidateForSave(Tag model)
        {
            if (string.IsNullOrEmpty(model.TagName))
                return AppCore.Result<Tag>.Failure(message: "نام وارد نشده است");
            if (model.ItemID == 0)
                return AppCore.Result<Tag>.Failure(message: "ProductID null");

            return AppCore.Result<Tag>.Successful();
        }
    }
}
