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

    [RoutePrefix("api/v1/ProductClassification")]
    public class ProductClassificationController : BaseApiController<IProductClassificationService>
    {

        public ProductClassificationController(IProductClassificationService service) : base(service)
        {
        }

        [HttpPost, Route("Add")]
        public Task<Result<ProductClassification>> Add(ProductClassification model)
            => _service.AddAsync(model);

        [HttpPost, Route("Edit")]
        public Task<Result<ProductClassification>> Edit(ProductClassification model)
            => _service.EditAsync(model);

        [HttpPost, Route("Delete")]
        public Task<Result> Delete(ProductClassification model)
            => _service.DeleteAsync(model);

        [HttpPost, Route("Get")]
        public Task<Result<ProductClassification>> Get(ProductClassification model)
            => _service.GetAsync(model);

        [HttpPost, Route("List")]
        public Task<Result<IEnumerable<ProductClassification>>> List(ProductClassificationVM model)
            => _service.ListAsync(model);
    }
}