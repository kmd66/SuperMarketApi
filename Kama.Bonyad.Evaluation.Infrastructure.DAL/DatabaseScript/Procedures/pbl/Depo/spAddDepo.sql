USE [Kama.Sm]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('pbl.spAddDepo'))
	DROP PROCEDURE pbl.spAddDepo
GO

CREATE PROCEDURE pbl.spAddDepo
	@AGuID UNIQUEIDENTIFIER,
	@AItemID BIGINT,
	@ANumber INT,
	@APriceBuy BIGINT,
	@APriceSale BIGINT,
	@AType TINYINT,
	@AComment NVARCHAR(MAX)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE 
		@GuID  UNIQUEIDENTIFIER = @AGuID,
		@ItemID BIGINT = @AItemID,
		@Number INT = @ANumber,
		@PriceBuy BIGINT = @APriceBuy,
		@PriceSale BIGINT = @APriceSale,
		@Type TINYINT = @AType,
		@Comment NVARCHAR(MAX) = TRIM(@AComment)

		
	BEGIN TRY
		BEGIN TRAN

		INSERT INTO pbl.Depo
				([GuID], [ItemID], [Number], [PriceBuy], [PriceSale], [Type], [Comment], [CreateDate])
		VALUES
			(@GuID, @ItemID, @Number, @PriceBuy, @PriceSale, @Type, @Comment, GETDATE())

		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH
	
END