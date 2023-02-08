using Kama.AppCore;
using Kama.Bonyad.Evaluation.Core.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Bonyad.Evaluation.Core.DataSource
{
    public interface IItemDataSource : IDataSource
    {
        Task<Result<Item>> AddAsync(Item model);

        Task<Result<Item>> EditAsync(Item model);

        Task<Result> DeleteAsync(Item model);

        Task<Result<Item>> GetAsync(Item model);

        Task<Result<IEnumerable<Item>>> ListAsync(ItemVM model);
    }
}
