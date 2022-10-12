USE [Kama.Sm]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('prd.spGetDocument'))
	DROP PROCEDURE prd.spGetDocument
GO

CREATE PROCEDURE prd.spGetDocument
	@AID BIGINT,
	@AFromPositionID UNIQUEIDENTIFIER,
	@AToPositionID UNIQUEIDENTIFIER,
	@AState TINYINT,
	@AGuID UNIQUEIDENTIFIER,
	@AGuID UNIQUEIDENTIFIER
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE @ID BIGINT= @AID,
		@GuID UNIQUEIDENTIFIER = @AGuID
	
	
	SELECT 
		doc.ID, 
		doc.GuID, 
		doc.Type, 
		doc.OrderID, 
		doc.CreatorID, 
		doc.CreationDate,
		flw.ToState [State] ,
		FrPos.ID FromPositionID,
		COALESCE(FrPos.FirstName,'')+COALESCE(FrPos.LastName,' ')  FromPositionName,
		ToPos.ID ToPositionID,
		COALESCE(ToPos.FirstName,'')+COALESCE(ToPos.LastName,' ') ToPositionName 
	FROM prd.Document doc
	INNER JOIN prd.Flow flw ON flw.DocumentID = doc.ID AND flw.ActionDate IS NULL
	LEFT JOIN org._Position FrPos ON flw.ToPositionID = FrPos.ID
	LEFT JOIN org._Position ToPos ON flw.FromPositionID = ToPos.ID
	WHERE RemoveDate IS NULL
		AND(
			(doc.[ID] <> 0 AND doc.[ID] = @ID) OR ([GuID] IS NOT NULL AND [GuID] = @GuID)
		)

END