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

    [RoutePrefix("api/v1/Item")]
    public class ItemController : BaseApiController<IItemService>
    {

        public ItemController(IItemService service) : base(service)
        {
        }

        [HttpPost, Route("Add")]
        public Task<Result<Item>> Add(Item model)
            => _service.AddAsync(model);

        [HttpPost, Route("Edit")]
        public Task<Result<Item>> Edit(Item model)
            => _service.EditAsync(model);

        [HttpPost, Route("Delete")]
        public Task<Result> Delete(Item model)
            => _service.DeleteAsync(model);

        [HttpPost, Route("Get")]
        public Task<Result<Item>> Get(Item model)
            => _service.GetAsync(model);

        [HttpPost, Route("List")]
        public Task<Result<IEnumerable<Item>>> List(ItemVM model)
            => _service.ListAsync(model);
    }
}