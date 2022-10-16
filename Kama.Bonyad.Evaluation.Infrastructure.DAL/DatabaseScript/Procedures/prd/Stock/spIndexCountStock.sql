USE [Kama.Sm]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('prd.spIndexCountStock'))
	DROP PROCEDURE prd.spIndexCountStock
GO

CREATE PROCEDURE prd.spIndexCountStock
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	BEGIN TRY
		BEGIN TRAN
		
		DELETE prd.IndexCountStock
		INSERT INTO prd.IndexCountStock
		SELECT 
			Count(doc.ID) Count,
			prd.ID, 
			prd.[Name] , 
			prd.ClassificationID ,
			prd.ClassificationName,
			doc.CreatorID, 
			doc.CreationDate [Date],
			FrPos.ID FrPosID,
			COALESCE(FrPos.FirstName,'')+ ' '+COALESCE(FrPos.LastName,' ')  FromPositionName,
			ToPos.ID ToPosID,
			COALESCE(ToPos.FirstName,'')+ ' '+COALESCE(ToPos.LastName,' ')  ToPositionName
		FROM prd._Product prd
		LEFt JOIN prd.Document doc ON prd.ID = doc.Type 
		LEFt JOIN prd.Flow flw ON flw.DocumentID = doc.ID AND flw.ActionDate IS NULL
			AND flw.FromState = 1 AND flw.ToState = 1
		LEFT JOIN org._Position FrPos ON flw.ToPositionID = FrPos.ID
		LEFT JOIN org._Position ToPos ON flw.ToPositionID = ToPos.ID
		WHERE doc.RemoveDate IS NULL
		GROUP BY 
			prd.ID, 
			prd.[Name] , 
			prd.ClassificationID,
			prd.ClassificationName,
			doc.CreatorID, 
			doc.CreationDate,
			FrPos.ID,
			FrPos.FirstName,
			FrPos.LastName,
			ToPos.ID,
			ToPos.FirstName,
			ToPos.LastName

		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH
	
END