using Kama.AppCore;
using Kama.Bonyad.Evaluation.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Kama.Bonyad.Evaluation.Infrastructure.DAL.DataSources
{
    class BrandDataSource : DataSource, Core.DataSource.IBrandDataSource
    {
        public BrandDataSource(AppCore.IOC.IContainer container
            , Core.DataSource.IAttachmentDataSource attachmentDataSource)
            : base(container)
        {
            _attachmentDataSource = attachmentDataSource;
        }
        Core.DataSource.IAttachmentDataSource _attachmentDataSource;

        private async Task<AppCore.Result<Core.Model.Brand>> ModifyAsync(bool isNewRecord, Brand model)
        {
            try
            {
                var result = (await _dbPBL.ModifyBrandAsync(
                    _isNewRecord: isNewRecord,
                    _guID:model.GuID,
                    _faName: model.FaName,
                    _enName: model.EnName,
                    _id:model.ID
                    )).ToActionResult<Core.Model.Brand>();

                if (result.Success)
                    return await GetAsync(new Brand { GuID= model.GuID });

                return result;
            }
            catch (Exception e)
            {
                return LogError<Core.Model.Brand>(e);
            }
        }

        public Task<Result<Brand>> AddAsync(Brand model)
        {
            model.GuID = Guid.NewGuid();
            return ModifyAsync(true, model);
        }

        public Task<Result<Brand>> EditAsync(Brand model)
            => ModifyAsync(false, model);

        public async Task<Result> DeleteAsync(Brand model)
        {
            try
            {
                var result = (await _dbPBL.DeleteBrandAsync(_id: model.ID))
                                    .ToActionResult(); 

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<Result<Brand>> GetAsync(Brand model)
        {
            try
            {
                var result = (await _dbPBL.GetBrandAsync(
                    _id: model.ID,
                    _guID: model.GuID
                    )).ToActionResult<Brand>();

                if (result.Data != null)
                {
                    var resultAttachment = await _attachmentDataSource.ListAsync(new AttachmentListVM { ParentIDs = new List<Guid> { result.Data.GuID } });
                    result.Data.Attachment = resultAttachment.Data.FirstOrDefault();
                }
                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<Result<IEnumerable<Brand>>> ListAsync(BrandVM model)
        {
            try
            {
                var result = (await _dbPBL.GetBrandsAsync(
                    _faName:model.FaName,
                    _enName:model.EnName,
                    _pageIndex:model.PageIndex,
                    _pageSize: model.PageSize
                    
                    )).ToListActionResult<Brand>();

                if (result.Data != null && model.IsAttachment)
                {
                    var resultAttachment = await _attachmentDataSource.ListAsync(new AttachmentListVM { ParentIDs = result.Data.Select(x => x.GuID).ToList() });
                    foreach (var brand in result.Data)
                    {
                        brand.Attachment = resultAttachment.Data.FirstOrDefault(x => x.ParentID == brand.GuID);
                    }
                }

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}
