USE [Kama.Sm]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('prd.spReturnExpiredState'))
	DROP PROCEDURE prd.spReturnExpiredState
GO

CREATE PROCEDURE prd.spReturnExpiredState
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;
	
	BEGIN TRY
		DECLARE @PrdDocument TABLE (ID BIGINT)
		DECLARE @Date DATETIME = GETDATE()
		
		INSERT INTO @PrdDocument
		SELECT DISTINCT doc.ID  FROM prd.Document doc
		INNER JOIN prd.Flow flw ON flw.DocumentID = doc.ID 
			AND flw.ToState = 1 
			AND flw.ActionDate IS NULL
		WHERE  Expired < @Date
		
		UPDATE flw 
			SET ActionDate = @Date
		FROM @PrdDocument doc
		INNER JOIN prd.Flow flw ON flw.DocumentID = doc.ID 
			AND flw.ActionDate IS NULL
			
				
		INSERT INTO [prd].Flow (DocumentID, Date, FromPositionID, FromState, ToPositionID, ToState, SendType)
		SELECT ID,  @Date, 0X, 1, 0X, 220, 250
		FROM @PrdDocument doc

		EXEC prd.spIndexCountStock
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH
	
END