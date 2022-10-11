using Kama.Bonyad.Evaluation.Core.Service;
using Kama.Organization.Core.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Kama.Bonyad.Evaluation.API.Controllers
{
    [RoutePrefix("api/v1/department")]
    public class DepartmentController : BaseApiController<IDepartmentService>
    {
        public DepartmentController(IDepartmentService service)
            : base(service)
        {
        }

        [HttpPost, Route("List")]
        public Task<AppCore.Result<IEnumerable<Department>>> List(DepartmentListVM model)
            => _service.ListAsync(model);
    }
}