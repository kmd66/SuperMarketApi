using Kama.AppCore;
using Kama.Bonyad.Evaluation.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Kama.Bonyad.Evaluation.Infrastructure.DAL.DataSources
{
    class ItemDataSource : DataSource, Core.DataSource.IItemDataSource
    {
        public ItemDataSource(AppCore.IOC.IContainer container
            , Core.DataSource.IAttachmentDataSource attachmentDataSource)
            : base(container)
        {
            _attachmentDataSource = attachmentDataSource;
        }
        Core.DataSource.IAttachmentDataSource _attachmentDataSource;

        private async Task<AppCore.Result<Core.Model.Item>> ModifyAsync(bool isNewRecord, Item model)
        {
            try
            {
                var result = (await _dbPRD.ModifyItemAsync(
                    _isNewRecord: isNewRecord,
                    _id:model.ID,
                    _guID:model.GuID,
                    _classificationID:model.ClassificationID,
                    _brandID: model.BrandID,
                    _faName:model.FaName,
                    _enName:model.EnName,
                    _information:model.Information
                    )).ToActionResult<Core.Model.Item>();

                if (result.Success)
                    return await GetAsync(new Item { GuID= model.GuID });

                return result;
            }
            catch (Exception e)
            {
                return LogError<Core.Model.Item>(e);
            }
        }

        public Task<Result<Item>> AddAsync(Item model)
        {
            model.GuID = Guid.NewGuid();
            return ModifyAsync(true, model);
        }

        public Task<Result<Item>> EditAsync(Item model)
            => ModifyAsync(false, model);

        public async Task<Result> DeleteAsync(Item model)
        {
            try
            {
                var result = (await _dbPRD.DeleteItemAsync(_id: model.ID))
                                    .ToActionResult(); 

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<Result<Item>> GetAsync(Item model)
        {
            try
            {
                var result = (await _dbPRD.GetItemAsync(
                    _id: model.ID,
                    _guID: model.GuID
                    )).ToActionResult<Item>();

                if (result.Data != null)
                {
                    var resultAttachment = await _attachmentDataSource.ListAsync(new AttachmentListVM { ParentIDs = new List<Guid> { result.Data .GuID} });
                    result.Data.Attachments = resultAttachment.Data.ToList();
                }
                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<Result<IEnumerable<Item>>> ListAsync(ItemVM model)
        {
            try
            {
                var result = (await _dbPRD.GetItemsAsync(
                    _classificationID: model.ClassificationID,
                    _brandID: model.BrandID,
                    _faName: model.FaName,
                    _enName: model.EnName,
                    _pageIndex:model.PageIndex,
                    _pageSize: model.PageSize
                    
                    )).ToListActionResult<Item>();

                if (result.Data != null && model.IsAttachment)
                {
                    var resultAttachment = await _attachmentDataSource.ListAsync(new AttachmentListVM { ParentIDs = result.Data.Select(x => x.GuID).ToList() });
                    foreach (var Item in result.Data)
                    {
                        Item.Attachments = resultAttachment.Data.Where(x => x.ParentID == Item.GuID).ToList();
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
