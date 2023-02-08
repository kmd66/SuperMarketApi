using Kama.AppCore;
using Kama.Bonyad.Evaluation.Core.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Bonyad.Evaluation.Core.Service
{
    public interface ITagService : IService
    {
        Task<Result<Tag>> AddAsync(Tag model);

        Task<Result> DeleteAsync(Tag model);


        Task<Result<IEnumerable<Tag>>> ListAsync(TagVM model);
    }
}
