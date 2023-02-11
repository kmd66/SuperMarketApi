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

    [RoutePrefix("api/v1/Depo")]
    public class DepoController : BaseApiController<IDepoService>
    {

        public DepoController(IDepoService service) : base(service)
        {
        }

        #region ورود به انبار


        [HttpPost, Route("EnterStorageAsync")]
        public Task<Result<Depo>> EnterStorageAsync(Depo model)
            => _service.EnterStorageAsync(model);

        #endregion

        [HttpPost, Route("Delete")]
        public Task<Result> Delete(Depo model)
            => _service.DeleteAsync(model);

        [HttpPost, Route("Get")]
        public Task<Result<Depo>> Get(Depo model)
            => _service.GetAsync(model);

        [HttpPost, Route("List")]
        public Task<Result<IEnumerable<Depo>>> List(DepoVM model)
            => _service.ListAsync(model);

        [HttpPost, Route("DepoIndexList")]
        public Task<Result<IEnumerable<DepoIndex>>> DepoIndexList(DepoVM model)
            => _service.DepoIndexListAsync(model);
    }
}