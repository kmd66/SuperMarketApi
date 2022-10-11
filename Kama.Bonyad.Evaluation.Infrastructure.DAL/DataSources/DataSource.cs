using System;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace Kama.Bonyad.Evaluation.Infrastructure.DAL
{
    abstract class DataSource
    {
        public DataSource(AppCore.IOC.IContainer container)
        {
            _container = container;
            _appSetting = _container.TryResolve<Core.IAppSetting>();
            _requestInfo = _container.TryResolve<Core.IRequestInfo>();
            _objSerializer = _container.TryResolve<AppCore.IObjectSerializer>();
            _logger = _container.TryResolve<Core.IEventLogger>();

            _dbPBL = new PBL(_appSetting.ConnectionString);
            _dbPRD = new PRD(_appSetting.ConnectionString);
        }

        protected readonly AppCore.IOC.IContainer _container;
        protected readonly Core.IAppSetting _appSetting;
        protected readonly Core.IRequestInfo _requestInfo;
        protected readonly AppCore.IObjectSerializer _objSerializer;
        protected readonly Core.IEventLogger _logger;

        protected readonly PBL _dbPBL;
        protected readonly PRD _dbPRD;

        public AppCore.Result LogError(Exception e, [CallerMemberName] string methodName = "")
        {
            if (e is SqlException)
            {
                var ex = e as SqlException;
                if (ex.Number >= 50000)
                    return AppCore.Result.Failure(message: e.Message);
            }

            //_logger?.Error(e, $"An Error Occurred in {this.GetType().Name}.{methodName}", "");
            return AppCore.Result.Failure(message: e.Message);
        }

        public AppCore.Result<T> LogError<T>(Exception e, [CallerMemberName] string methodName = "")
        {
            if (e is SqlException)
            {
                var ex = e as SqlException;
                if (ex.Number >= 50000)
                    return AppCore.Result<T>.Failure(message: e.Message);
            }

            //_logger?.Error(e, $"An Error Occurred in {this.GetType().Name}.{methodName}", "");
            return AppCore.Result<T>.Failure(message: e.Message);
        }
    }
}



