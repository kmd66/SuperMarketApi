USE [Kama.Sm]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('prd.spGetStocks'))
	DROP PROCEDURE prd.spGetStocks
GO

CREATE PROCEDURE prd.spGetStocks
	@AID BIGINT,
	@AName NVARCHAR(MAX),
	@AClassificationID BIGINT,
	@APageSize INT,
	@APageIndex INT
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;
	
	DECLARE 
		@ID BIGINT = @AID ,
		@ClassificationID BIGINT = @AClassificationID,
		@Name NVARCHAR(MAX) = TRIM(@AName),
		@PageSize INT = @APageSize,
		@PageIndex INT = @APageIndex

		
	;WITH MainSelect AS
	(
		SELECT 
			SUM([Count]) Count,
			ID, 
			[Name] , 
			ClassificationName
		FROM [prd].[IndexCountStock]
		WHERE (@ID = 0 OR ID = @ID)
			AND (@ClassificationID = 0 OR  ClassificationID = @ClassificationID)
			AND (@Name IS NULL OR  [Name] LIKE '%' + @Name + '%')
		GROUP BY 
			ID, 
			[Name] , 
			ClassificationName
	)
	SELECT 
		Count(ID) OVER() Total,
		MainSelect.*
	FROM MainSelect
	ORDER BY Name
	OFFSET ((@PageIndex - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY


END