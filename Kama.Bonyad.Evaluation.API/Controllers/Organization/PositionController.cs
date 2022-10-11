using Kama.Bonyad.Evaluation.Core.Model;
//using Kama.Organization.Core.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using mdl = Kama.Bonyad.Evaluation.Core.Model;
using srv = Kama.Bonyad.Evaluation.Core.Service;

namespace Kama.Bonyad.Evaluation.API.Controllers
{
    [RoutePrefix("api/v1/position")]
    public class PositionController : BaseApiController<srv.IPositionService>
    {
        public PositionController(srv.IPositionService service) 
            : base(service)
        {
        }

        [HttpPost, Route("Add")]
        public Task<AppCore.Result<Organization.Core.Model.Position>> Add(Organization.Core.Model.Position model)
            => _service.AddAsync(model);

        [HttpPost, Route("Edit")]
        public Task<AppCore.Result<Organization.Core.Model.Position>> Edit(Organization.Core.Model.Position model)
            => _service.EditAsync(model);

        [HttpPost, Route("List")]
        public Task<AppCore.Result<IEnumerable<EvaluationPosition>>> List(Organization.Core.Model.PositionListVM model)
            => _service.ListAsync(model);

      

        [HttpPost, Route("Delete/{id:guid}")]
        public Task<AppCore.Result> Delete(Guid id)
            => _service.DeleteAsync(id);
    }
}