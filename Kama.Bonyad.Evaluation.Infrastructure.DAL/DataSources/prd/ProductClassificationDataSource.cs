using Kama.AppCore;
using Kama.Bonyad.Evaluation.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Kama.Bonyad.Evaluation.Infrastructure.DAL.DataSources
{
    class ProductClassificationDataSource : DataSource, Core.DataSource.IProductClassificationDataSource
    {
        public ProductClassificationDataSource(AppCore.IOC.IContainer container
            , Core.DataSource.IAttachmentDataSource attachmentDataSource)
            : base(container)
        {
            _attachmentDataSource = attachmentDataSource;
        }
        Core.DataSource.IAttachmentDataSource _attachmentDataSource;

        private async Task<AppCore.Result<Core.Model.ProductClassification>> ModifyAsync(bool isNewRecord, ProductClassification model)
        {
            try
            {
                var result = (await _dbPRD.ModifyProductClassificationAsync(
                    _isNewRecord: isNewRecord,
                    _guID:model.GuID,
                    _name:model.Name,
                    _comment: model.Comment,
                    _parentID:model.ParentID
                    )).ToActionResult<Core.Model.ProductClassification>();

                if (result.Success)
                    return await GetAsync(new ProductClassification { GuID= model.GuID });

                return result;
            }
            catch (Exception e)
            {
                return LogError<Core.Model.ProductClassification>(e);
            }
        }

        public Task<Result<ProductClassification>> AddAsync(ProductClassification model)
        {
            model.GuID = Guid.NewGuid();
            return ModifyAsync(true, model);
        }

        public Task<Result<ProductClassification>> EditAsync(ProductClassification model)
            => ModifyAsync(false, model);

        public async Task<Result> DeleteAsync(ProductClassification model)
        {
            try
            {
                var result = (await _dbPRD.DeleteProductClassificationAsync(_guID: model.GuID))
                                    .ToActionResult(); 

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<Result<ProductClassification>> GetAsync(ProductClassification model)
        {
            try
            {
                var result = (await _dbPRD.GetProductClassificationAsync(_guID: model.GuID))
                                .ToActionResult<ProductClassification>();

                if (result.Data != null)
                {
                    var resultAttachment = await _attachmentDataSource.ListAsync(new AttachmentListVM { ParentIDs = new List<Guid> { result.Data .GuID} });
                    result.Data.Attachment = resultAttachment.Data.FirstOrDefault();
                }
                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<Result<IEnumerable<ProductClassification>>> ListAsync(ProductClassificationVM model)
        {
            try
            {
                var result = (await _dbPRD.GetProductClassificationsAsync(
                    _parentID: model.ParentID,
                    _name:model.Name,
                    _comment: model.Comment,
                    _allChild:model.AllChild,
                    _pageIndex:model.PageIndex,
                    _pageSize: model.PageSize
                    
                    )).ToListActionResult<ProductClassification>();

                if (result.Data != null && model.IsAttachment)
                {
                    var resultAttachment = await _attachmentDataSource.ListAsync(new AttachmentListVM { ParentIDs = result.Data.Select(x => x.GuID).ToList() });
                    foreach (var productClassification in result.Data)
                    {
                        productClassification.Attachment = resultAttachment.Data.FirstOrDefault(x => x.ParentID == productClassification.GuID);
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
