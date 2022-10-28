using Kama.AppCore;
using Kama.Bonyad.Evaluation.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Kama.Bonyad.Evaluation.Infrastructure.DAL.DataSources
{
    class ProductDataSource : DataSource, Core.DataSource.IProductDataSource
    {
        public ProductDataSource(AppCore.IOC.IContainer container
            , Core.DataSource.IAttachmentDataSource attachmentDataSource)
            : base(container)
        {
            _attachmentDataSource = attachmentDataSource;
        }
        Core.DataSource.IAttachmentDataSource _attachmentDataSource;

        private async Task<AppCore.Result<Core.Model.Product>> ModifyAsync(bool isNewRecord, Product model)
        {
            try
            {
                var result = (await _dbPRD.ModifyProductAsync(
                    _isNewRecord: isNewRecord,
                    _guID:model.GuID,
                    _name:model.Name,
                    _comment: model.Comment,
                    _parentID:model.ParentID,
                    _id:model.ID,
                    _discount:model.Discount,
                    _price:model.Price,
                    _information:model.Information,
                    _unitOfMeasure:(byte)model.UnitOfMeasure
                    )).ToActionResult<Core.Model.Product>();

                if (result.Success)
                    return await GetAsync(new Product { GuID= model.GuID });

                return result;
            }
            catch (Exception e)
            {
                return LogError<Core.Model.Product>(e);
            }
        }

        public Task<Result<Product>> AddAsync(Product model)
        {
            model.GuID = Guid.NewGuid();
            return ModifyAsync(true, model);
        }

        public Task<Result<Product>> EditAsync(Product model)
            => ModifyAsync(false, model);

        public async Task<Result> DeleteAsync(Product model)
        {
            try
            {
                var result = (await _dbPRD.DeleteProductAsync(_id: model.ID))
                                    .ToActionResult(); 

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<Result<Product>> GetAsync(Product model)
        {
            try
            {
                var result = (await _dbPRD.GetProductAsync(
                    _id: model.ID,
                    _guID: model.GuID
                    )).ToActionResult<Product>();

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

        public async Task<Result<IEnumerable<Product>>> ListAsync(ProductVM model)
        {
            try
            {
                var result = (await _dbPRD.GetProductsAsync(
                    _parentID: model.ParentID,
                    _name:model.Name,
                    _comment: model.Comment,
                    _startPrice:model.StartPrice,
                    _endPrice:model.EndPrice,
                    _pageIndex:model.PageIndex,
                    _pageSize: model.PageSize
                    
                    )).ToListActionResult<Product>();

                if (result.Data != null && model.IsAttachment)
                {
                    var resultAttachment = await _attachmentDataSource.ListAsync(new AttachmentListVM { ParentIDs = result.Data.Select(x => x.GuID).ToList() });
                    foreach (var Product in result.Data)
                    {
                        Product.Attachment = resultAttachment.Data.FirstOrDefault(x => x.ParentID == Product.GuID);
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
