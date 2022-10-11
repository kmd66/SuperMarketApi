using Swashbuckle.Application;
using System.Web.Http;

namespace Kama.Bonyad.Evaluation.API
{
    public class SwaggerConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableSwagger(c =>
            {
                c.SchemaId(x => x.FullName);

                c.SingleApiVersion("v1", "Kama.Bonyad.Evaluation.API");
            })
            .EnableSwaggerUi(c =>
            {
            });
        }
    }
}
