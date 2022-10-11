using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Kama.AppCore;
using System.Linq;
using Kama.Bonyad.Evaluation.Core.Service;
using Kama.Organization.Core.Model;

namespace Kama.Bonyad.Evaluation.Domain.Services
{
    class DepartmentService : Service, IDepartmentService
    {
        public DepartmentService(AppCore.IOC.IContainer container
                                , Organization.ApiClient.Interface.IDepartmentService departmentService
                                , Core.IRequestInfo requestInfo)
            : base(container)
        {
            _departmentService = departmentService;
            _requestInfo = requestInfo;
        }
        private readonly Organization.ApiClient.Interface.IDepartmentService _departmentService;
        private readonly Core.IRequestInfo _requestInfo;

        public async Task<Result<IEnumerable<Department>>> ListAsync(DepartmentListVM model)
        {
            return await _departmentService.List(model);
        }
    }
}
