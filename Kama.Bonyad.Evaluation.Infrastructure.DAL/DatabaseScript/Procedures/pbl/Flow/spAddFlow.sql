USE [Kama.SuperMarket]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('pbl.spAddFlow'))
	DROP PROCEDURE pbl.spAddFlow
GO

CREATE PROCEDURE pbl.spAddFlow
	@ADocumentID INT,
	@AToDocState TINYINT,
	@AToPositionID UNIQUEIDENTIFIER,
	@ASendType TINYINT,
	@AComment NVARCHAR(4000)


WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;
	
	DECLARE 
		@ID INT,
		@DocumentID INT = @ADocumentID,
		@ToDocState TINYINT =  COALESCE(@AToDocState, 0),
		@ToPositionID UNIQUEIDENTIFIER =  @AToPositionID,
		@SendType TINYINT =  COALESCE(@ASendType, 0),
		@Comment NVARCHAR(4000) =  LTRIM(RTRIM(@AComment)),
		@FromPositionID UNIQUEIDENTIFIER ,
		@FromUserID UNIQUEIDENTIFIER ,
		@FromDocState TINYINT ,
		@CurrentDate DATETIME = GETDATE(),
		@ToUserID UNIQUEIDENTIFIER

	BEGIN TRY
		BEGIN TRAN
			SET @ID = (SELECT COALESCE (MAX(ID), 0) + 1 FROM pbl.[DocumentFlow])

			SET @ToUserID =(SELECT UserID FROM ORG._Position WHERE @ToPositionID IS NOT NULL AND ID = @ToPositionID)
			SET @FromPositionID =(SELECT TOP 1 ToPositionID FROM PBL.DocumentFlow WHERE DocumentID = @DocumentID ORDER BY DATE DESC)
			SET @FromUserID =(SELECT UserID FROM ORG._Position WHERE @FromPositionID IS NOT NULL AND ID = @FromPositionID)
			SET @FromDocState =(SELECT TOP 1 ToDocState FROM PBL.DocumentFlow WHERE DocumentID = @DocumentID ORDER BY DATE DESC)

			UPDATE [pbl].[DocumentFlow]
			SET ActionDate = @CurrentDate
			WHERE DocumentID = @DocumentID AND ActionDate IS NULL

			INSERT INTO [pbl].[DocumentFlow] (ID, [DocumentID], [Date], [FromPositionID], [FromUserID], [FromDocState], [ToPositionID], [ToUserID], [ToDocState], [SendType], [Comment], [ReadDate], [IsRead], [ActionDate])
			VALUES(@ID, @DocumentID, @CurrentDate, @FromPositionID, @FromUserID, @FromDocState, @ToPositionID, @ToUserID, @ToDocState, @SendType, @Comment, 0, 0, null)


		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH

	RETURN @@ROWCOUNT
END
