USE [Kama.SuperMarket]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('prd.spGetProducts'))
	DROP PROCEDURE prd.spGetProducts
GO

CREATE PROCEDURE prd.spGetProducts
	@AParentID BIGINT,
	@AName NVARCHAR(MAX),
	@AComment NVARCHAR(MAX),
	@AStartPrice BIGINT,
	@AEndPrice BIGINT,
	@APageSize INT,
	@APageIndex INT
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;
	
	DECLARE 
		@ParentID BIGINT = @AParentID,
		@Name NVARCHAR(MAX) = TRIM(@AName),
		@Comment NVARCHAR(MAX) = TRIM(@AComment),
		@StartPrice BIGINT = @AStartPrice,
		@EndPrice BIGINT = @AEndPrice,
		@PageSize INT = @APageSize,
		@PageIndex INT = @APageIndex
	
	IF @PageSize = 0
	BEGIN
		SET @PageSize = 1000
		SET @PageIndex = 1
	END
	
	SELECT *
	FROM prd._Product
	WHERE (@ParentID = 0 OR ParentID = @ParentID)
		AND(@Name IS NULL OR [Name] LIKE '%' + @Name + '%')
		AND(@Comment IS NULL OR Comment LIKE '%' + @Comment + '%')
		AND (@StartPrice = 0 OR Price >= @StartPrice)
		AND (@EndPrice = 0 OR Price <= @EndPrice)
	ORDER BY CreateDate
	OFFSET ((@PageIndex - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY

END