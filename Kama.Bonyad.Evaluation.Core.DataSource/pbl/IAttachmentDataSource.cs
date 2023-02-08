using Kama.AppCore;
using Kama.Bonyad.Evaluation.Core.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Bonyad.Evaluation.Core.DataSource
{
    public interface IAttachmentDataSource : IDataSource
    {
        Task<Result<Attachment>> AddAsync(Attachment attachment);

        Task<Result<Attachment>> EditAsync(Attachment attachment);

        Task<Result> DeleteAsync(long id);

        Task<Result<Attachment>> GetAsync(long id);

        Task<Result<IEnumerable<Attachment>>> ListAsync(AttachmentListVM model);
    }
}
