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

    [RoutePrefix("api/v1/Attachment")]
    public class AttachmentController : BaseApiController<Core.Service.IAttachmentService>
    {

        public AttachmentController(Core.Service.IAttachmentService service) : base(service)
        {
        }

        [HttpPost, Route("Add")]
        public Task<Result<Core.Model.Attachment>> Add(Core.Model.Attachment model)
            => _service.AddAsync(model);

        [HttpPost, Route("Edit")]
        public Task<Result<Core.Model.Attachment>> Edit(Core.Model.Attachment model)
            => _service.EditAsync(model);

        [HttpPost, Route("Delete")]
        public Task<Result> Delete(Core.Model.Attachment model)
            => _service.DeleteAsync(model.ID);

        [HttpPost, Route("Get")]
        public Task<Result<Core.Model.Attachment>> Get(Core.Model.Attachment model)
            => _service.GetAsync(model.ID);

        [HttpPost, Route("List")]
        public Task<Result<IEnumerable<Core.Model.Attachment>>> List(Core.Model.AttachmentListVM model)
            => _service.ListAsync(model);
    }
}