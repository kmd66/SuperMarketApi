USE [Kama.Sm]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('prd.spGetStocksMinimumToAlert'))
	DROP PROCEDURE prd.spGetStocksMinimumToAlert
GO

CREATE PROCEDURE prd.spGetStocksMinimumToAlert
	@AID BIGINT,
	@AName NVARCHAR(MAX),
	@AClassificationID BIGINT,
	@AActionState TINYINT,
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
		@ActionState TINYINT =@AActionState,
		@PageSize INT = @APageSize,
		@PageIndex INT = @APageIndex,
		@Date DATETIME = GETDATE()

		
	;WITH StockSelect AS
	(
		SELECT 
			SUM([Count]) Count,
			MIN(Expired) Expired,
			ID, 
			[Name] , 
			ClassificationName
		FROM [prd].[IndexCountStock]
		WHERE State = 1
			AND (@ID = 0 OR ID = @ID)
			AND (@ClassificationID = 0 OR  ClassificationID = @ClassificationID)
			AND (@Name IS NULL OR  [Name] LIKE '%' + @Name + '%')
		GROUP BY 
			ID, 
			[Name] , 
			ClassificationName
	)
	,MainSelect AS
	(
		SELECT 
			stock.*
		FROM StockSelect stock
		INNER JOIN prd.Product prd
			ON prd.ID = stock.ID
		WHERE (@ActionState = 2 AND prd.MinimumToAlert IS NOT NULL AND prd.MinimumToAlert > [Count])
			OR (@ActionState = 4 AND prd.ExpiredToAlert IS NOT NULL AND DATEADD(DAY, prd.ExpiredToAlert, @Date) > Expired)
	)
	SELECT 
		Count(ID) OVER() Total,
		MainSelect.*
	FROM MainSelect
	ORDER BY Name
	OFFSET ((@PageIndex - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY


END