USE [Kama.Sm]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('prd.spGetInformations'))
	DROP PROCEDURE prd.spGetInformations
GO

CREATE PROCEDURE prd.spGetInformations
	@AText NVARCHAR(MAX),
	@APageSize INT,
	@APageIndex INT
WITH ENCRYPTION
AS
BEGIN
	
	DECLARE 
		@Text NVARCHAR(MAX) = TRIM(@AText),
		@PageSize INT = COALESCE(@APageSize,100),
		@PageIndex INT = COALESCE(@APageIndex, 1)
	
	SELECT 
		Count(ID) OVER() Total, 
		ID,
		[Text]
	FROM prd.Information 
	WHERE @Text IS NULL OR [Text] LIKE '%' + @Text + '%' 
	ORDER BY ID DESC
	OFFSET ((@PageIndex - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY;
END

