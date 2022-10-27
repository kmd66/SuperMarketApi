using Kama.AppCore;
using Kama.Bonyad.Evaluation.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Kama.Bonyad.Evaluation.Infrastructure.DAL.DataSources
{
    class StockDataSource : DataSource, Core.DataSource.IStockDataSource
    {
        public StockDataSource(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        public async Task<Result<Stock>> AddAsync(Stock model, List<Guid> ids)
        {
            try
            {
                var result = (await _dbPRD.AddStockAsync(
                    _creatorID:_requestInfo.PositionId,
                    _id: model.ID,
                    _guIDS: _objSerializer.Serialize(ids),
                    _isEXECspIndexCountStock: true
                    )).ToActionResult<Stock>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<Result> AddListAsync(List<Stock> model, List<List<Guid>> listIds)
        {
            try
            {
                var commands = new List<SqlCommand>();
                
                int row = 0;
                foreach (var item in model)
                {
                    var ids = listIds[row];
                    commands.Add(_dbPRD.GetCommand_AddStock(
                        _creatorID: _requestInfo.PositionId,
                        _id: item.ID,
                        _guIDS: _objSerializer.Serialize(ids),
                        _isEXECspIndexCountStock: row +1 == model.Count?true:false
                        ));
                    row++;
                }

                await _dbPRD.BatchExcuteAsync(commands.ToArray());

                return Result.Successful();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<Result<IEnumerable<Stock>>> GetAsync(Stock model)
        {
            try
            {
                var result = (await _dbPRD.GetStockAsync(
                    _id:model.ID
                    )).ToListActionResult<Stock>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<Result<IEnumerable<Stock>>> ListAsync(Stock model)
        {
            try
            {
                var result = (await _dbPRD.GetStocksAsync(
                    _id: model.ID,
                    _name:model.Name,
                    _classificationID:model.ClassificationID,
                    _pageIndex:model.PageIndex,
                    _pageSize:model.PageSize
                    )).ToListActionResult<Stock>();
                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}
