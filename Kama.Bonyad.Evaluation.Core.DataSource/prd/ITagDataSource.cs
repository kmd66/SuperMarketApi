using Kama.AppCore;
using Kama.Bonyad.Evaluation.Core.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Bonyad.Evaluation.Core.DataSource
{
    public interface ITagDataSource : IDataSource
    {
        Task<Result<Tag>> AddAsync(Tag model);

        Task<Result> DeleteAsync(Tag model);

        Task<Result<IEnumerable<Tag>>> ListAsync(TagVM model);
    }
}
