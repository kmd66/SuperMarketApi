using Kama.AppCore;
using Kama.Bonyad.Evaluation.Core.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Bonyad.Evaluation.Core.Service
{
    public interface IInformationService : IService
    {
        Task<Result<Information>> AddAsync(Information model);

        Task<Result<IEnumerable<Information>>> ListAsync(InformationVM model);

        Task<Result<Information>> AddClassificationInformationAsync(Information model);

        Task<Result<IEnumerable<Information>>> ListClassificationInformationAsync(InformationVM model);

        Task<Result> DeleteClassificationInformationAsync(Information model);

    }
}
