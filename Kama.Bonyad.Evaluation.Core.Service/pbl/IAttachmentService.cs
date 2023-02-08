using Kama.AppCore;
using Kama.Bonyad.Evaluation.Core.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Bonyad.Evaluation.Core.Service
{
    public interface IAttachmentService : IService
    {
        Task<Result<Attachment>> AddAsync(Attachment model);

        Task<Result<Attachment>> EditAsync(Attachment model);

        Task<Result> DeleteAsync(long id);

        Task<Result<Attachment>> GetAsync(long id);

        Task<Result<IEnumerable<Attachment>>> ListAsync(AttachmentListVM model);
    }
}
