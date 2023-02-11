USE [Kama.Sm]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('pbl.spGetDepos'))
	DROP PROCEDURE pbl.spGetDepos
GO

CREATE PROCEDURE pbl.spGetDepos
	@AItemID BIGINT,
	@AType TINYINT,
	@AComment NVARCHAR(MAX),
	@APageSize INT,
	@APageIndex INT
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;
	
	DECLARE 
		@ItemID BIGINT = @AItemID,
		@Type TINYINT= @AType,
		@Comment NVARCHAR(MAX) = TRIM(@AComment),
		@PageSize INT = COALESCE(@APageSize, 0),
		@PageIndex INT = COALESCE(@APageIndex, 0)
	
	IF @PageSize = 0
	BEGIN
		SET @PageSize = 1000
		SET @PageIndex = 1
	END
	
	SELECT 
		dep.[ID], 
		dep.[GuID], 
		dep.[ItemID], 
		dep.[Number], 
		dep.[PriceBuy], 
		dep.[PriceSale], 
		dep.[Type], 
		dep.[Comment], 
		dep.[CreateDate],
		itm.FaName FaName,
		itm.EnName EnName
	FROM pbl.Depo dep
	INNER JOIN prd.Item itm ON itm.ID = dep.ItemID
	WHERE dep.Removed = 0 
		AND itm.Removed = 0 
		AND (@ItemID = 0 OR ItemID = @ItemID)
		AND (@Type = 0 OR [Type] = @Type)
		AND(@Comment IS NULL OR Comment LIKE '%' + @Comment + '%')
	ORDER BY [CreateDate] DESC
	OFFSET ((@PageIndex - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY

END