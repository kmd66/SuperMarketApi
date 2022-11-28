using Kama.AppCore;
using Kama.Bonyad.Evaluation.Core.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Bonyad.Evaluation.Core.DataSource
{
    public interface IBrandDataSource : IDataSource
    {
        Task<Result<Brand>> AddAsync(Brand model);

        Task<Result<Brand>> EditAsync(Brand model);

        Task<Result> DeleteAsync(Brand model);

        Task<Result<Brand>> GetAsync(Brand model);

        Task<Result<IEnumerable<Brand>>> ListAsync(BrandVM model);
    }
}
