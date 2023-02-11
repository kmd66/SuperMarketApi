using Kama.AppCore;
using Kama.Bonyad.Evaluation.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Kama.Bonyad.Evaluation.Infrastructure.DAL.DataSources
{
    class DepoDataSource : DataSource, Core.DataSource.IDepoDataSource
    {
        public DepoDataSource(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        #region ورود به انبار
        public async Task<Result<Depo>> EnterStorageAsync(Depo model, List<Guid> documentGuID)
        {
            model.GuID = Guid.NewGuid();
            try
            {
                var result = (await _dbPBL.AddStorageDepoAsync(
                    _guID: model.GuID,
                    _itemID: model.ItemID,
                    _comment: model.Comment,
                    _number: model.Number,
                    _priceBuy: model.PriceBuy,
                    _creatorID: Guid.NewGuid(),
                    _expired:model.Expired,
                    _documentGuID: _objSerializer.Serialize(documentGuID)
                    )).ToActionResult<Core.Model.Depo>();

                if (result.Success)
                {
                    await Index();
                    return await GetAsync(new Depo { GuID = model.GuID });
                }
                return result;
            }
            catch (Exception e)
            {
                return LogError<Core.Model.Depo>(e);
            }
        }
        public async Task<Result<Depo>> AddAsync(Depo model)
        {
            model.GuID = Guid.NewGuid();
            try
            {
                var result = (await _dbPBL.AddDepoAsync(
                    _guID: model.GuID,
                    _itemID: model.ItemID,
                    _comment: model.Comment,
                    _number: model.Number,
                    _priceBuy: model.PriceBuy,
                    _priceSale: model.PriceSale,
                    _type: (byte)model.Type
                    )).ToActionResult<Core.Model.Depo>();

                if (result.Success)
                {
                    await Index();
                    return await GetAsync(new Depo { GuID = model.GuID });
                }

                return result;
            }
            catch (Exception e)
            {
                return LogError<Core.Model.Depo>(e);
            }
        }
        #endregion

        public async Task<Result> DeleteAsync(Depo model)
        {
            try
            {
                var result = (await _dbPBL.DeleteDepoAsync(_id: model.ID))
                                    .ToActionResult(); 

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<Result<Depo>> GetAsync(Depo model)
        {
            try
            {
                var result = (await _dbPBL.GetDepoAsync(
                    _id: model.ID,
                    _guID: model.GuID
                    )).ToActionResult<Depo>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<Result<IEnumerable<Depo>>> ListAsync(DepoVM model)
        {
            try
            {
                var result = (await _dbPBL.GetDeposAsync(
                    _itemID: model.ItemID,
                    _comment: model.Comment,
                    _type: (byte)model.Type,
                    _pageIndex: model.PageIndex,
                    _pageSize: model.PageSize
                    )).ToListActionResult<Depo>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<Result<IEnumerable<DepoIndex>>> DepoIndexListAsync(DepoVM model)
        {
            try
            {
                var result = (await _dbPBL.DepoIndexListAsync(
                    _itemID: model.ItemID,
                    _type: (byte)model.Type,
                    _pageIndex: model.PageIndex,
                    _pageSize: model.PageSize
                    )).ToListActionResult<DepoIndex>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Task Index() => _dbPBL.DepoIndexAsync();
    }
}
