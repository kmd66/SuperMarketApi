using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Kama.Bonyad.Evaluation.Domain
{
    abstract class Service
    {
        public Service(AppCore.IOC.IContainer container)
        {
            _container = container;

            try
            {
                _logger = _container.Resolve<Core.IEventLogger>();
            }
            catch
            {
            }
        }

        protected readonly AppCore.IOC.IContainer _container;
        protected readonly Core.IEventLogger _logger;

        protected int AppError(int code)
        {
            var strCode = $"-20{Math.Abs(code)}";
            int result = 0;
            int.TryParse(strCode, out result);
            return result;
        }

        protected string ValidateModel(Core.Model.Model model)
        {
            var context = new System.ComponentModel.DataAnnotations.ValidationContext(model, serviceProvider: null, items: null);
            var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            var result = System.ComponentModel.DataAnnotations.Validator.TryValidateObject(model, context, results, true);

            if (!result)
            {
                List<string> errors = new List<string>();
                results.ForEach(x => errors.Add(x.ErrorMessage));
                return string.Join("&&", errors);
            }

            return null;
        }

        protected string ValidateModel(Organization.Core.Model.Model model)
        {
            var context = new System.ComponentModel.DataAnnotations.ValidationContext(model, serviceProvider: null, items: null);
            var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            var result = System.ComponentModel.DataAnnotations.Validator.TryValidateObject(model, context, results, true);

            if (!result)
            {
                List<string> errors = new List<string>();
                results.ForEach(x => errors.Add(x.ErrorMessage));
                return string.Join("&&", errors);
            }

            return null;
        }
    }

    abstract class Service<TDataSource> : Service
        where TDataSource : Core.DataSource.IDataSource
    {
        public Service(AppCore.IOC.IContainer container)
            : base(container)
        {
            try
            {
                _dataSource = _container.Resolve<TDataSource>();
            }
            catch
            {
            }
        }

        protected readonly TDataSource _dataSource;

    }

}