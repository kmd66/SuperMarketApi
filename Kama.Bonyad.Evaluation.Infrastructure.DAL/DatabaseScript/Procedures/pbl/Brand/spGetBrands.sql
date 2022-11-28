USE [Kama.Sm]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('pbl.spGetBrands'))
	DROP PROCEDURE pbl.spGetBrands
GO

CREATE PROCEDURE pbl.spGetBrands
	@AParentID BIGINT,
	@AName NVARCHAR(MAX),
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
		@PageSize INT = COALESCE(@APageSize, 0),
		@PageIndex INT = COALESCE(@APageIndex, 0)
	
	IF @PageSize = 0
	BEGIN
		SET @PageSize = 100000
		SET @PageIndex = 1
	END
	
	SELECT
		Count(brand.ID) OVER() Total, brand.*
		, parent.Name ParentName
	FROM pbl.Brand brand
	INNER JOIN [prd].[ProductClassification] parent
		ON brand.ParentID = parent.ID
	WHERE (@ParentID = 0 OR brand.ParentID = @ParentID)
		AND(@Name IS NULL OR brand.[Name] LIKE '%' + @Name + '%')
	ORDER BY ID DESC
	OFFSET ((@PageIndex - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY

END