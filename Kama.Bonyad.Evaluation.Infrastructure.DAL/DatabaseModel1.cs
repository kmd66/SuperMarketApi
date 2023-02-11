using System;
using Kama.DatabaseModel;
using System.Threading.Tasks;
 using System.Collections.Generic;

namespace Kama.Bonyad.Evaluation.Infrastructure.DAL
{
class PRD: Database
{
#region Constructors
public PRD(string connectionString)
	:base(connectionString){}

public PRD(string connectionString, IModelValueBinder modelValueBinder)
	:base(connectionString, modelValueBinder){}
#endregion

#region AddDocument

public System.Data.SqlClient.SqlCommand GetCommand_AddDocument(Guid? _guID, long? _itemID, long? _storageID, long? _saleID, long? _orderID, byte? _lastState, DateTime? _expired, Guid? _creatorID, int? timeout = null)
{
var cmd = base.CreateCommand("prd.spAddDocument", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AGuID", IsOutput = false, Value = _guID == null ? DBNull.Value : (object)_guID }, 
					new Parameter { Name = "@AItemID", IsOutput = false, Value = _itemID == null ? DBNull.Value : (object)_itemID }, 
					new Parameter { Name = "@AStorageID", IsOutput = false, Value = _storageID == null ? DBNull.Value : (object)_storageID }, 
					new Parameter { Name = "@ASaleID", IsOutput = false, Value = _saleID == null ? DBNull.Value : (object)_saleID }, 
					new Parameter { Name = "@AOrderID", IsOutput = false, Value = _orderID == null ? DBNull.Value : (object)_orderID }, 
					new Parameter { Name = "@ALastState", IsOutput = false, Value = _lastState == null ? DBNull.Value : (object)_lastState }, 
					new Parameter { Name = "@AExpired", IsOutput = false, Value = _expired == null ? DBNull.Value : (object)_expired }, 
					new Parameter { Name = "@ACreatorID", IsOutput = false, Value = _creatorID == null ? DBNull.Value : (object)_creatorID }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> AddDocumentAsync(Guid? _guID, long? _itemID, long? _storageID, long? _saleID, long? _orderID, byte? _lastState, DateTime? _expired, Guid? _creatorID, int? timeout = null)
{
	using(var cmd = GetCommand_AddDocument(_guID, _itemID, _storageID, _saleID, _orderID, _lastState, _expired, _creatorID, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> AddDocumentDapperAsync<T>(Guid? _guID, long? _itemID, long? _storageID, long? _saleID, long? _orderID, byte? _lastState, DateTime? _expired, Guid? _creatorID, int? timeout = null)
{
	return await  DapperQueryAsync<T>("prd.spAddDocument",new {AGuID=_guID,AItemID=_itemID,AStorageID=_storageID,ASaleID=_saleID,AOrderID=_orderID,ALastState=_lastState,AExpired=_expired,ACreatorID=_creatorID} , timeout );
}

public ResultSet AddDocument(Guid? _guID, long? _itemID, long? _storageID, long? _saleID, long? _orderID, byte? _lastState, DateTime? _expired, Guid? _creatorID, int? timeout = null)
{
	using(var cmd = GetCommand_AddDocument(_guID, _itemID, _storageID, _saleID, _orderID, _lastState, _expired, _creatorID, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region ModifyStock

public System.Data.SqlClient.SqlCommand GetCommand_ModifyStock(long? _type, Guid? _creatorID, string _guIDS, int? timeout = null)
{
var cmd = base.CreateCommand("prd.spModifyStock", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AType", IsOutput = false, Value = _type == null ? DBNull.Value : (object)_type }, 
					new Parameter { Name = "@ACreatorID", IsOutput = false, Value = _creatorID == null ? DBNull.Value : (object)_creatorID }, 
					new Parameter { Name = "@AGuIDS", IsOutput = false, Value = string.IsNullOrWhiteSpace(_guIDS) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_guIDS) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> ModifyStockAsync(long? _type, Guid? _creatorID, string _guIDS, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyStock(_type, _creatorID, _guIDS, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> ModifyStockDapperAsync<T>(long? _type, Guid? _creatorID, string _guIDS, int? timeout = null)
{
	return await  DapperQueryAsync<T>("prd.spModifyStock",new {AType=_type,ACreatorID=_creatorID,AGuIDS=string.IsNullOrWhiteSpace(_guIDS) ? _guIDS : ReplaceArabicWithPersianChars(_guIDS)} , timeout );
}

public ResultSet ModifyStock(long? _type, Guid? _creatorID, string _guIDS, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyStock(_type, _creatorID, _guIDS, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region DeleteProductClassification

public System.Data.SqlClient.SqlCommand GetCommand_DeleteProductClassification(Guid? _guID, int? timeout = null)
{
var cmd = base.CreateCommand("prd.spDeleteProductClassification", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AGuID", IsOutput = false, Value = _guID == null ? DBNull.Value : (object)_guID }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> DeleteProductClassificationAsync(Guid? _guID, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteProductClassification(_guID, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> DeleteProductClassificationDapperAsync<T>(Guid? _guID, int? timeout = null)
{
	return await  DapperQueryAsync<T>("prd.spDeleteProductClassification",new {AGuID=_guID} , timeout );
}

public ResultSet DeleteProductClassification(Guid? _guID, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteProductClassification(_guID, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetProductClassification

public System.Data.SqlClient.SqlCommand GetCommand_GetProductClassification(Guid? _guID, int? timeout = null)
{
var cmd = base.CreateCommand("prd.spGetProductClassification", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AGuID", IsOutput = false, Value = _guID == null ? DBNull.Value : (object)_guID }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetProductClassificationAsync(Guid? _guID, int? timeout = null)
{
	using(var cmd = GetCommand_GetProductClassification(_guID, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetProductClassificationDapperAsync<T>(Guid? _guID, int? timeout = null)
{
	return await  DapperQueryAsync<T>("prd.spGetProductClassification",new {AGuID=_guID} , timeout );
}

public ResultSet GetProductClassification(Guid? _guID, int? timeout = null)
{
	using(var cmd = GetCommand_GetProductClassification(_guID, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region ModifyProductClassification

public System.Data.SqlClient.SqlCommand GetCommand_ModifyProductClassification(bool? _isNewRecord, Guid? _guID, Guid? _parentID, string _name, string _comment, int? timeout = null)
{
var cmd = base.CreateCommand("prd.spModifyProductClassification", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AIsNewRecord", IsOutput = false, Value = _isNewRecord == null ? DBNull.Value : (object)_isNewRecord }, 
					new Parameter { Name = "@AGuID", IsOutput = false, Value = _guID == null ? DBNull.Value : (object)_guID }, 
					new Parameter { Name = "@AParentID", IsOutput = false, Value = _parentID == null ? DBNull.Value : (object)_parentID }, 
					new Parameter { Name = "@AName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_name) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_name) }, 
					new Parameter { Name = "@AComment", IsOutput = false, Value = string.IsNullOrWhiteSpace(_comment) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_comment) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> ModifyProductClassificationAsync(bool? _isNewRecord, Guid? _guID, Guid? _parentID, string _name, string _comment, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyProductClassification(_isNewRecord, _guID, _parentID, _name, _comment, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> ModifyProductClassificationDapperAsync<T>(bool? _isNewRecord, Guid? _guID, Guid? _parentID, string _name, string _comment, int? timeout = null)
{
	return await  DapperQueryAsync<T>("prd.spModifyProductClassification",new {AIsNewRecord=_isNewRecord,AGuID=_guID,AParentID=_parentID,AName=string.IsNullOrWhiteSpace(_name) ? _name : ReplaceArabicWithPersianChars(_name),AComment=string.IsNullOrWhiteSpace(_comment) ? _comment : ReplaceArabicWithPersianChars(_comment)} , timeout );
}

public ResultSet ModifyProductClassification(bool? _isNewRecord, Guid? _guID, Guid? _parentID, string _name, string _comment, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyProductClassification(_isNewRecord, _guID, _parentID, _name, _comment, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region IndexCountStock

public System.Data.SqlClient.SqlCommand GetCommand_IndexCountStock(int? timeout = null)
{
var cmd = base.CreateCommand("prd.spIndexCountStock", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> IndexCountStockAsync(int? timeout = null)
{
	using(var cmd = GetCommand_IndexCountStock(timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> IndexCountStockDapperAsync<T>(int? timeout = null)
{
	return await  DapperQueryAsync<T>("prd.spIndexCountStock",new {} , timeout );
}

public ResultSet IndexCountStock(int? timeout = null)
{
	using(var cmd = GetCommand_IndexCountStock(timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetStocks

public System.Data.SqlClient.SqlCommand GetCommand_GetStocks(long? _id, string _name, long? _classificationID, byte? _actionState, int? _pageSize, int? _pageIndex, int? timeout = null)
{
var cmd = base.CreateCommand("prd.spGetStocks", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@AName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_name) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_name) }, 
					new Parameter { Name = "@AClassificationID", IsOutput = false, Value = _classificationID == null ? DBNull.Value : (object)_classificationID }, 
					new Parameter { Name = "@AActionState", IsOutput = false, Value = _actionState == null ? DBNull.Value : (object)_actionState }, 
					new Parameter { Name = "@APageSize", IsOutput = false, Value = _pageSize == null ? DBNull.Value : (object)_pageSize }, 
					new Parameter { Name = "@APageIndex", IsOutput = false, Value = _pageIndex == null ? DBNull.Value : (object)_pageIndex }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetStocksAsync(long? _id, string _name, long? _classificationID, byte? _actionState, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	using(var cmd = GetCommand_GetStocks(_id, _name, _classificationID, _actionState, _pageSize, _pageIndex, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetStocksDapperAsync<T>(long? _id, string _name, long? _classificationID, byte? _actionState, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	return await  DapperQueryAsync<T>("prd.spGetStocks",new {AID=_id,AName=string.IsNullOrWhiteSpace(_name) ? _name : ReplaceArabicWithPersianChars(_name),AClassificationID=_classificationID,AActionState=_actionState,APageSize=_pageSize,APageIndex=_pageIndex} , timeout );
}

public ResultSet GetStocks(long? _id, string _name, long? _classificationID, byte? _actionState, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	using(var cmd = GetCommand_GetStocks(_id, _name, _classificationID, _actionState, _pageSize, _pageIndex, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetStock

public System.Data.SqlClient.SqlCommand GetCommand_GetStock(long? _id, int? timeout = null)
{
var cmd = base.CreateCommand("prd.spGetStock", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetStockAsync(long? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetStock(_id, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetStockDapperAsync<T>(long? _id, int? timeout = null)
{
	return await  DapperQueryAsync<T>("prd.spGetStock",new {AID=_id} , timeout );
}

public ResultSet GetStock(long? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetStock(_id, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region AddStock

public System.Data.SqlClient.SqlCommand GetCommand_AddStock(long? _id, Guid? _creatorID, string _guIDS, DateTime? _expired, bool? _isEXECspIndexCountStock, int? timeout = null)
{
var cmd = base.CreateCommand("prd.spAddStock", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@ACreatorID", IsOutput = false, Value = _creatorID == null ? DBNull.Value : (object)_creatorID }, 
					new Parameter { Name = "@AGuIDS", IsOutput = false, Value = string.IsNullOrWhiteSpace(_guIDS) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_guIDS) }, 
					new Parameter { Name = "@AExpired", IsOutput = false, Value = _expired == null ? DBNull.Value : (object)_expired }, 
					new Parameter { Name = "@AIsEXECspIndexCountStock", IsOutput = false, Value = _isEXECspIndexCountStock == null ? DBNull.Value : (object)_isEXECspIndexCountStock }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> AddStockAsync(long? _id, Guid? _creatorID, string _guIDS, DateTime? _expired, bool? _isEXECspIndexCountStock, int? timeout = null)
{
	using(var cmd = GetCommand_AddStock(_id, _creatorID, _guIDS, _expired, _isEXECspIndexCountStock, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> AddStockDapperAsync<T>(long? _id, Guid? _creatorID, string _guIDS, DateTime? _expired, bool? _isEXECspIndexCountStock, int? timeout = null)
{
	return await  DapperQueryAsync<T>("prd.spAddStock",new {AID=_id,ACreatorID=_creatorID,AGuIDS=string.IsNullOrWhiteSpace(_guIDS) ? _guIDS : ReplaceArabicWithPersianChars(_guIDS),AExpired=_expired,AIsEXECspIndexCountStock=_isEXECspIndexCountStock} , timeout );
}

public ResultSet AddStock(long? _id, Guid? _creatorID, string _guIDS, DateTime? _expired, bool? _isEXECspIndexCountStock, int? timeout = null)
{
	using(var cmd = GetCommand_AddStock(_id, _creatorID, _guIDS, _expired, _isEXECspIndexCountStock, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region ModifyItem

public System.Data.SqlClient.SqlCommand GetCommand_ModifyItem(bool? _isNewRecord, long? _id, Guid? _guID, long? _classificationID, long? _brandID, string _faName, string _enName, string _information, int? timeout = null)
{
var cmd = base.CreateCommand("prd.spModifyItem", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AIsNewRecord", IsOutput = false, Value = _isNewRecord == null ? DBNull.Value : (object)_isNewRecord }, 
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@AGuID", IsOutput = false, Value = _guID == null ? DBNull.Value : (object)_guID }, 
					new Parameter { Name = "@AClassificationID", IsOutput = false, Value = _classificationID == null ? DBNull.Value : (object)_classificationID }, 
					new Parameter { Name = "@ABrandID", IsOutput = false, Value = _brandID == null ? DBNull.Value : (object)_brandID }, 
					new Parameter { Name = "@AFaName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_faName) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_faName) }, 
					new Parameter { Name = "@AEnName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_enName) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_enName) }, 
					new Parameter { Name = "@AInformation", IsOutput = false, Value = string.IsNullOrWhiteSpace(_information) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_information) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> ModifyItemAsync(bool? _isNewRecord, long? _id, Guid? _guID, long? _classificationID, long? _brandID, string _faName, string _enName, string _information, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyItem(_isNewRecord, _id, _guID, _classificationID, _brandID, _faName, _enName, _information, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> ModifyItemDapperAsync<T>(bool? _isNewRecord, long? _id, Guid? _guID, long? _classificationID, long? _brandID, string _faName, string _enName, string _information, int? timeout = null)
{
	return await  DapperQueryAsync<T>("prd.spModifyItem",new {AIsNewRecord=_isNewRecord,AID=_id,AGuID=_guID,AClassificationID=_classificationID,ABrandID=_brandID,AFaName=string.IsNullOrWhiteSpace(_faName) ? _faName : ReplaceArabicWithPersianChars(_faName),AEnName=string.IsNullOrWhiteSpace(_enName) ? _enName : ReplaceArabicWithPersianChars(_enName),AInformation=string.IsNullOrWhiteSpace(_information) ? _information : ReplaceArabicWithPersianChars(_information)} , timeout );
}

public ResultSet ModifyItem(bool? _isNewRecord, long? _id, Guid? _guID, long? _classificationID, long? _brandID, string _faName, string _enName, string _information, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyItem(_isNewRecord, _id, _guID, _classificationID, _brandID, _faName, _enName, _information, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region DeleteItem

public System.Data.SqlClient.SqlCommand GetCommand_DeleteItem(long? _id, int? timeout = null)
{
var cmd = base.CreateCommand("prd.spDeleteItem", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> DeleteItemAsync(long? _id, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteItem(_id, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> DeleteItemDapperAsync<T>(long? _id, int? timeout = null)
{
	return await  DapperQueryAsync<T>("prd.spDeleteItem",new {AID=_id} , timeout );
}

public ResultSet DeleteItem(long? _id, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteItem(_id, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetStocksMinimumToAlert

public System.Data.SqlClient.SqlCommand GetCommand_GetStocksMinimumToAlert(long? _id, string _name, long? _classificationID, byte? _actionState, int? _pageSize, int? _pageIndex, int? timeout = null)
{
var cmd = base.CreateCommand("prd.spGetStocksMinimumToAlert", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@AName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_name) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_name) }, 
					new Parameter { Name = "@AClassificationID", IsOutput = false, Value = _classificationID == null ? DBNull.Value : (object)_classificationID }, 
					new Parameter { Name = "@AActionState", IsOutput = false, Value = _actionState == null ? DBNull.Value : (object)_actionState }, 
					new Parameter { Name = "@APageSize", IsOutput = false, Value = _pageSize == null ? DBNull.Value : (object)_pageSize }, 
					new Parameter { Name = "@APageIndex", IsOutput = false, Value = _pageIndex == null ? DBNull.Value : (object)_pageIndex }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetStocksMinimumToAlertAsync(long? _id, string _name, long? _classificationID, byte? _actionState, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	using(var cmd = GetCommand_GetStocksMinimumToAlert(_id, _name, _classificationID, _actionState, _pageSize, _pageIndex, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetStocksMinimumToAlertDapperAsync<T>(long? _id, string _name, long? _classificationID, byte? _actionState, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	return await  DapperQueryAsync<T>("prd.spGetStocksMinimumToAlert",new {AID=_id,AName=string.IsNullOrWhiteSpace(_name) ? _name : ReplaceArabicWithPersianChars(_name),AClassificationID=_classificationID,AActionState=_actionState,APageSize=_pageSize,APageIndex=_pageIndex} , timeout );
}

public ResultSet GetStocksMinimumToAlert(long? _id, string _name, long? _classificationID, byte? _actionState, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	using(var cmd = GetCommand_GetStocksMinimumToAlert(_id, _name, _classificationID, _actionState, _pageSize, _pageIndex, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetItem

public System.Data.SqlClient.SqlCommand GetCommand_GetItem(long? _id, Guid? _guID, int? timeout = null)
{
var cmd = base.CreateCommand("prd.spGetItem", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@AGuID", IsOutput = false, Value = _guID == null ? DBNull.Value : (object)_guID }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetItemAsync(long? _id, Guid? _guID, int? timeout = null)
{
	using(var cmd = GetCommand_GetItem(_id, _guID, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetItemDapperAsync<T>(long? _id, Guid? _guID, int? timeout = null)
{
	return await  DapperQueryAsync<T>("prd.spGetItem",new {AID=_id,AGuID=_guID} , timeout );
}

public ResultSet GetItem(long? _id, Guid? _guID, int? timeout = null)
{
	using(var cmd = GetCommand_GetItem(_id, _guID, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetItems

public System.Data.SqlClient.SqlCommand GetCommand_GetItems(long? _classificationID, long? _brandID, string _faName, string _enName, int? _pageSize, int? _pageIndex, int? timeout = null)
{
var cmd = base.CreateCommand("prd.spGetItems", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AClassificationID", IsOutput = false, Value = _classificationID == null ? DBNull.Value : (object)_classificationID }, 
					new Parameter { Name = "@ABrandID", IsOutput = false, Value = _brandID == null ? DBNull.Value : (object)_brandID }, 
					new Parameter { Name = "@AFaName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_faName) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_faName) }, 
					new Parameter { Name = "@AEnName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_enName) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_enName) }, 
					new Parameter { Name = "@APageSize", IsOutput = false, Value = _pageSize == null ? DBNull.Value : (object)_pageSize }, 
					new Parameter { Name = "@APageIndex", IsOutput = false, Value = _pageIndex == null ? DBNull.Value : (object)_pageIndex }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetItemsAsync(long? _classificationID, long? _brandID, string _faName, string _enName, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	using(var cmd = GetCommand_GetItems(_classificationID, _brandID, _faName, _enName, _pageSize, _pageIndex, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetItemsDapperAsync<T>(long? _classificationID, long? _brandID, string _faName, string _enName, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	return await  DapperQueryAsync<T>("prd.spGetItems",new {AClassificationID=_classificationID,ABrandID=_brandID,AFaName=string.IsNullOrWhiteSpace(_faName) ? _faName : ReplaceArabicWithPersianChars(_faName),AEnName=string.IsNullOrWhiteSpace(_enName) ? _enName : ReplaceArabicWithPersianChars(_enName),APageSize=_pageSize,APageIndex=_pageIndex} , timeout );
}

public ResultSet GetItems(long? _classificationID, long? _brandID, string _faName, string _enName, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	using(var cmd = GetCommand_GetItems(_classificationID, _brandID, _faName, _enName, _pageSize, _pageIndex, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region ReturnExpiredState

public System.Data.SqlClient.SqlCommand GetCommand_ReturnExpiredState(int? timeout = null)
{
var cmd = base.CreateCommand("prd.spReturnExpiredState", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> ReturnExpiredStateAsync(int? timeout = null)
{
	using(var cmd = GetCommand_ReturnExpiredState(timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> ReturnExpiredStateDapperAsync<T>(int? timeout = null)
{
	return await  DapperQueryAsync<T>("prd.spReturnExpiredState",new {} , timeout );
}

public ResultSet ReturnExpiredState(int? timeout = null)
{
	using(var cmd = GetCommand_ReturnExpiredState(timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region StockChangeState

public System.Data.SqlClient.SqlCommand GetCommand_StockChangeState(long? _id, Guid? _fromPositionID, byte? _state, int? timeout = null)
{
var cmd = base.CreateCommand("prd.spStockChangeState", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@AFromPositionID", IsOutput = false, Value = _fromPositionID == null ? DBNull.Value : (object)_fromPositionID }, 
					new Parameter { Name = "@AState", IsOutput = false, Value = _state == null ? DBNull.Value : (object)_state }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> StockChangeStateAsync(long? _id, Guid? _fromPositionID, byte? _state, int? timeout = null)
{
	using(var cmd = GetCommand_StockChangeState(_id, _fromPositionID, _state, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> StockChangeStateDapperAsync<T>(long? _id, Guid? _fromPositionID, byte? _state, int? timeout = null)
{
	return await  DapperQueryAsync<T>("prd.spStockChangeState",new {AID=_id,AFromPositionID=_fromPositionID,AState=_state} , timeout );
}

public ResultSet StockChangeState(long? _id, Guid? _fromPositionID, byte? _state, int? timeout = null)
{
	using(var cmd = GetCommand_StockChangeState(_id, _fromPositionID, _state, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region AddFlow

public System.Data.SqlClient.SqlCommand GetCommand_AddFlow(long? _documentID, long? _depoID, Guid? _toPositionID, byte? _toState, byte? _sendType, string _comment, int? timeout = null)
{
var cmd = base.CreateCommand("prd.spAddFlow", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@ADocumentID", IsOutput = false, Value = _documentID == null ? DBNull.Value : (object)_documentID }, 
					new Parameter { Name = "@ADepoID", IsOutput = false, Value = _depoID == null ? DBNull.Value : (object)_depoID }, 
					new Parameter { Name = "@AToPositionID", IsOutput = false, Value = _toPositionID == null ? DBNull.Value : (object)_toPositionID }, 
					new Parameter { Name = "@AToState", IsOutput = false, Value = _toState == null ? DBNull.Value : (object)_toState }, 
					new Parameter { Name = "@ASendType", IsOutput = false, Value = _sendType == null ? DBNull.Value : (object)_sendType }, 
					new Parameter { Name = "@AComment", IsOutput = false, Value = string.IsNullOrWhiteSpace(_comment) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_comment) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> AddFlowAsync(long? _documentID, long? _depoID, Guid? _toPositionID, byte? _toState, byte? _sendType, string _comment, int? timeout = null)
{
	using(var cmd = GetCommand_AddFlow(_documentID, _depoID, _toPositionID, _toState, _sendType, _comment, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> AddFlowDapperAsync<T>(long? _documentID, long? _depoID, Guid? _toPositionID, byte? _toState, byte? _sendType, string _comment, int? timeout = null)
{
	return await  DapperQueryAsync<T>("prd.spAddFlow",new {ADocumentID=_documentID,ADepoID=_depoID,AToPositionID=_toPositionID,AToState=_toState,ASendType=_sendType,AComment=string.IsNullOrWhiteSpace(_comment) ? _comment : ReplaceArabicWithPersianChars(_comment)} , timeout );
}

public ResultSet AddFlow(long? _documentID, long? _depoID, Guid? _toPositionID, byte? _toState, byte? _sendType, string _comment, int? timeout = null)
{
	using(var cmd = GetCommand_AddFlow(_documentID, _depoID, _toPositionID, _toState, _sendType, _comment, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region DeleteDocument

public System.Data.SqlClient.SqlCommand GetCommand_DeleteDocument(long? _id, Guid? _userID, int? timeout = null)
{
var cmd = base.CreateCommand("prd.spDeleteDocument", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@AUserID", IsOutput = false, Value = _userID == null ? DBNull.Value : (object)_userID }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> DeleteDocumentAsync(long? _id, Guid? _userID, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteDocument(_id, _userID, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> DeleteDocumentDapperAsync<T>(long? _id, Guid? _userID, int? timeout = null)
{
	return await  DapperQueryAsync<T>("prd.spDeleteDocument",new {AID=_id,AUserID=_userID} , timeout );
}

public ResultSet DeleteDocument(long? _id, Guid? _userID, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteDocument(_id, _userID, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region AddInformation

public System.Data.SqlClient.SqlCommand GetCommand_AddInformation(string _text, int? timeout = null)
{
var cmd = base.CreateCommand("prd.spAddInformation", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AText", IsOutput = false, Value = string.IsNullOrWhiteSpace(_text) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_text) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> AddInformationAsync(string _text, int? timeout = null)
{
	using(var cmd = GetCommand_AddInformation(_text, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> AddInformationDapperAsync<T>(string _text, int? timeout = null)
{
	return await  DapperQueryAsync<T>("prd.spAddInformation",new {AText=string.IsNullOrWhiteSpace(_text) ? _text : ReplaceArabicWithPersianChars(_text)} , timeout );
}

public ResultSet AddInformation(string _text, int? timeout = null)
{
	using(var cmd = GetCommand_AddInformation(_text, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetClassification

public System.Data.SqlClient.SqlCommand GetCommand_GetClassification(Guid? _guID, int? timeout = null)
{
var cmd = base.CreateCommand("prd.spGetClassification", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AGuID", IsOutput = false, Value = _guID == null ? DBNull.Value : (object)_guID }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetClassificationAsync(Guid? _guID, int? timeout = null)
{
	using(var cmd = GetCommand_GetClassification(_guID, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetClassificationDapperAsync<T>(Guid? _guID, int? timeout = null)
{
	return await  DapperQueryAsync<T>("prd.spGetClassification",new {AGuID=_guID} , timeout );
}

public ResultSet GetClassification(Guid? _guID, int? timeout = null)
{
	using(var cmd = GetCommand_GetClassification(_guID, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region DeleteClassification

public System.Data.SqlClient.SqlCommand GetCommand_DeleteClassification(Guid? _guID, int? timeout = null)
{
var cmd = base.CreateCommand("prd.spDeleteClassification", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AGuID", IsOutput = false, Value = _guID == null ? DBNull.Value : (object)_guID }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> DeleteClassificationAsync(Guid? _guID, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteClassification(_guID, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> DeleteClassificationDapperAsync<T>(Guid? _guID, int? timeout = null)
{
	return await  DapperQueryAsync<T>("prd.spDeleteClassification",new {AGuID=_guID} , timeout );
}

public ResultSet DeleteClassification(Guid? _guID, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteClassification(_guID, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region ModifyClassification

public System.Data.SqlClient.SqlCommand GetCommand_ModifyClassification(bool? _isNewRecord, Guid? _guID, Guid? _parentID, string _name, string _comment, int? timeout = null)
{
var cmd = base.CreateCommand("prd.spModifyClassification", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AIsNewRecord", IsOutput = false, Value = _isNewRecord == null ? DBNull.Value : (object)_isNewRecord }, 
					new Parameter { Name = "@AGuID", IsOutput = false, Value = _guID == null ? DBNull.Value : (object)_guID }, 
					new Parameter { Name = "@AParentID", IsOutput = false, Value = _parentID == null ? DBNull.Value : (object)_parentID }, 
					new Parameter { Name = "@AName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_name) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_name) }, 
					new Parameter { Name = "@AComment", IsOutput = false, Value = string.IsNullOrWhiteSpace(_comment) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_comment) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> ModifyClassificationAsync(bool? _isNewRecord, Guid? _guID, Guid? _parentID, string _name, string _comment, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyClassification(_isNewRecord, _guID, _parentID, _name, _comment, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> ModifyClassificationDapperAsync<T>(bool? _isNewRecord, Guid? _guID, Guid? _parentID, string _name, string _comment, int? timeout = null)
{
	return await  DapperQueryAsync<T>("prd.spModifyClassification",new {AIsNewRecord=_isNewRecord,AGuID=_guID,AParentID=_parentID,AName=string.IsNullOrWhiteSpace(_name) ? _name : ReplaceArabicWithPersianChars(_name),AComment=string.IsNullOrWhiteSpace(_comment) ? _comment : ReplaceArabicWithPersianChars(_comment)} , timeout );
}

public ResultSet ModifyClassification(bool? _isNewRecord, Guid? _guID, Guid? _parentID, string _name, string _comment, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyClassification(_isNewRecord, _guID, _parentID, _name, _comment, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetProductClassifications

public System.Data.SqlClient.SqlCommand GetCommand_GetProductClassifications(Guid? _parentID, string _name, string _comment, bool? _allChild, bool? _firstNode, bool? _lastNode, int? _pageSize, int? _pageIndex, int? timeout = null)
{
var cmd = base.CreateCommand("prd.spGetProductClassifications", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AParentID", IsOutput = false, Value = _parentID == null ? DBNull.Value : (object)_parentID }, 
					new Parameter { Name = "@AName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_name) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_name) }, 
					new Parameter { Name = "@AComment", IsOutput = false, Value = string.IsNullOrWhiteSpace(_comment) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_comment) }, 
					new Parameter { Name = "@AAllChild", IsOutput = false, Value = _allChild == null ? DBNull.Value : (object)_allChild }, 
					new Parameter { Name = "@AFirstNode", IsOutput = false, Value = _firstNode == null ? DBNull.Value : (object)_firstNode }, 
					new Parameter { Name = "@ALastNode", IsOutput = false, Value = _lastNode == null ? DBNull.Value : (object)_lastNode }, 
					new Parameter { Name = "@APageSize", IsOutput = false, Value = _pageSize == null ? DBNull.Value : (object)_pageSize }, 
					new Parameter { Name = "@APageIndex", IsOutput = false, Value = _pageIndex == null ? DBNull.Value : (object)_pageIndex }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetProductClassificationsAsync(Guid? _parentID, string _name, string _comment, bool? _allChild, bool? _firstNode, bool? _lastNode, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	using(var cmd = GetCommand_GetProductClassifications(_parentID, _name, _comment, _allChild, _firstNode, _lastNode, _pageSize, _pageIndex, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetProductClassificationsDapperAsync<T>(Guid? _parentID, string _name, string _comment, bool? _allChild, bool? _firstNode, bool? _lastNode, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	return await  DapperQueryAsync<T>("prd.spGetProductClassifications",new {AParentID=_parentID,AName=string.IsNullOrWhiteSpace(_name) ? _name : ReplaceArabicWithPersianChars(_name),AComment=string.IsNullOrWhiteSpace(_comment) ? _comment : ReplaceArabicWithPersianChars(_comment),AAllChild=_allChild,AFirstNode=_firstNode,ALastNode=_lastNode,APageSize=_pageSize,APageIndex=_pageIndex} , timeout );
}

public ResultSet GetProductClassifications(Guid? _parentID, string _name, string _comment, bool? _allChild, bool? _firstNode, bool? _lastNode, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	using(var cmd = GetCommand_GetProductClassifications(_parentID, _name, _comment, _allChild, _firstNode, _lastNode, _pageSize, _pageIndex, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetClassifications

public System.Data.SqlClient.SqlCommand GetCommand_GetClassifications(Guid? _parentID, string _name, string _comment, bool? _allChild, bool? _firstNode, bool? _lastNode, int? _pageSize, int? _pageIndex, int? timeout = null)
{
var cmd = base.CreateCommand("prd.spGetClassifications", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AParentID", IsOutput = false, Value = _parentID == null ? DBNull.Value : (object)_parentID }, 
					new Parameter { Name = "@AName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_name) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_name) }, 
					new Parameter { Name = "@AComment", IsOutput = false, Value = string.IsNullOrWhiteSpace(_comment) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_comment) }, 
					new Parameter { Name = "@AAllChild", IsOutput = false, Value = _allChild == null ? DBNull.Value : (object)_allChild }, 
					new Parameter { Name = "@AFirstNode", IsOutput = false, Value = _firstNode == null ? DBNull.Value : (object)_firstNode }, 
					new Parameter { Name = "@ALastNode", IsOutput = false, Value = _lastNode == null ? DBNull.Value : (object)_lastNode }, 
					new Parameter { Name = "@APageSize", IsOutput = false, Value = _pageSize == null ? DBNull.Value : (object)_pageSize }, 
					new Parameter { Name = "@APageIndex", IsOutput = false, Value = _pageIndex == null ? DBNull.Value : (object)_pageIndex }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetClassificationsAsync(Guid? _parentID, string _name, string _comment, bool? _allChild, bool? _firstNode, bool? _lastNode, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	using(var cmd = GetCommand_GetClassifications(_parentID, _name, _comment, _allChild, _firstNode, _lastNode, _pageSize, _pageIndex, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetClassificationsDapperAsync<T>(Guid? _parentID, string _name, string _comment, bool? _allChild, bool? _firstNode, bool? _lastNode, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	return await  DapperQueryAsync<T>("prd.spGetClassifications",new {AParentID=_parentID,AName=string.IsNullOrWhiteSpace(_name) ? _name : ReplaceArabicWithPersianChars(_name),AComment=string.IsNullOrWhiteSpace(_comment) ? _comment : ReplaceArabicWithPersianChars(_comment),AAllChild=_allChild,AFirstNode=_firstNode,ALastNode=_lastNode,APageSize=_pageSize,APageIndex=_pageIndex} , timeout );
}

public ResultSet GetClassifications(Guid? _parentID, string _name, string _comment, bool? _allChild, bool? _firstNode, bool? _lastNode, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	using(var cmd = GetCommand_GetClassifications(_parentID, _name, _comment, _allChild, _firstNode, _lastNode, _pageSize, _pageIndex, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetInformations

public System.Data.SqlClient.SqlCommand GetCommand_GetInformations(string _text, int? _pageSize, int? _pageIndex, int? timeout = null)
{
var cmd = base.CreateCommand("prd.spGetInformations", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AText", IsOutput = false, Value = string.IsNullOrWhiteSpace(_text) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_text) }, 
					new Parameter { Name = "@APageSize", IsOutput = false, Value = _pageSize == null ? DBNull.Value : (object)_pageSize }, 
					new Parameter { Name = "@APageIndex", IsOutput = false, Value = _pageIndex == null ? DBNull.Value : (object)_pageIndex }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetInformationsAsync(string _text, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	using(var cmd = GetCommand_GetInformations(_text, _pageSize, _pageIndex, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetInformationsDapperAsync<T>(string _text, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	return await  DapperQueryAsync<T>("prd.spGetInformations",new {AText=string.IsNullOrWhiteSpace(_text) ? _text : ReplaceArabicWithPersianChars(_text),APageSize=_pageSize,APageIndex=_pageIndex} , timeout );
}

public ResultSet GetInformations(string _text, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	using(var cmd = GetCommand_GetInformations(_text, _pageSize, _pageIndex, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetClassificationInformations

public System.Data.SqlClient.SqlCommand GetCommand_GetClassificationInformations(long? _classificationID, int? timeout = null)
{
var cmd = base.CreateCommand("prd.spGetClassificationInformations", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AClassificationID", IsOutput = false, Value = _classificationID == null ? DBNull.Value : (object)_classificationID }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetClassificationInformationsAsync(long? _classificationID, int? timeout = null)
{
	using(var cmd = GetCommand_GetClassificationInformations(_classificationID, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetClassificationInformationsDapperAsync<T>(long? _classificationID, int? timeout = null)
{
	return await  DapperQueryAsync<T>("prd.spGetClassificationInformations",new {AClassificationID=_classificationID} , timeout );
}

public ResultSet GetClassificationInformations(long? _classificationID, int? timeout = null)
{
	using(var cmd = GetCommand_GetClassificationInformations(_classificationID, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region DeleteClassificationInformation

public System.Data.SqlClient.SqlCommand GetCommand_DeleteClassificationInformation(long? _classificationID, long? _informationID, int? timeout = null)
{
var cmd = base.CreateCommand("prd.spDeleteClassificationInformation", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AClassificationID", IsOutput = false, Value = _classificationID == null ? DBNull.Value : (object)_classificationID }, 
					new Parameter { Name = "@AInformationID", IsOutput = false, Value = _informationID == null ? DBNull.Value : (object)_informationID }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> DeleteClassificationInformationAsync(long? _classificationID, long? _informationID, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteClassificationInformation(_classificationID, _informationID, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> DeleteClassificationInformationDapperAsync<T>(long? _classificationID, long? _informationID, int? timeout = null)
{
	return await  DapperQueryAsync<T>("prd.spDeleteClassificationInformation",new {AClassificationID=_classificationID,AInformationID=_informationID} , timeout );
}

public ResultSet DeleteClassificationInformation(long? _classificationID, long? _informationID, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteClassificationInformation(_classificationID, _informationID, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetDocuments

public System.Data.SqlClient.SqlCommand GetCommand_GetDocuments(long? _itemID, long? _storageID, long? _saleID, long? _orderID, byte? _lastState, int? _pageSize, int? _pageIndex, int? timeout = null)
{
var cmd = base.CreateCommand("prd.spGetDocuments", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AItemID", IsOutput = false, Value = _itemID == null ? DBNull.Value : (object)_itemID }, 
					new Parameter { Name = "@AStorageID", IsOutput = false, Value = _storageID == null ? DBNull.Value : (object)_storageID }, 
					new Parameter { Name = "@ASaleID", IsOutput = false, Value = _saleID == null ? DBNull.Value : (object)_saleID }, 
					new Parameter { Name = "@AOrderID", IsOutput = false, Value = _orderID == null ? DBNull.Value : (object)_orderID }, 
					new Parameter { Name = "@ALastState", IsOutput = false, Value = _lastState == null ? DBNull.Value : (object)_lastState }, 
					new Parameter { Name = "@APageSize", IsOutput = false, Value = _pageSize == null ? DBNull.Value : (object)_pageSize }, 
					new Parameter { Name = "@APageIndex", IsOutput = false, Value = _pageIndex == null ? DBNull.Value : (object)_pageIndex }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetDocumentsAsync(long? _itemID, long? _storageID, long? _saleID, long? _orderID, byte? _lastState, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	using(var cmd = GetCommand_GetDocuments(_itemID, _storageID, _saleID, _orderID, _lastState, _pageSize, _pageIndex, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetDocumentsDapperAsync<T>(long? _itemID, long? _storageID, long? _saleID, long? _orderID, byte? _lastState, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	return await  DapperQueryAsync<T>("prd.spGetDocuments",new {AItemID=_itemID,AStorageID=_storageID,ASaleID=_saleID,AOrderID=_orderID,ALastState=_lastState,APageSize=_pageSize,APageIndex=_pageIndex} , timeout );
}

public ResultSet GetDocuments(long? _itemID, long? _storageID, long? _saleID, long? _orderID, byte? _lastState, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	using(var cmd = GetCommand_GetDocuments(_itemID, _storageID, _saleID, _orderID, _lastState, _pageSize, _pageIndex, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region AddClassificationInformation

public System.Data.SqlClient.SqlCommand GetCommand_AddClassificationInformation(long? _classificationID, long? _informationID, int? timeout = null)
{
var cmd = base.CreateCommand("prd.spAddClassificationInformation", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AClassificationID", IsOutput = false, Value = _classificationID == null ? DBNull.Value : (object)_classificationID }, 
					new Parameter { Name = "@AInformationID", IsOutput = false, Value = _informationID == null ? DBNull.Value : (object)_informationID }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> AddClassificationInformationAsync(long? _classificationID, long? _informationID, int? timeout = null)
{
	using(var cmd = GetCommand_AddClassificationInformation(_classificationID, _informationID, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> AddClassificationInformationDapperAsync<T>(long? _classificationID, long? _informationID, int? timeout = null)
{
	return await  DapperQueryAsync<T>("prd.spAddClassificationInformation",new {AClassificationID=_classificationID,AInformationID=_informationID} , timeout );
}

public ResultSet AddClassificationInformation(long? _classificationID, long? _informationID, int? timeout = null)
{
	using(var cmd = GetCommand_AddClassificationInformation(_classificationID, _informationID, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetDocument

public System.Data.SqlClient.SqlCommand GetCommand_GetDocument(long? _id, int? timeout = null)
{
var cmd = base.CreateCommand("prd.spGetDocument", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetDocumentAsync(long? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetDocument(_id, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetDocumentDapperAsync<T>(long? _id, int? timeout = null)
{
	return await  DapperQueryAsync<T>("prd.spGetDocument",new {AID=_id} , timeout );
}

public ResultSet GetDocument(long? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetDocument(_id, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

}

class PBL: Database
{
#region Constructors
public PBL(string connectionString)
	:base(connectionString){}

public PBL(string connectionString, IModelValueBinder modelValueBinder)
	:base(connectionString, modelValueBinder){}
#endregion

#region AddDepo

public System.Data.SqlClient.SqlCommand GetCommand_AddDepo(Guid? _guID, long? _itemID, int? _number, long? _priceBuy, long? _priceSale, byte? _type, string _comment, int? timeout = null)
{
var cmd = base.CreateCommand("pbl.spAddDepo", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AGuID", IsOutput = false, Value = _guID == null ? DBNull.Value : (object)_guID }, 
					new Parameter { Name = "@AItemID", IsOutput = false, Value = _itemID == null ? DBNull.Value : (object)_itemID }, 
					new Parameter { Name = "@ANumber", IsOutput = false, Value = _number == null ? DBNull.Value : (object)_number }, 
					new Parameter { Name = "@APriceBuy", IsOutput = false, Value = _priceBuy == null ? DBNull.Value : (object)_priceBuy }, 
					new Parameter { Name = "@APriceSale", IsOutput = false, Value = _priceSale == null ? DBNull.Value : (object)_priceSale }, 
					new Parameter { Name = "@AType", IsOutput = false, Value = _type == null ? DBNull.Value : (object)_type }, 
					new Parameter { Name = "@AComment", IsOutput = false, Value = string.IsNullOrWhiteSpace(_comment) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_comment) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> AddDepoAsync(Guid? _guID, long? _itemID, int? _number, long? _priceBuy, long? _priceSale, byte? _type, string _comment, int? timeout = null)
{
	using(var cmd = GetCommand_AddDepo(_guID, _itemID, _number, _priceBuy, _priceSale, _type, _comment, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> AddDepoDapperAsync<T>(Guid? _guID, long? _itemID, int? _number, long? _priceBuy, long? _priceSale, byte? _type, string _comment, int? timeout = null)
{
	return await  DapperQueryAsync<T>("pbl.spAddDepo",new {AGuID=_guID,AItemID=_itemID,ANumber=_number,APriceBuy=_priceBuy,APriceSale=_priceSale,AType=_type,AComment=string.IsNullOrWhiteSpace(_comment) ? _comment : ReplaceArabicWithPersianChars(_comment)} , timeout );
}

public ResultSet AddDepo(Guid? _guID, long? _itemID, int? _number, long? _priceBuy, long? _priceSale, byte? _type, string _comment, int? timeout = null)
{
	using(var cmd = GetCommand_AddDepo(_guID, _itemID, _number, _priceBuy, _priceSale, _type, _comment, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetDepo

public System.Data.SqlClient.SqlCommand GetCommand_GetDepo(long? _id, Guid? _guID, int? timeout = null)
{
var cmd = base.CreateCommand("pbl.spGetDepo", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@AGuID", IsOutput = false, Value = _guID == null ? DBNull.Value : (object)_guID }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetDepoAsync(long? _id, Guid? _guID, int? timeout = null)
{
	using(var cmd = GetCommand_GetDepo(_id, _guID, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetDepoDapperAsync<T>(long? _id, Guid? _guID, int? timeout = null)
{
	return await  DapperQueryAsync<T>("pbl.spGetDepo",new {AID=_id,AGuID=_guID} , timeout );
}

public ResultSet GetDepo(long? _id, Guid? _guID, int? timeout = null)
{
	using(var cmd = GetCommand_GetDepo(_id, _guID, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region AddStorageDepo

public System.Data.SqlClient.SqlCommand GetCommand_AddStorageDepo(Guid? _guID, string _documentGuID, long? _itemID, int? _number, long? _priceBuy, string _comment, Guid? _creatorID, DateTime? _expired, int? timeout = null)
{
var cmd = base.CreateCommand("pbl.spAddStorageDepo", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AGuID", IsOutput = false, Value = _guID == null ? DBNull.Value : (object)_guID }, 
					new Parameter { Name = "@ADocumentGuID", IsOutput = false, Value = string.IsNullOrWhiteSpace(_documentGuID) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_documentGuID) }, 
					new Parameter { Name = "@AItemID", IsOutput = false, Value = _itemID == null ? DBNull.Value : (object)_itemID }, 
					new Parameter { Name = "@ANumber", IsOutput = false, Value = _number == null ? DBNull.Value : (object)_number }, 
					new Parameter { Name = "@APriceBuy", IsOutput = false, Value = _priceBuy == null ? DBNull.Value : (object)_priceBuy }, 
					new Parameter { Name = "@AComment", IsOutput = false, Value = string.IsNullOrWhiteSpace(_comment) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_comment) }, 
					new Parameter { Name = "@ACreatorID", IsOutput = false, Value = _creatorID == null ? DBNull.Value : (object)_creatorID }, 
					new Parameter { Name = "@AExpired", IsOutput = false, Value = _expired == null ? DBNull.Value : (object)_expired }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> AddStorageDepoAsync(Guid? _guID, string _documentGuID, long? _itemID, int? _number, long? _priceBuy, string _comment, Guid? _creatorID, DateTime? _expired, int? timeout = null)
{
	using(var cmd = GetCommand_AddStorageDepo(_guID, _documentGuID, _itemID, _number, _priceBuy, _comment, _creatorID, _expired, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> AddStorageDepoDapperAsync<T>(Guid? _guID, string _documentGuID, long? _itemID, int? _number, long? _priceBuy, string _comment, Guid? _creatorID, DateTime? _expired, int? timeout = null)
{
	return await  DapperQueryAsync<T>("pbl.spAddStorageDepo",new {AGuID=_guID,ADocumentGuID=string.IsNullOrWhiteSpace(_documentGuID) ? _documentGuID : ReplaceArabicWithPersianChars(_documentGuID),AItemID=_itemID,ANumber=_number,APriceBuy=_priceBuy,AComment=string.IsNullOrWhiteSpace(_comment) ? _comment : ReplaceArabicWithPersianChars(_comment),ACreatorID=_creatorID,AExpired=_expired} , timeout );
}

public ResultSet AddStorageDepo(Guid? _guID, string _documentGuID, long? _itemID, int? _number, long? _priceBuy, string _comment, Guid? _creatorID, DateTime? _expired, int? timeout = null)
{
	using(var cmd = GetCommand_AddStorageDepo(_guID, _documentGuID, _itemID, _number, _priceBuy, _comment, _creatorID, _expired, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region DeleteAttachment

public System.Data.SqlClient.SqlCommand GetCommand_DeleteAttachment(long? _id, int? timeout = null)
{
var cmd = base.CreateCommand("pbl.spDeleteAttachment", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> DeleteAttachmentAsync(long? _id, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteAttachment(_id, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> DeleteAttachmentDapperAsync<T>(long? _id, int? timeout = null)
{
	return await  DapperQueryAsync<T>("pbl.spDeleteAttachment",new {AID=_id} , timeout );
}

public ResultSet DeleteAttachment(long? _id, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteAttachment(_id, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region DepoIndex

public System.Data.SqlClient.SqlCommand GetCommand_DepoIndex(int? timeout = null)
{
var cmd = base.CreateCommand("pbl.spDepoIndex", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> DepoIndexAsync(int? timeout = null)
{
	using(var cmd = GetCommand_DepoIndex(timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> DepoIndexDapperAsync<T>(int? timeout = null)
{
	return await  DapperQueryAsync<T>("pbl.spDepoIndex",new {} , timeout );
}

public ResultSet DepoIndex(int? timeout = null)
{
	using(var cmd = GetCommand_DepoIndex(timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetAttachment

public System.Data.SqlClient.SqlCommand GetCommand_GetAttachment(long? _id, int? timeout = null)
{
var cmd = base.CreateCommand("pbl.spGetAttachment", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetAttachmentAsync(long? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetAttachment(_id, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetAttachmentDapperAsync<T>(long? _id, int? timeout = null)
{
	return await  DapperQueryAsync<T>("pbl.spGetAttachment",new {AID=_id} , timeout );
}

public ResultSet GetAttachment(long? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetAttachment(_id, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetDepos

public System.Data.SqlClient.SqlCommand GetCommand_GetDepos(long? _itemID, byte? _type, string _comment, int? _pageSize, int? _pageIndex, int? timeout = null)
{
var cmd = base.CreateCommand("pbl.spGetDepos", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AItemID", IsOutput = false, Value = _itemID == null ? DBNull.Value : (object)_itemID }, 
					new Parameter { Name = "@AType", IsOutput = false, Value = _type == null ? DBNull.Value : (object)_type }, 
					new Parameter { Name = "@AComment", IsOutput = false, Value = string.IsNullOrWhiteSpace(_comment) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_comment) }, 
					new Parameter { Name = "@APageSize", IsOutput = false, Value = _pageSize == null ? DBNull.Value : (object)_pageSize }, 
					new Parameter { Name = "@APageIndex", IsOutput = false, Value = _pageIndex == null ? DBNull.Value : (object)_pageIndex }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetDeposAsync(long? _itemID, byte? _type, string _comment, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	using(var cmd = GetCommand_GetDepos(_itemID, _type, _comment, _pageSize, _pageIndex, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetDeposDapperAsync<T>(long? _itemID, byte? _type, string _comment, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	return await  DapperQueryAsync<T>("pbl.spGetDepos",new {AItemID=_itemID,AType=_type,AComment=string.IsNullOrWhiteSpace(_comment) ? _comment : ReplaceArabicWithPersianChars(_comment),APageSize=_pageSize,APageIndex=_pageIndex} , timeout );
}

public ResultSet GetDepos(long? _itemID, byte? _type, string _comment, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	using(var cmd = GetCommand_GetDepos(_itemID, _type, _comment, _pageSize, _pageIndex, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetAttachments

public System.Data.SqlClient.SqlCommand GetCommand_GetAttachments(string _parentIDs, int? timeout = null)
{
var cmd = base.CreateCommand("pbl.spGetAttachments", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AParentIDs", IsOutput = false, Value = string.IsNullOrWhiteSpace(_parentIDs) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_parentIDs) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetAttachmentsAsync(string _parentIDs, int? timeout = null)
{
	using(var cmd = GetCommand_GetAttachments(_parentIDs, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetAttachmentsDapperAsync<T>(string _parentIDs, int? timeout = null)
{
	return await  DapperQueryAsync<T>("pbl.spGetAttachments",new {AParentIDs=string.IsNullOrWhiteSpace(_parentIDs) ? _parentIDs : ReplaceArabicWithPersianChars(_parentIDs)} , timeout );
}

public ResultSet GetAttachments(string _parentIDs, int? timeout = null)
{
	using(var cmd = GetCommand_GetAttachments(_parentIDs, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region ModifyAttachment

public System.Data.SqlClient.SqlCommand GetCommand_ModifyAttachment(bool? _isNewRecord, long? _id, Guid? _parentID, byte? _type, string _fileName, string _comment, string _urL, int? timeout = null)
{
var cmd = base.CreateCommand("pbl.spModifyAttachment", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AIsNewRecord", IsOutput = false, Value = _isNewRecord == null ? DBNull.Value : (object)_isNewRecord }, 
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@AParentID", IsOutput = false, Value = _parentID == null ? DBNull.Value : (object)_parentID }, 
					new Parameter { Name = "@AType", IsOutput = false, Value = _type == null ? DBNull.Value : (object)_type }, 
					new Parameter { Name = "@AFileName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_fileName) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_fileName) }, 
					new Parameter { Name = "@AComment", IsOutput = false, Value = string.IsNullOrWhiteSpace(_comment) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_comment) }, 
					new Parameter { Name = "@AUrL", IsOutput = false, Value = string.IsNullOrWhiteSpace(_urL) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_urL) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> ModifyAttachmentAsync(bool? _isNewRecord, long? _id, Guid? _parentID, byte? _type, string _fileName, string _comment, string _urL, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyAttachment(_isNewRecord, _id, _parentID, _type, _fileName, _comment, _urL, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> ModifyAttachmentDapperAsync<T>(bool? _isNewRecord, long? _id, Guid? _parentID, byte? _type, string _fileName, string _comment, string _urL, int? timeout = null)
{
	return await  DapperQueryAsync<T>("pbl.spModifyAttachment",new {AIsNewRecord=_isNewRecord,AID=_id,AParentID=_parentID,AType=_type,AFileName=string.IsNullOrWhiteSpace(_fileName) ? _fileName : ReplaceArabicWithPersianChars(_fileName),AComment=string.IsNullOrWhiteSpace(_comment) ? _comment : ReplaceArabicWithPersianChars(_comment),AUrL=string.IsNullOrWhiteSpace(_urL) ? _urL : ReplaceArabicWithPersianChars(_urL)} , timeout );
}

public ResultSet ModifyAttachment(bool? _isNewRecord, long? _id, Guid? _parentID, byte? _type, string _fileName, string _comment, string _urL, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyAttachment(_isNewRecord, _id, _parentID, _type, _fileName, _comment, _urL, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region DepoIndexList

public System.Data.SqlClient.SqlCommand GetCommand_DepoIndexList(long? _itemID, byte? _type, int? _pageSize, int? _pageIndex, int? timeout = null)
{
var cmd = base.CreateCommand("pbl.spDepoIndexList", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AItemID", IsOutput = false, Value = _itemID == null ? DBNull.Value : (object)_itemID }, 
					new Parameter { Name = "@AType", IsOutput = false, Value = _type == null ? DBNull.Value : (object)_type }, 
					new Parameter { Name = "@APageSize", IsOutput = false, Value = _pageSize == null ? DBNull.Value : (object)_pageSize }, 
					new Parameter { Name = "@APageIndex", IsOutput = false, Value = _pageIndex == null ? DBNull.Value : (object)_pageIndex }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> DepoIndexListAsync(long? _itemID, byte? _type, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	using(var cmd = GetCommand_DepoIndexList(_itemID, _type, _pageSize, _pageIndex, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> DepoIndexListDapperAsync<T>(long? _itemID, byte? _type, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	return await  DapperQueryAsync<T>("pbl.spDepoIndexList",new {AItemID=_itemID,AType=_type,APageSize=_pageSize,APageIndex=_pageIndex} , timeout );
}

public ResultSet DepoIndexList(long? _itemID, byte? _type, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	using(var cmd = GetCommand_DepoIndexList(_itemID, _type, _pageSize, _pageIndex, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetTags

public System.Data.SqlClient.SqlCommand GetCommand_GetTags(long? _itemID, int? timeout = null)
{
var cmd = base.CreateCommand("pbl.spGetTags", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AItemID", IsOutput = false, Value = _itemID == null ? DBNull.Value : (object)_itemID }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetTagsAsync(long? _itemID, int? timeout = null)
{
	using(var cmd = GetCommand_GetTags(_itemID, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetTagsDapperAsync<T>(long? _itemID, int? timeout = null)
{
	return await  DapperQueryAsync<T>("pbl.spGetTags",new {AItemID=_itemID} , timeout );
}

public ResultSet GetTags(long? _itemID, int? timeout = null)
{
	using(var cmd = GetCommand_GetTags(_itemID, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region DeleteTag

public System.Data.SqlClient.SqlCommand GetCommand_DeleteTag(int? _tagID, long? _itemID, int? timeout = null)
{
var cmd = base.CreateCommand("pbl.spDeleteTag", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@ATagID", IsOutput = false, Value = _tagID == null ? DBNull.Value : (object)_tagID }, 
					new Parameter { Name = "@AItemID", IsOutput = false, Value = _itemID == null ? DBNull.Value : (object)_itemID }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> DeleteTagAsync(int? _tagID, long? _itemID, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteTag(_tagID, _itemID, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> DeleteTagDapperAsync<T>(int? _tagID, long? _itemID, int? timeout = null)
{
	return await  DapperQueryAsync<T>("pbl.spDeleteTag",new {ATagID=_tagID,AItemID=_itemID} , timeout );
}

public ResultSet DeleteTag(int? _tagID, long? _itemID, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteTag(_tagID, _itemID, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region AddTag

public System.Data.SqlClient.SqlCommand GetCommand_AddTag(long? _itemID, string _tag, int? timeout = null)
{
var cmd = base.CreateCommand("pbl.spAddTag", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AItemID", IsOutput = false, Value = _itemID == null ? DBNull.Value : (object)_itemID }, 
					new Parameter { Name = "@ATag", IsOutput = false, Value = string.IsNullOrWhiteSpace(_tag) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_tag) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> AddTagAsync(long? _itemID, string _tag, int? timeout = null)
{
	using(var cmd = GetCommand_AddTag(_itemID, _tag, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> AddTagDapperAsync<T>(long? _itemID, string _tag, int? timeout = null)
{
	return await  DapperQueryAsync<T>("pbl.spAddTag",new {AItemID=_itemID,ATag=string.IsNullOrWhiteSpace(_tag) ? _tag : ReplaceArabicWithPersianChars(_tag)} , timeout );
}

public ResultSet AddTag(long? _itemID, string _tag, int? timeout = null)
{
	using(var cmd = GetCommand_AddTag(_itemID, _tag, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetFlows

public System.Data.SqlClient.SqlCommand GetCommand_GetFlows(int? _documentID, int? timeout = null)
{
var cmd = base.CreateCommand("pbl.spGetFlows", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@ADocumentID", IsOutput = false, Value = _documentID == null ? DBNull.Value : (object)_documentID }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetFlowsAsync(int? _documentID, int? timeout = null)
{
	using(var cmd = GetCommand_GetFlows(_documentID, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetFlowsDapperAsync<T>(int? _documentID, int? timeout = null)
{
	return await  DapperQueryAsync<T>("pbl.spGetFlows",new {ADocumentID=_documentID} , timeout );
}

public ResultSet GetFlows(int? _documentID, int? timeout = null)
{
	using(var cmd = GetCommand_GetFlows(_documentID, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetBrand

public System.Data.SqlClient.SqlCommand GetCommand_GetBrand(long? _id, Guid? _guID, int? timeout = null)
{
var cmd = base.CreateCommand("pbl.spGetBrand", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@AGuID", IsOutput = false, Value = _guID == null ? DBNull.Value : (object)_guID }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetBrandAsync(long? _id, Guid? _guID, int? timeout = null)
{
	using(var cmd = GetCommand_GetBrand(_id, _guID, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetBrandDapperAsync<T>(long? _id, Guid? _guID, int? timeout = null)
{
	return await  DapperQueryAsync<T>("pbl.spGetBrand",new {AID=_id,AGuID=_guID} , timeout );
}

public ResultSet GetBrand(long? _id, Guid? _guID, int? timeout = null)
{
	using(var cmd = GetCommand_GetBrand(_id, _guID, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region DeleteBrand

public System.Data.SqlClient.SqlCommand GetCommand_DeleteBrand(long? _id, int? timeout = null)
{
var cmd = base.CreateCommand("pbl.spDeleteBrand", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> DeleteBrandAsync(long? _id, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteBrand(_id, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> DeleteBrandDapperAsync<T>(long? _id, int? timeout = null)
{
	return await  DapperQueryAsync<T>("pbl.spDeleteBrand",new {AID=_id} , timeout );
}

public ResultSet DeleteBrand(long? _id, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteBrand(_id, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetBrands

public System.Data.SqlClient.SqlCommand GetCommand_GetBrands(string _faName, string _enName, int? _pageSize, int? _pageIndex, int? timeout = null)
{
var cmd = base.CreateCommand("pbl.spGetBrands", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AFaName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_faName) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_faName) }, 
					new Parameter { Name = "@AEnName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_enName) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_enName) }, 
					new Parameter { Name = "@APageSize", IsOutput = false, Value = _pageSize == null ? DBNull.Value : (object)_pageSize }, 
					new Parameter { Name = "@APageIndex", IsOutput = false, Value = _pageIndex == null ? DBNull.Value : (object)_pageIndex }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetBrandsAsync(string _faName, string _enName, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	using(var cmd = GetCommand_GetBrands(_faName, _enName, _pageSize, _pageIndex, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetBrandsDapperAsync<T>(string _faName, string _enName, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	return await  DapperQueryAsync<T>("pbl.spGetBrands",new {AFaName=string.IsNullOrWhiteSpace(_faName) ? _faName : ReplaceArabicWithPersianChars(_faName),AEnName=string.IsNullOrWhiteSpace(_enName) ? _enName : ReplaceArabicWithPersianChars(_enName),APageSize=_pageSize,APageIndex=_pageIndex} , timeout );
}

public ResultSet GetBrands(string _faName, string _enName, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	using(var cmd = GetCommand_GetBrands(_faName, _enName, _pageSize, _pageIndex, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region ModifyBrand

public System.Data.SqlClient.SqlCommand GetCommand_ModifyBrand(bool? _isNewRecord, long? _id, Guid? _guID, string _faName, string _enName, int? timeout = null)
{
var cmd = base.CreateCommand("pbl.spModifyBrand", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AIsNewRecord", IsOutput = false, Value = _isNewRecord == null ? DBNull.Value : (object)_isNewRecord }, 
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@AGuID", IsOutput = false, Value = _guID == null ? DBNull.Value : (object)_guID }, 
					new Parameter { Name = "@AFaName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_faName) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_faName) }, 
					new Parameter { Name = "@AEnName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_enName) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_enName) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> ModifyBrandAsync(bool? _isNewRecord, long? _id, Guid? _guID, string _faName, string _enName, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyBrand(_isNewRecord, _id, _guID, _faName, _enName, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> ModifyBrandDapperAsync<T>(bool? _isNewRecord, long? _id, Guid? _guID, string _faName, string _enName, int? timeout = null)
{
	return await  DapperQueryAsync<T>("pbl.spModifyBrand",new {AIsNewRecord=_isNewRecord,AID=_id,AGuID=_guID,AFaName=string.IsNullOrWhiteSpace(_faName) ? _faName : ReplaceArabicWithPersianChars(_faName),AEnName=string.IsNullOrWhiteSpace(_enName) ? _enName : ReplaceArabicWithPersianChars(_enName)} , timeout );
}

public ResultSet ModifyBrand(bool? _isNewRecord, long? _id, Guid? _guID, string _faName, string _enName, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyBrand(_isNewRecord, _id, _guID, _faName, _enName, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region DeleteDepo

public System.Data.SqlClient.SqlCommand GetCommand_DeleteDepo(long? _id, int? timeout = null)
{
var cmd = base.CreateCommand("pbl.spDeleteDepo", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> DeleteDepoAsync(long? _id, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteDepo(_id, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> DeleteDepoDapperAsync<T>(long? _id, int? timeout = null)
{
	return await  DapperQueryAsync<T>("pbl.spDeleteDepo",new {AID=_id} , timeout );
}

public ResultSet DeleteDepo(long? _id, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteDepo(_id, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

}

}

