using Kama.AppCore;
using Kama.Bonyad.Evaluation.Core.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Bonyad.Evaluation.Infrastructure.DAL.DataSources
{
    internal class FlowDataSource : DataSource, Core.DataSource.IFlowDataSource
    {
        public FlowDataSource(AppCore.IOC.IContainer container) : base(container)
        {
        }

        public Task<Result> AddAsync(RecognitionFlow flow, IActivityLog log)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<T>>> ListAsync<T>(int documentId) where T : class, new()
        {
            throw new NotImplementedException();
        }

        //public async Task<AppCore.Result> AddAsync(RecognitionFlow flow, AppCore.IActivityLog log)
        //{
        //    AppCore.Result.Failure(errors:"");
        //    //try
        //    //{

        //    //    //if (flow.ToDocState == EvaluationDocState.بررسی_اولیه)
        //    //    //{
        //    //    //    await _dbreq.SetTrackingCodeAsync(
        //    //    //        _documentID: flow.DocumentID
        //    //    //     );
        //    //    //}
        //    //    var result = (await _dbPBL.AddFlowAsync(
        //    //        _documentID: flow.DocumentID,
        //    //        _toDocState: (byte)flow.ToDocState,
        //    //        _toPositionID: flow.ToPositionID,
        //    //        _sendType: (byte)flow.SendType,
        //    //        _comment: flow.Comment
        //    //        )).ToActionResult();

        //    //    return result;
        //    //}
        //    //catch (Exception e)
        //    //{
        //    //    return LogError(e);
        //    //}
        //}


        //public async Task<AppCore.Result<IEnumerable<T>>> ListAsync<T>(int documentId)
        //    where T : class, new()
        //{
        //    try
        //    {
        //        var result = (await _dbPBL.GetFlowsAsync(
        //            _documentID: documentId
        //            )).ToListActionResult<T>();

        //        return result;
        //    }
        //    catch (Exception e)
        //    {
        //        throw;
        //    }
        //}

        //public async Task<AppCore.Result> AddFlowsAsync<T>(IEnumerable<Flow<T>> flows, AppCore.IActivityLog log)
        //{
        //    try
        //    {
        //        var result = (await _dbPBL.AddFlowsAsync(
        //            _flows: _objSerializer.Serialize(flows),
        //            _log: log?.Value
        //            )).ToActionResult();

        //        return result;
        //    }
        //    catch (Exception e)
        //    {
        //        throw;
        //    }
        //}

        //public async Task<AppCore.Result> RejectAsync(Flow flow, AppCore.IActivityLog log)
        //{
        //    try
        //    {
        //        var result = await _dbPBL.RejectFlowAsync(
        //            _documentID: flow.DocumentID,
        //            _fromUserID: flow.FromUserID,
        //            _fromPositionID: flow.FromPositionID,
        //            _comment: flow.Comment,
        //            _log: log?.Value
        //            );

        //        return result.ToActionResult();
        //    }
        //    catch (Exception e)
        //    {
        //        return LogError(e);
        //    }
        //}

        //public async Task<AppCore.Result> SetAsReadAsync(Guid documentID, Guid userPositionID, AppCore.IActivityLog log)
        //{
        //    try
        //    {
        //        var result = await _dbPBL.SetFlowReadStateAsync(
        //            _documentID: documentID,
        //            _userPositionID: userPositionID,
        //            _isRead: true,
        //            _log: log?.Value
        //            );

        //        return result.ToActionResult();
        //    }
        //    catch (Exception e)
        //    {
        //        return LogError(e);
        //    }
        //}

        //public async Task<AppCore.Result> SetAsUnReadAsync(Guid documentID, Guid userPositionID, AppCore.IActivityLog log)
        //{
        //    try
        //    {
        //        var result = await _dbPBL.SetFlowReadStateAsync(
        //            _documentID: documentID,
        //            _userPositionID: userPositionID,
        //            _isRead: false,
        //            _log: log?.Value
        //            );

        //        return result.ToActionResult();
        //    }
        //    catch (Exception e)
        //    {
        //        return LogError(e);
        //    }
        //}

    }
}