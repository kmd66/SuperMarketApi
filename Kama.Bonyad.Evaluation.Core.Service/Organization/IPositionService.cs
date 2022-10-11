using Kama.AppCore;
using Kama.Bonyad.Evaluation.Core.Model;
using Kama.Organization.Core.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Bonyad.Evaluation.Core.Service
{
    public interface IPositionService : IService
    {
        Task<AppCore.Result<Organization.Core.Model.Position>> AddAsync(Organization.Core.Model.Position model);

        Task<AppCore.Result<Organization.Core.Model.Position>> EditAsync(Organization.Core.Model.Position user);

        Task<Result<IEnumerable<EvaluationPosition>>> ListAsync(PositionListVM model);

        Task<Result> DeleteAsync(Guid id);
    }
}
