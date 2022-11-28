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

    [RoutePrefix("api/v1/Brand")]
    public class BrandController : BaseApiController<IBrandService>
    {

        public BrandController(IBrandService service) : base(service)
        {
        }

        [HttpPost, Route("Add")]
        public Task<Result<Brand>> Add(Brand model)
            => _service.AddAsync(model);

        [HttpPost, Route("Edit")]
        public Task<Result<Brand>> Edit(Brand model)
            => _service.EditAsync(model);

        [HttpPost, Route("Delete")]
        public Task<Result> Delete(Brand model)
            => _service.DeleteAsync(model);

        [HttpPost, Route("Get")]
        public Task<Result<Brand>> Get(Brand model)
            => _service.GetAsync(model);

        [HttpPost, Route("List")]
        public Task<Result<IEnumerable<Brand>>> List(BrandVM model)
            => _service.ListAsync(model);
    }
}