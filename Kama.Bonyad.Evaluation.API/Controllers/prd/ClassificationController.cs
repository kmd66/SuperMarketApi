using Kama.AppCore;
using Kama.Bonyad.Evaluation.Core.Model;
using Kama.Bonyad.Evaluation.Core.Service;
using Kama.Organization.Core.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Kama.Bonyad.Evaluation.API.Controllers
{

    [RoutePrefix("api/v1/Classification")]
    public class ClassificationController : BaseApiController<IClassificationService>
    {

        public ClassificationController(IClassificationService service) : base(service)
        {
        }

        [HttpPost, Route("Add")]
        public Task<Result<Classification>> Add(Classification model)
            => _service.AddAsync(model);

        [HttpPost, Route("Edit")]
        public Task<Result<Classification>> Edit(Classification model)
            => _service.EditAsync(model);

        [HttpPost, Route("Delete")]
        public Task<Result> Delete(Classification model)
            => _service.DeleteAsync(model);

        [HttpPost, Route("Get")]
        public Task<Result<Classification>> Get(Classification model)
            => _service.GetAsync(model);

        [HttpPost, Route("List")]
        public Task<Result<IEnumerable<Classification>>> List(ClassificationVM model)
            => _service.ListAsync(model);
    }
}