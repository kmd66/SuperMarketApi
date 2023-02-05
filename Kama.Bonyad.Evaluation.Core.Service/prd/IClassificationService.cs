using Kama.AppCore;
using Kama.Bonyad.Evaluation.Core.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Bonyad.Evaluation.Core.Service
{
    public interface IClassificationService : IService
    {
        Task<Result<Classification>> AddAsync(Classification model);

        Task<Result<Classification>> EditAsync(Classification model);

        Task<Result> DeleteAsync(Classification model);

        Task<Result<Classification>> GetAsync(Classification model);

        Task<Result<IEnumerable<Classification>>> ListAsync(ClassificationVM model);
    }
}
