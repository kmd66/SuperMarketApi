using Kama.AppCore;
using Kama.Bonyad.Evaluation.Core.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Bonyad.Evaluation.Core.DataSource
{
    public interface IProductDataSource : IDataSource
    {
        Task<Result<Product>> AddAsync(Product model);

        Task<Result<Product>> EditAsync(Product model);

        Task<Result> DeleteAsync(Product model);

        Task<Result<Product>> GetAsync(Product model);

        Task<Result<IEnumerable<Product>>> ListAsync(ProductVM model);
    }
}
