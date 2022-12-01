USE [Kama.Sm]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('prd.spStockChangeState'))
	DROP PROCEDURE prd.spStockChangeState
GO

CREATE PROCEDURE prd.spStockChangeState
	@AID BIGINT,
	@AFromPositionID UNIQUEIDENTIFIER,
	@AState TINYINT
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;
	
	BEGIN TRY
	
	DECLARE 
		@ID BIGINT = @AID ,
		@FromPositionID UNIQUEIDENTIFIER = @AFromPositionID ,
		@State TINYINT =@AState

	DECLARE @PrdDocument TABLE (ID BIGINT)
	DECLARE @Date DATETIME = GETDATE()
	
	INSERT INTO @PrdDocument
	SELECT DISTINCT doc.ID  FROM prd.Document doc
	INNER JOIN prd.Flow flw ON flw.DocumentID = doc.ID 
		AND flw.ToState = 220 
		AND flw.ActionDate IS NULL
	WHERE doc.Type = @ID
	
	UPDATE flw 
		SET ActionDate = @Date
	FROM @PrdDocument doc
	INNER JOIN prd.Flow flw ON flw.DocumentID = doc.ID 
		AND flw.ActionDate IS NULL
		
			
	INSERT INTO [prd].Flow (DocumentID, Date, FromPositionID, FromState, ToPositionID, ToState, SendType)
	SELECT ID,  @Date, @FromPositionID, 1, 0X, @State, 1
	FROM @PrdDocument doc

	EXEC prd.spIndexCountStock


	END TRY
	BEGIN CATCH
		;THROW
	END CATCH
	
END