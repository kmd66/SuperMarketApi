using Kama.AppCore;
using Kama.Bonyad.Evaluation.Core.Model;
using Kama.Organization.Core.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Bonyad.Evaluation.Core.Service
{
    public interface IDepartmentService : IService
    {
        Task<Result<IEnumerable<Organization.Core.Model.Department>>> ListAsync(Organization.Core.Model.DepartmentListVM model);
    }
}
