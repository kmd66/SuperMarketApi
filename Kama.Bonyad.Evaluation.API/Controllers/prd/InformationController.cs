using Kama.AppCore;
using Kama.Bonyad.Evaluation.Core.Model;
using Kama.Bonyad.Evaluation.Core.Service;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Kama.Bonyad.Evaluation.API.Controllers
{

    [RoutePrefix("api/v1/Information")]
    public class InformationController : BaseApiController<IInformationService>
    {

        public InformationController(IInformationService service) : base(service)
        {
        }

        [HttpPost, Route("Add")]
        public Task<Result<Information>> Add(Information model)
            => _service.AddAsync(model);

        [HttpPost, Route("List")]
        public Task<Result<IEnumerable<Information>>> List(InformationVM model)
            => _service.ListAsync(model);

        [HttpPost, Route("AddClassificationInformation")]
        public Task<Result<Information>> AddClassificationInformation(Information model)
            => _service.AddClassificationInformationAsync(model);

        [HttpPost, Route("ListClassificationInformation")]
        public Task<Result<IEnumerable<Information>>> ListClassificationInformation(InformationVM model)
            => _service.ListClassificationInformationAsync(model);

        [HttpPost, Route("DeleteClassificationInformation")]
        public Task<Result> DeleteClassificationInformation(Information model)
            => _service.DeleteClassificationInformationAsync(model);

    }
}