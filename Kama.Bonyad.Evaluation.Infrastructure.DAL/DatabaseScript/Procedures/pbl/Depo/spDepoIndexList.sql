USE [Kama.Sm]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('pbl.spDepoIndexList'))
	DROP PROCEDURE pbl.spDepoIndexList
GO

CREATE PROCEDURE pbl.spDepoIndexList
	@AItemID BIGINT,
	@AType TINYINT,
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
		@PageSize INT = COALESCE(@APageSize, 0),
		@PageIndex INT = COALESCE(@APageIndex, 0)
	
	IF @PageSize = 0
	BEGIN
		SET @PageSize = 1000
		SET @PageIndex = 1
	END
	
	SELECT 
		[ItemID], 
		[FaName], 
		[Number], 
		[NumberEnter], 
		[NumberLeave], 
		[LastPriceBuy], 
		[AveragePriceBuy], 
		[LastPriceSale], 
		[AverageLastPriceSale], 
		[Type]
	FROM pbl.DepoIndex
	WHERE (@ItemID = 0 OR ItemID = @ItemID)
		AND (@Type = 0 OR [Type] = @Type)
	ORDER BY [FaName]
	OFFSET ((@PageIndex - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY

END