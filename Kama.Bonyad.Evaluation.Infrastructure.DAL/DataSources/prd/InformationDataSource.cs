using Kama.AppCore;
using Kama.Bonyad.Evaluation.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Kama.Bonyad.Evaluation.Infrastructure.DAL.DataSources
{
    class InformationDataSource : DataSource, Core.DataSource.IInformationDataSource
    {
        public InformationDataSource(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        public async Task<Result<Information>> AddAsync(Information model)
        {
            try
            {
                var result = (await _dbPRD.AddInformationAsync(
                    _text:model.Text
                    )).ToActionResult<Information>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<Result<IEnumerable<Information>>> ListAsync(InformationVM model)
        {
            try
            {
                var result = (await _dbPRD.GetInformationsAsync(
                    _text:model.Text,
                    _pageIndex:model.PageIndex,
                    _pageSize:model.PageSize
                    )).ToListActionResult<Information>();
                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
