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

#region GetDocument

public System.Data.SqlClient.SqlCommand GetCommand_GetDocument(long? _type, int? timeout = null)
{
var cmd = base.CreateCommand("prd.spGetDocument", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AType", IsOutput = false, Value = _type == null ? DBNull.Value : (object)_type }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetDocumentAsync(long? _type, int? timeout = null)
{
	using(var cmd = GetCommand_GetDocument(_type, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetDocumentDapperAsync<T>(long? _type, int? timeout = null)
{
	return await  DapperQueryAsync<T>("prd.spGetDocument",new {AType=_type} , timeout );
}

public ResultSet GetDocument(long? _type, int? timeout = null)
{
	using(var cmd = GetCommand_GetDocument(_type, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region DeleteProduct

public System.Data.SqlClient.SqlCommand GetCommand_DeleteProduct(long? _id, int? timeout = null)
{
var cmd = base.CreateCommand("prd.spDeleteProduct", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> DeleteProductAsync(long? _id, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteProduct(_id, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> DeleteProductDapperAsync<T>(long? _id, int? timeout = null)
{
	return await  DapperQueryAsync<T>("prd.spDeleteProduct",new {AID=_id} , timeout );
}

public ResultSet DeleteProduct(long? _id, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteProduct(_id, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetProduct

public System.Data.SqlClient.SqlCommand GetCommand_GetProduct(long? _id, Guid? _guID, int? timeout = null)
{
var cmd = base.CreateCommand("prd.spGetProduct", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@AGuID", IsOutput = false, Value = _guID == null ? DBNull.Value : (object)_guID }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetProductAsync(long? _id, Guid? _guID, int? timeout = null)
{
	using(var cmd = GetCommand_GetProduct(_id, _guID, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetProductDapperAsync<T>(long? _id, Guid? _guID, int? timeout = null)
{
	return await  DapperQueryAsync<T>("prd.spGetProduct",new {AID=_id,AGuID=_guID} , timeout );
}

public ResultSet GetProduct(long? _id, Guid? _guID, int? timeout = null)
{
	using(var cmd = GetCommand_GetProduct(_id, _guID, timeout))
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

#region GetStocks

public System.Data.SqlClient.SqlCommand GetCommand_GetStocks(long? _id, string _name, long? _classificationID, int? _pageSize, int? _pageIndex, int? timeout = null)
{
var cmd = base.CreateCommand("prd.spGetStocks", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@AName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_name) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_name) }, 
					new Parameter { Name = "@AClassificationID", IsOutput = false, Value = _classificationID == null ? DBNull.Value : (object)_classificationID }, 
					new Parameter { Name = "@APageSize", IsOutput = false, Value = _pageSize == null ? DBNull.Value : (object)_pageSize }, 
					new Parameter { Name = "@APageIndex", IsOutput = false, Value = _pageIndex == null ? DBNull.Value : (object)_pageIndex }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetStocksAsync(long? _id, string _name, long? _classificationID, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	using(var cmd = GetCommand_GetStocks(_id, _name, _classificationID, _pageSize, _pageIndex, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetStocksDapperAsync<T>(long? _id, string _name, long? _classificationID, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	return await  DapperQueryAsync<T>("prd.spGetStocks",new {AID=_id,AName=string.IsNullOrWhiteSpace(_name) ? _name : ReplaceArabicWithPersianChars(_name),AClassificationID=_classificationID,APageSize=_pageSize,APageIndex=_pageIndex} , timeout );
}

public ResultSet GetStocks(long? _id, string _name, long? _classificationID, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	using(var cmd = GetCommand_GetStocks(_id, _name, _classificationID, _pageSize, _pageIndex, timeout))
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

#region AddTag

public System.Data.SqlClient.SqlCommand GetCommand_AddTag(long? _productID, string _tag, int? timeout = null)
{
var cmd = base.CreateCommand("prd.spAddTag", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AProductID", IsOutput = false, Value = _productID == null ? DBNull.Value : (object)_productID }, 
					new Parameter { Name = "@ATag", IsOutput = false, Value = string.IsNullOrWhiteSpace(_tag) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_tag) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> AddTagAsync(long? _productID, string _tag, int? timeout = null)
{
	using(var cmd = GetCommand_AddTag(_productID, _tag, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> AddTagDapperAsync<T>(long? _productID, string _tag, int? timeout = null)
{
	return await  DapperQueryAsync<T>("prd.spAddTag",new {AProductID=_productID,ATag=string.IsNullOrWhiteSpace(_tag) ? _tag : ReplaceArabicWithPersianChars(_tag)} , timeout );
}

public ResultSet AddTag(long? _productID, string _tag, int? timeout = null)
{
	using(var cmd = GetCommand_AddTag(_productID, _tag, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region DeleteTag

public System.Data.SqlClient.SqlCommand GetCommand_DeleteTag(int? _tagID, long? _productID, int? timeout = null)
{
var cmd = base.CreateCommand("prd.spDeleteTag", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@ATagID", IsOutput = false, Value = _tagID == null ? DBNull.Value : (object)_tagID }, 
					new Parameter { Name = "@AProductID", IsOutput = false, Value = _productID == null ? DBNull.Value : (object)_productID }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> DeleteTagAsync(int? _tagID, long? _productID, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteTag(_tagID, _productID, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> DeleteTagDapperAsync<T>(int? _tagID, long? _productID, int? timeout = null)
{
	return await  DapperQueryAsync<T>("prd.spDeleteTag",new {ATagID=_tagID,AProductID=_productID} , timeout );
}

public ResultSet DeleteTag(int? _tagID, long? _productID, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteTag(_tagID, _productID, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetTags

public System.Data.SqlClient.SqlCommand GetCommand_GetTags(long? _productID, int? timeout = null)
{
var cmd = base.CreateCommand("prd.spGetTags", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AProductID", IsOutput = false, Value = _productID == null ? DBNull.Value : (object)_productID }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetTagsAsync(long? _productID, int? timeout = null)
{
	using(var cmd = GetCommand_GetTags(_productID, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetTagsDapperAsync<T>(long? _productID, int? timeout = null)
{
	return await  DapperQueryAsync<T>("prd.spGetTags",new {AProductID=_productID} , timeout );
}

public ResultSet GetTags(long? _productID, int? timeout = null)
{
	using(var cmd = GetCommand_GetTags(_productID, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region ModifyProduct

public System.Data.SqlClient.SqlCommand GetCommand_ModifyProduct(bool? _isNewRecord, long? _id, Guid? _guID, long? _parentID, string _name, string _comment, long? _price, long? _discount, string _information, int? timeout = null)
{
var cmd = base.CreateCommand("prd.spModifyProduct", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AIsNewRecord", IsOutput = false, Value = _isNewRecord == null ? DBNull.Value : (object)_isNewRecord }, 
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@AGuID", IsOutput = false, Value = _guID == null ? DBNull.Value : (object)_guID }, 
					new Parameter { Name = "@AParentID", IsOutput = false, Value = _parentID == null ? DBNull.Value : (object)_parentID }, 
					new Parameter { Name = "@AName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_name) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_name) }, 
					new Parameter { Name = "@AComment", IsOutput = false, Value = string.IsNullOrWhiteSpace(_comment) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_comment) }, 
					new Parameter { Name = "@APrice", IsOutput = false, Value = _price == null ? DBNull.Value : (object)_price }, 
					new Parameter { Name = "@ADiscount", IsOutput = false, Value = _discount == null ? DBNull.Value : (object)_discount }, 
					new Parameter { Name = "@AInformation", IsOutput = false, Value = string.IsNullOrWhiteSpace(_information) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_information) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> ModifyProductAsync(bool? _isNewRecord, long? _id, Guid? _guID, long? _parentID, string _name, string _comment, long? _price, long? _discount, string _information, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyProduct(_isNewRecord, _id, _guID, _parentID, _name, _comment, _price, _discount, _information, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> ModifyProductDapperAsync<T>(bool? _isNewRecord, long? _id, Guid? _guID, long? _parentID, string _name, string _comment, long? _price, long? _discount, string _information, int? timeout = null)
{
	return await  DapperQueryAsync<T>("prd.spModifyProduct",new {AIsNewRecord=_isNewRecord,AID=_id,AGuID=_guID,AParentID=_parentID,AName=string.IsNullOrWhiteSpace(_name) ? _name : ReplaceArabicWithPersianChars(_name),AComment=string.IsNullOrWhiteSpace(_comment) ? _comment : ReplaceArabicWithPersianChars(_comment),APrice=_price,ADiscount=_discount,AInformation=string.IsNullOrWhiteSpace(_information) ? _information : ReplaceArabicWithPersianChars(_information)} , timeout );
}

public ResultSet ModifyProduct(bool? _isNewRecord, long? _id, Guid? _guID, long? _parentID, string _name, string _comment, long? _price, long? _discount, string _information, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyProduct(_isNewRecord, _id, _guID, _parentID, _name, _comment, _price, _discount, _information, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetProductClassifications

public System.Data.SqlClient.SqlCommand GetCommand_GetProductClassifications(Guid? _parentID, string _name, string _comment, bool? _allChild, int? _pageSize, int? _pageIndex, int? timeout = null)
{
var cmd = base.CreateCommand("prd.spGetProductClassifications", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AParentID", IsOutput = false, Value = _parentID == null ? DBNull.Value : (object)_parentID }, 
					new Parameter { Name = "@AName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_name) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_name) }, 
					new Parameter { Name = "@AComment", IsOutput = false, Value = string.IsNullOrWhiteSpace(_comment) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_comment) }, 
					new Parameter { Name = "@AAllChild", IsOutput = false, Value = _allChild == null ? DBNull.Value : (object)_allChild }, 
					new Parameter { Name = "@APageSize", IsOutput = false, Value = _pageSize == null ? DBNull.Value : (object)_pageSize }, 
					new Parameter { Name = "@APageIndex", IsOutput = false, Value = _pageIndex == null ? DBNull.Value : (object)_pageIndex }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetProductClassificationsAsync(Guid? _parentID, string _name, string _comment, bool? _allChild, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	using(var cmd = GetCommand_GetProductClassifications(_parentID, _name, _comment, _allChild, _pageSize, _pageIndex, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetProductClassificationsDapperAsync<T>(Guid? _parentID, string _name, string _comment, bool? _allChild, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	return await  DapperQueryAsync<T>("prd.spGetProductClassifications",new {AParentID=_parentID,AName=string.IsNullOrWhiteSpace(_name) ? _name : ReplaceArabicWithPersianChars(_name),AComment=string.IsNullOrWhiteSpace(_comment) ? _comment : ReplaceArabicWithPersianChars(_comment),AAllChild=_allChild,APageSize=_pageSize,APageIndex=_pageIndex} , timeout );
}

public ResultSet GetProductClassifications(Guid? _parentID, string _name, string _comment, bool? _allChild, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	using(var cmd = GetCommand_GetProductClassifications(_parentID, _name, _comment, _allChild, _pageSize, _pageIndex, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetProducts

public System.Data.SqlClient.SqlCommand GetCommand_GetProducts(long? _parentID, string _name, string _comment, long? _startPrice, long? _endPrice, int? _pageSize, int? _pageIndex, int? timeout = null)
{
var cmd = base.CreateCommand("prd.spGetProducts", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AParentID", IsOutput = false, Value = _parentID == null ? DBNull.Value : (object)_parentID }, 
					new Parameter { Name = "@AName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_name) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_name) }, 
					new Parameter { Name = "@AComment", IsOutput = false, Value = string.IsNullOrWhiteSpace(_comment) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_comment) }, 
					new Parameter { Name = "@AStartPrice", IsOutput = false, Value = _startPrice == null ? DBNull.Value : (object)_startPrice }, 
					new Parameter { Name = "@AEndPrice", IsOutput = false, Value = _endPrice == null ? DBNull.Value : (object)_endPrice }, 
					new Parameter { Name = "@APageSize", IsOutput = false, Value = _pageSize == null ? DBNull.Value : (object)_pageSize }, 
					new Parameter { Name = "@APageIndex", IsOutput = false, Value = _pageIndex == null ? DBNull.Value : (object)_pageIndex }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetProductsAsync(long? _parentID, string _name, string _comment, long? _startPrice, long? _endPrice, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	using(var cmd = GetCommand_GetProducts(_parentID, _name, _comment, _startPrice, _endPrice, _pageSize, _pageIndex, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetProductsDapperAsync<T>(long? _parentID, string _name, string _comment, long? _startPrice, long? _endPrice, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	return await  DapperQueryAsync<T>("prd.spGetProducts",new {AParentID=_parentID,AName=string.IsNullOrWhiteSpace(_name) ? _name : ReplaceArabicWithPersianChars(_name),AComment=string.IsNullOrWhiteSpace(_comment) ? _comment : ReplaceArabicWithPersianChars(_comment),AStartPrice=_startPrice,AEndPrice=_endPrice,APageSize=_pageSize,APageIndex=_pageIndex} , timeout );
}

public ResultSet GetProducts(long? _parentID, string _name, string _comment, long? _startPrice, long? _endPrice, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	using(var cmd = GetCommand_GetProducts(_parentID, _name, _comment, _startPrice, _endPrice, _pageSize, _pageIndex, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region AddStock

public System.Data.SqlClient.SqlCommand GetCommand_AddStock(long? _id, Guid? _creatorID, string _guIDS, bool? _isEXECspIndexCountStock, int? timeout = null)
{
var cmd = base.CreateCommand("prd.spAddStock", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@ACreatorID", IsOutput = false, Value = _creatorID == null ? DBNull.Value : (object)_creatorID }, 
					new Parameter { Name = "@AGuIDS", IsOutput = false, Value = string.IsNullOrWhiteSpace(_guIDS) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_guIDS) }, 
					new Parameter { Name = "@AIsEXECspIndexCountStock", IsOutput = false, Value = _isEXECspIndexCountStock == null ? DBNull.Value : (object)_isEXECspIndexCountStock }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> AddStockAsync(long? _id, Guid? _creatorID, string _guIDS, bool? _isEXECspIndexCountStock, int? timeout = null)
{
	using(var cmd = GetCommand_AddStock(_id, _creatorID, _guIDS, _isEXECspIndexCountStock, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> AddStockDapperAsync<T>(long? _id, Guid? _creatorID, string _guIDS, bool? _isEXECspIndexCountStock, int? timeout = null)
{
	return await  DapperQueryAsync<T>("prd.spAddStock",new {AID=_id,ACreatorID=_creatorID,AGuIDS=string.IsNullOrWhiteSpace(_guIDS) ? _guIDS : ReplaceArabicWithPersianChars(_guIDS),AIsEXECspIndexCountStock=_isEXECspIndexCountStock} , timeout );
}

public ResultSet AddStock(long? _id, Guid? _creatorID, string _guIDS, bool? _isEXECspIndexCountStock, int? timeout = null)
{
	using(var cmd = GetCommand_AddStock(_id, _creatorID, _guIDS, _isEXECspIndexCountStock, timeout))
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

#region AddFlow

public System.Data.SqlClient.SqlCommand GetCommand_AddFlow(int? _documentID, byte? _toDocState, Guid? _toPositionID, byte? _sendType, string _comment, int? timeout = null)
{
var cmd = base.CreateCommand("pbl.spAddFlow", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@ADocumentID", IsOutput = false, Value = _documentID == null ? DBNull.Value : (object)_documentID }, 
					new Parameter { Name = "@AToDocState", IsOutput = false, Value = _toDocState == null ? DBNull.Value : (object)_toDocState }, 
					new Parameter { Name = "@AToPositionID", IsOutput = false, Value = _toPositionID == null ? DBNull.Value : (object)_toPositionID }, 
					new Parameter { Name = "@ASendType", IsOutput = false, Value = _sendType == null ? DBNull.Value : (object)_sendType }, 
					new Parameter { Name = "@AComment", IsOutput = false, Value = string.IsNullOrWhiteSpace(_comment) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_comment) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> AddFlowAsync(int? _documentID, byte? _toDocState, Guid? _toPositionID, byte? _sendType, string _comment, int? timeout = null)
{
	using(var cmd = GetCommand_AddFlow(_documentID, _toDocState, _toPositionID, _sendType, _comment, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> AddFlowDapperAsync<T>(int? _documentID, byte? _toDocState, Guid? _toPositionID, byte? _sendType, string _comment, int? timeout = null)
{
	return await  DapperQueryAsync<T>("pbl.spAddFlow",new {ADocumentID=_documentID,AToDocState=_toDocState,AToPositionID=_toPositionID,ASendType=_sendType,AComment=string.IsNullOrWhiteSpace(_comment) ? _comment : ReplaceArabicWithPersianChars(_comment)} , timeout );
}

public ResultSet AddFlow(int? _documentID, byte? _toDocState, Guid? _toPositionID, byte? _sendType, string _comment, int? timeout = null)
{
	using(var cmd = GetCommand_AddFlow(_documentID, _toDocState, _toPositionID, _sendType, _comment, timeout))
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

}

}

