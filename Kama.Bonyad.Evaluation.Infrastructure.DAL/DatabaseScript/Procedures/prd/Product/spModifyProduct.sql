USE [Kama.Sm]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('prd.spModifyProduct'))
	DROP PROCEDURE prd.spModifyProduct
GO

CREATE PROCEDURE prd.spModifyProduct
	@AIsNewRecord BIT,
	@AID BIGINT,
	@AGuID UNIQUEIDENTIFIER,
	@AClassificationID BIGINT,
	@ABrandID BIGINT,
	@AFaName NVARCHAR(MAX),
	@AEnName NVARCHAR(MAX),
	@AInformation NVARCHAR(MAX)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE 
		@IsNewRecord BIT = ISNULL(@AIsNewRecord, 0),
		@ID  BIGINT = @AID ,
		@GuID  UNIQUEIDENTIFIER = @AGuID ,
		@ClassificationID BIGINT = @AClassificationID,
		@BrandID BIGINT = @ABrandID,
		@FaName NVARCHAR(MAX) = TRIM(@AFaName),
		@EnName NVARCHAR(MAX) = TRIM(@AEnName),
		@Information NVARCHAR(MAX) = TRIM(@AInformation)

	BEGIN TRY
		BEGIN TRAN

		IF @IsNewRecord = 1 -- insert
		BEGIN
			INSERT INTO prd.Product
				([GuID], [FaName], [EnName], [ClassificationID], [BrandID], [CreateDate], [Information])
			VALUES
				(@AGuID, @FaName, @EnName, @ClassificationID, @BrandID, GETDATE(), @Information)
		END
		ELSE
		BEGIN -- update
			UPDATE prd.Product
			SET [FaName] = @FaName, EnName = @EnName, Information = @Information
			WHERE ID = @ID

		END

		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH
	
END