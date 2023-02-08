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

    [RoutePrefix("api/v1/Tag")]
    public class TagController : BaseApiController<ITagService>
    {

        public TagController(ITagService service) : base(service)
        {
        }

        [HttpPost, Route("Add")]
        public Task<Result<Tag>> Add(Tag model)
            => _service.AddAsync(model);

        [HttpPost, Route("Delete")]
        public Task<Result> Delete(Tag model)
            => _service.DeleteAsync(model);

        [HttpPost, Route("List")]
        public Task<Result<IEnumerable<Tag>>> List(TagVM model)
            => _service.ListAsync(model);
    }
}