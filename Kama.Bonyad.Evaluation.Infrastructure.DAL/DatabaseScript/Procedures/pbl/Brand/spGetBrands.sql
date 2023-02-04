USE [Kama.Sm]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('pbl.spGetBrands'))
	DROP PROCEDURE pbl.spGetBrands
GO

CREATE PROCEDURE pbl.spGetBrands
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
		Count(brand.ID) OVER() Total,
		brand.*
	FROM pbl.Brand brand
	WHERE (@FaName IS NULL OR brand.FaName LIKE '%' + @FaName + '%')
		AND (@EnName IS NULL OR brand.ENName LIKE '%' + @EnName + '%')
	ORDER BY ID DESC
	OFFSET ((@PageIndex - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY

END