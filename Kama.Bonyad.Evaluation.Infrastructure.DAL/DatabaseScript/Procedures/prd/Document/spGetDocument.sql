USE [Kama.Sm]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('prd.spGetDocument'))
	DROP PROCEDURE prd.spGetDocument
GO

CREATE PROCEDURE prd.spGetDocument
	@AType BIGINT
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;
	
	DECLARE
		@Type BIGINT = @AType 
	
	
	SELECT 
		count(doc.ID) Count,
		doc.Type, 
		doc.CreatorID, 
		doc.CreationDate,
		COALESCE(FrPos.FirstName,'')+ ' '+COALESCE(FrPos.LastName,' ')  FromPositionName
	FROM prd.Document doc
	INNER JOIN prd.Flow flw ON flw.DocumentID = doc.ID AND flw.ActionDate IS NULL
		AND flw.FromState = 1 AND flw.ToState = 1
	LEFT JOIN org._Position FrPos ON flw.ToPositionID = FrPos.ID
	WHERE doc.Type =@Type
	GROUP BY 
		doc.Type, 
		doc.CreatorID, 
		doc.CreationDate,
		FrPos.FirstName,
		FrPos.LastName

END