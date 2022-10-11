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

    [RoutePrefix("api/v1/Product")]
    public class ProductController : BaseApiController<IProductService>
    {

        public ProductController(IProductService service) : base(service)
        {
        }

        [HttpPost, Route("Add")]
        public Task<Result<Product>> Add(Product model)
            => _service.AddAsync(model);

        [HttpPost, Route("Edit")]
        public Task<Result<Product>> Edit(Product model)
            => _service.EditAsync(model);

        [HttpPost, Route("Delete")]
        public Task<Result> Delete(Product model)
            => _service.DeleteAsync(model);

        [HttpPost, Route("Get")]
        public Task<Result<Product>> Get(Product model)
            => _service.GetAsync(model);

        [HttpPost, Route("List")]
        public Task<Result<IEnumerable<Product>>> List(ProductVM model)
            => _service.ListAsync(model);
    }
}