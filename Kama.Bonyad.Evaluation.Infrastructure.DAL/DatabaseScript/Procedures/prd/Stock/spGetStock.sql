USE [Kama.Sm]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('prd.spGetStock'))
	DROP PROCEDURE prd.spGetStock
GO

CREATE PROCEDURE prd.spGetStock
	@AID BIGINT
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;
	
	DECLARE
		@ID BIGINT = @AID 

	SELECT 
		Count,
		ID, 
		CreatorID, 
		[Date],
		FromPositionName
	FROM PRD.IndexCountStock
	WHERE ID = @ID 
	ORDER BY [Date] DESC

END