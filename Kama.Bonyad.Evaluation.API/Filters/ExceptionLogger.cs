using Kama.Bonyad.Evaluation.Core;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;
using Config = System.Configuration.ConfigurationManager;

namespace Kama.Bonyad.Evaluation.API.Filters
{

    //global Logger
    public class KamaExceptionLogger : IExceptionLogger
    {
        public KamaExceptionLogger(IEventLogger logger)
            => _logger = logger;

        protected readonly IEventLogger _logger;
        public virtual Task LogAsync(ExceptionLoggerContext context,
                                     CancellationToken cancellationToken)
        {
            _logger?.Error(context.Exception, $"An Error Occurred in {context.Exception.TargetSite}", "");
            return Task.FromResult(0);
        }
    }
}