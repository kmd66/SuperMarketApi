using Kama.AppCore;
using Kama.Bonyad.Evaluation.Core.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Bonyad.Evaluation.Core.Service
{
    public interface IProductClassificationService : IService
    {
        Task<Result<ProductClassification>> AddAsync(ProductClassification model);

        Task<Result<ProductClassification>> EditAsync(ProductClassification model);

        Task<Result> DeleteAsync(ProductClassification model);

        Task<Result<ProductClassification>> GetAsync(ProductClassification model);

        Task<Result<IEnumerable<ProductClassification>>> ListAsync(ProductClassificationVM model);
    }
}
