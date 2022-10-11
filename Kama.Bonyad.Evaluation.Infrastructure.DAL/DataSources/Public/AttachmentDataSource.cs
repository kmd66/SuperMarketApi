using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Kama.Bonyad.Evaluation.Infrastructure.DAL.DataSources
{
    class AttachmentDataSource : DataSource, Core.DataSource.IAttachmentDataSource
    {
        public AttachmentDataSource(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        private async Task<AppCore.Result<Core.Model.Attachment>> ModifyAsync(bool isNewRecord, Core.Model.Attachment model)
        {
            try
            {
                var result = (await _dbPBL.ModifyAttachmentAsync(
                    _isNewRecord: isNewRecord,
                    _id: model.ID,
                    _parentID: model.ParentID,
                    _type: (byte)model.Type,
                    _fileName: model.FileName,
                    _comment: model.Comment,
                    _urL: model.Url
                    )).ToActionResult<Core.Model.Attachment>();

                return result;
            }
            catch (Exception e)
            {
                return LogError<Core.Model.Attachment>(e);
            }
        }

        public Task<AppCore.Result<Core.Model.Attachment>> AddAsync(Core.Model.Attachment model)
            => ModifyAsync(true, model);

        public Task<AppCore.Result<Core.Model.Attachment>> EditAsync(Core.Model.Attachment model)
            => ModifyAsync(false, model);

        public async Task<AppCore.Result> DeleteAsync(long id)
        {
            try
            {
                var result = (await _dbPBL.DeleteAttachmentAsync(_id: id))
                                    .ToActionResult(); ;

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public async Task<AppCore.Result<Core.Model.Attachment>> GetAsync(long id)
        {
            try
            {
                var result = (await _dbPBL.GetAttachmentAsync(id))
                                .ToActionResult<Core.Model.Attachment>();
                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<IEnumerable<Core.Model.Attachment>>> ListAsync(Core.Model.AttachmentListVM model)
        {
            try
            {
                var result = (await _dbPBL.GetAttachmentsAsync(
                    _parentIDs: _objSerializer.Serialize(model.ParentIDs)
                    )).ToListActionResult<Core.Model.Attachment>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result> CreateAggregatedAsync(Core.Model.Attachment model, AppCore.IActivityLog log)
        {
            return null;
        }
    }
}
