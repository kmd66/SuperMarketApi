USE [Kama.Sm]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('prd.spAddDocument'))
	DROP PROCEDURE prd.spAddDocument
GO

CREATE PROCEDURE prd.spAddDocument
	@AGuID UNIQUEIDENTIFIER,
	@AItemID BIGINT,
	@AStorageID BIGINT,
	@ASaleID BIGINT,
	@AOrderID BIGINT,
	@ALastState TINYINT,
	@AExpired DATETIME,
	@ACreatorID UNIQUEIDENTIFIER
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE 
		@GuID  UNIQUEIDENTIFIER = @AGuID,
		@ItemID BIGINT = @AItemID,
		@StorageID BIGINT = @AStorageID,
		@SaleID BIGINT = @ASaleID,
		@OrderID BIGINT = @AOrderID,
		@LastState TINYINT = @ALastState,
		@Expired DATETIME = @AExpired,
		@CreatorID UNIQUEIDENTIFIER = @ACreatorID

		
	BEGIN TRY
		BEGIN TRAN

		INSERT INTO [prd].[Document]
				([GuID], [ItemID], [StorageID], [SaleID], [OrderID], [LastState], [Expired], [CreatorID], [CreationDate])
			VALUES
				(@GuID, @ItemID, @StorageID, @SaleID, @OrderID, @LastState, @Expired, @CreatorID, GETDATE())

		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH
	
END