USE [Kama.Sm]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('prd.spGetDocument'))
	DROP PROCEDURE prd.spGetDocument
GO

CREATE PROCEDURE prd.spGetDocument
	@AID BIGINT
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;
	
	DECLARE
		@ID BIGINT = @AID 
	
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
		prd.ToPositionID,
		COALESCE(pos.FirstName,'') + ' '+COALESCE(pos.LastName,' ')  FromPositionName
	FROM prd._Product prd
	LEFT JOIN org._position pos ON Pos.ID = prd.ToPositionID
	WHERE prd.[ID] = @ID

END