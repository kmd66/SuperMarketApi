USE [Kama.Sm]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('prd.spGetDocuments'))
	DROP PROCEDURE prd.spGetDocuments
GO

CREATE PROCEDURE prd.spGetDocuments
	@AItemID BIGINT,
	@AStorageID BIGINT,
	@ASaleID BIGINT,
	@AOrderID BIGINT,
	@ALastState TINYINT,
	@APageSize INT,
	@APageIndex INT
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;
	
	DECLARE 
		@ItemID BIGINT = @AItemID,
		@StorageID BIGINT = @AStorageID,
		@SaleID BIGINT = @ASaleID,
		@OrderID BIGINT = @AOrderID,
		@LastState TINYINT = @ALastState,
		@PageSize INT = @APageSize,
		@PageIndex INT = @APageIndex
	
	IF @PageSize = 0
	BEGIN
		SET @PageSize = 1000
		SET @PageIndex = 1
	END
	
	SELECT 
		prd.[ID], 
		prd.[ItemID], 
		prd.[StorageID],
		prd.[SaleID],
		prd.[OrderID],
		prd.[LastState],
		prd.[Expired],
		prd.CreatorID, 
		prd.CreationDate,
		prd.FaName,
		prd.EnName,
		prd.ClassificationID,
		prd.ClassificationName,
		prd.brandID,
		prd.brandName,
		prd.ToPositionID
	FROM prd._Product prd
	LEFT JOIN org._position pos ON Pos.ID = prd.ToPositionID
	WHERE (@ItemID = 0 OR ItemID = ItemID)
		AND(@StorageID = 0 OR StorageID = @StorageID)
		AND(@SaleID = 0 OR SaleID = @SaleID)
		AND(@OrderID = 0 OR OrderID = @OrderID)
		AND(@LastState = 0 OR LastState = @LastState)
	ORDER BY CreationDate
	OFFSET ((@PageIndex - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY

END