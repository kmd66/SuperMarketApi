using Kama.AppCore;
using Kama.Bonyad.Evaluation.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Kama.Bonyad.Evaluation.Infrastructure.DAL.DataSources
{
    class ClassificationDataSource : DataSource, Core.DataSource.IClassificationDataSource
    {
        public ClassificationDataSource(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        private async Task<AppCore.Result<Core.Model.Classification>> ModifyAsync(bool isNewRecord, Classification model)
        {
            try
            {
                var result = (await _dbPRD.ModifyClassificationAsync(
                    _isNewRecord: isNewRecord,
                    _guID:model.GuID,
                    _name:model.Name,
                    _comment: model.Comment,
                    _parentID:model.ParentID
                    )).ToActionResult<Core.Model.Classification>();

                if (result.Success)
                    return await GetAsync(new Classification { GuID= model.GuID });

                return result;
            }
            catch (Exception e)
            {
                return LogError<Core.Model.Classification>(e);
            }
        }

        public Task<Result<Classification>> AddAsync(Classification model)
        {
            model.GuID = Guid.NewGuid();
            return ModifyAsync(true, model);
        }

        public Task<Result<Classification>> EditAsync(Classification model)
            => ModifyAsync(false, model);

        public async Task<Result> DeleteAsync(Classification model)
        {
            try
            {
                var result = (await _dbPRD.DeleteClassificationAsync(_guID: model.GuID)).ToActionResult(); 

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<Result<Classification>> GetAsync(Classification model)
        {
            try
            {
                var result = (await _dbPRD.GetClassificationAsync(_guID: model.GuID))
                                .ToActionResult<Classification>();
                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<Result<IEnumerable<Classification>>> ListAsync(ClassificationVM model)
        {
            try
            {
                var result = (await _dbPRD.GetClassificationsAsync(
                    _parentID: model.ParentID,
                    _name:model.Name,
                    _comment: model.Comment,
                    _allChild:model.AllChild,
                    _firstNode:model.FirstNode,
                    _lastNode: model.LastNode,
                    _pageIndex:model.PageIndex,
                    _pageSize: model.PageSize
                    
                    )).ToListActionResult<Classification>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}
