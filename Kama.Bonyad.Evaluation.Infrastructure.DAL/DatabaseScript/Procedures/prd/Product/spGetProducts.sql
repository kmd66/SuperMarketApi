USE [Kama.Sm]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('prd.spGetProducts'))
	DROP PROCEDURE prd.spGetProducts
GO

CREATE PROCEDURE prd.spGetProducts
	@AClassificationID BIGINT,
	@ABrandID BIGINT,
	@AFaName NVARCHAR(MAX),
	@AEnName NVARCHAR(MAX),
	@APageSize INT,
	@APageIndex INT
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;
	
	DECLARE 
		@ClassificationID BIGINT = @AClassificationID,
		@BrandID BIGINT = @ABrandID,
		@FaName NVARCHAR(MAX) = TRIM(@AFaName),
		@EnName NVARCHAR(MAX) = TRIM(@AEnName),
		@PageSize INT = COALESCE(@APageSize, 0),
		@PageIndex INT = COALESCE(@APageIndex, 0)
	
	IF @PageSize = 0
	BEGIN
		SET @PageSize = 100000
		SET @PageIndex = 1
	END
	
	SELECT
		Count(ID) OVER() Total, *
	FROM prd._Product
	WHERE (@ClassificationID = 0 OR ClassificationID = @ClassificationID)
		AND(@BrandID  = 0 OR BrandID = @BrandID)
		AND(@FaName IS NULL OR FaName LIKE '%' + @FaName + '%')
		AND(@EnName IS NULL OR EnName LIKE '%' + @EnName + '%')
	ORDER BY CreateDate DESC
	OFFSET ((@PageIndex - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY

END