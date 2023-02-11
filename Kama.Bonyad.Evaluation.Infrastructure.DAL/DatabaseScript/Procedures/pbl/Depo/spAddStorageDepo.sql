USE [Kama.Sm]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('pbl.spAddStorageDepo'))
	DROP PROCEDURE pbl.spAddStorageDepo
GO

CREATE PROCEDURE pbl.spAddStorageDepo
	@AGuID UNIQUEIDENTIFIER,
	@ADocumentGuID NVARCHAR(MAX),
	@AItemID BIGINT,
	@ANumber INT,
	@APriceBuy BIGINT,
	@AComment NVARCHAR(MAX),
	@ACreatorID UNIQUEIDENTIFIER,
	@AExpired DATETIME
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE 
		@GuID  UNIQUEIDENTIFIER = @AGuID,
		@DocumentGuID NVARCHAR(MAX) = TRIM(@ADocumentGuID),
		@ItemID BIGINT = @AItemID,
		@Number INT = @ANumber,
		@PriceBuy BIGINT = @APriceBuy,
		@Comment NVARCHAR(MAX) = TRIM(@AComment),
		@CreatorID  UNIQUEIDENTIFIER = @ACreatorID,
		@Expired DATETIME = @AExpired,
		@ID BIGINT,
		@Date DATETIME = GETDATE()

		
	BEGIN TRY
		BEGIN TRAN

		INSERT INTO pbl.Depo
				([GuID], [ItemID], [Number], [PriceBuy], [PriceSale], [Type], [Comment], [CreateDate])
		VALUES
			(@GuID, @ItemID, @Number, @PriceBuy, 0, 1, @Comment, @Date)
		
		SET @ID =(SELECT TOP 1 ID FROM pbl.Depo WHERE [GuID] = @GuID)
		
		INSERT INTO [prd].[Document]([GuID], [ItemID], [StorageID], [SaleID], [OrderID], [LastState], [Expired], [CreatorID], [CreationDate])
		SELECT 
			VALUE, @ItemID, @ID, 0, 0, 1, @Expired, @CreatorID, @Date
		FROM  OPENJSON(@DocumentGuID)
		
		INSERT INTO [prd].[Flow]([DocumentID], [DepoID], [Date], [FromPositionID], [FromState], [ToPositionID], [ToState], [SendType], [Comment], [ReadDate], [ActionDate])
		SELECT 
			doc.[ID], @ID, @Date, @CreatorID, 1, 0x, 1, 1, null, null, null
		FROM  OPENJSON(@DocumentGuID) ids
		INNER JOIN [prd].[Document] doc ON ids.VALUE = doc.[GuID]

		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH
	
END