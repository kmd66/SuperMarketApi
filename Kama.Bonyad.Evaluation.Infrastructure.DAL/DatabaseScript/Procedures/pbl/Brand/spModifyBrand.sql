USE [Kama.Sm]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('pbl.spModifyBrand'))
	DROP PROCEDURE pbl.spModifyBrand
GO

CREATE PROCEDURE pbl.spModifyBrand
	@AIsNewRecord BIT,
	@AID BIGINT,
	@AGuID UNIQUEIDENTIFIER,
	@AFaName NVARCHAR(MAX),
	@AEnName NVARCHAR(MAX)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE 
		@IsNewRecord BIT = ISNULL(@AIsNewRecord, 0),
		@ID  BIGINT = @AID ,
		@GuID  UNIQUEIDENTIFIER = @AGuID ,
		@FaName NVARCHAR(MAX) = TRIM(@AFaName),
		@EnName NVARCHAR(MAX) = TRIM(@AEnName)

	BEGIN TRY
		BEGIN TRAN

		IF @IsNewRecord = 1 -- insert
		BEGIN
			INSERT INTO pbl.Brand
				([GuID], FaName, EnName)
			VALUES
				(@AGuID, @FaName, @EnName)
		END
		ELSE
		BEGIN -- update
			UPDATE pbl.Brand
			SET FaName = @FaName,  EnName = @EnName
			WHERE ID = @ID

		END

		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH
	
END