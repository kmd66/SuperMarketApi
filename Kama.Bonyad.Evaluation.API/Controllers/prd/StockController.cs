using Kama.AppCore;
using Kama.Bonyad.Evaluation.Core.Model;
using Kama.Bonyad.Evaluation.Core.Service;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Kama.Bonyad.Evaluation.API.Controllers
{

    [RoutePrefix("api/v1/Stock")]
    public class StockController : BaseApiController<IStockService>
    {

        public StockController(IStockService service) : base(service)
        {
        }

        [HttpPost, Route("Add")]
        public Task<Result<Stock>> Add(Stock model)
            => _service.AddAsync(model);

        [HttpPost, Route("Get")]
        public Task<Result<IEnumerable<Stock>>> Get(Stock model)
            => _service.GetAsync(model);

        [HttpPost, Route("List")]
        public Task<Result<IEnumerable<Stock>>> List(Stock model)
            => _service.ListAsync(model);
    }
}