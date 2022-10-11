using Kama.AppCore;
using Kama.Bonyad.Evaluation.Core.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Bonyad.Evaluation.Core.DataSource
{
    public interface IProductClassificationDataSource : IDataSource
    {
        Task<Result<ProductClassification>> AddAsync(ProductClassification model);

        Task<Result<ProductClassification>> EditAsync(ProductClassification model);

        Task<Result> DeleteAsync(ProductClassification model);

        Task<Result<ProductClassification>> GetAsync(ProductClassification model);

        Task<Result<IEnumerable<ProductClassification>>> ListAsync(ProductClassificationVM model);
    }
}
