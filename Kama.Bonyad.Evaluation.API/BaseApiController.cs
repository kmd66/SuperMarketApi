using Kama.Bonyad.Evaluation.Core.Service;
using System.Web.Http;

namespace Kama.Bonyad.Evaluation.API.Controllers
{
    [Attributes.Authorize]
    //[Attributes.ActivityLog]
    public class BaseApiController<T> : ApiController
        where T: IService
    {
        public BaseApiController(T service)
        {
            _service = service;
        }

        protected readonly T _service;

    }
}
