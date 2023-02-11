USE [Kama.Sm]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('prd.spAddFlow'))
	DROP PROCEDURE prd.spAddFlow
GO

CREATE PROCEDURE prd.spAddFlow
	@ADocumentID BIGINT,
	@ADepoID BIGINT,
	@AToPositionID UNIQUEIDENTIFIER,
	@AToState TINYINT,
	@ASendType TINYINT,
	@AComment NVARCHAR(255)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;
	
	DECLARE 
		@DocumentID INT = @ADocumentID,
		@DepoID INT = @ADepoID,
		@ToState TINYINT =  COALESCE(@AToState, 0),
		@ToPositionID UNIQUEIDENTIFIER =  @AToPositionID,
		@SendType TINYINT =  COALESCE(@ASendType, 0),
		@Comment NVARCHAR(4000) =  LTRIM(RTRIM(@AComment)),
		@FromPositionID UNIQUEIDENTIFIER ,
		@FromState TINYINT ,
		@Date DATETIME = GETDATE()

	BEGIN TRY
		BEGIN TRAN
			SET @FromPositionID =(SELECT TOP 1 ToPositionID FROM prd.Flow WHERE DocumentID = @DocumentID ORDER BY DATE DESC)
			SET @FromState =(SELECT TOP 1 ToState FROM prd.Flow WHERE DocumentID = @DocumentID ORDER BY DATE DESC)

			UPDATE prd.[Flow]
			SET ActionDate = @Date
			WHERE DocumentID = @DocumentID AND ActionDate IS NULL

			INSERT INTO prd.[Flow] ([DocumentID], [DepoID], [Date], [FromPositionID], [FromState], [ToPositionID], [ToState], [SendType], [Comment])
			VALUES(@DocumentID, @DepoID, @Date, @FromPositionID, @FromState, @ToPositionID, @ToState, @SendType, @Comment)


		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH

END
