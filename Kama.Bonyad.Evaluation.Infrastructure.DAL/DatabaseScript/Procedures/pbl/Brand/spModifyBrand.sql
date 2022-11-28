USE [Kama.Sm]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('pbl.spModifyBrand'))
	DROP PROCEDURE pbl.spModifyBrand
GO

CREATE PROCEDURE pbl.spModifyBrand
	@AIsNewRecord BIT,
	@AID BIGINT,
	@AGuID UNIQUEIDENTIFIER,
	@AParentID BIGINT,
	@AName NVARCHAR(MAX)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE 
		@IsNewRecord BIT = ISNULL(@AIsNewRecord, 0),
		@ID  BIGINT = @AID ,
		@GuID  UNIQUEIDENTIFIER = @AGuID ,
		@ParentID BIGINT = @AParentID,
		@Name NVARCHAR(MAX) = TRIM(@AName)

	BEGIN TRY
		BEGIN TRAN

		IF @IsNewRecord = 1 -- insert
		BEGIN
			INSERT INTO pbl.Brand
				([GuID], ParentID, [Name])
			VALUES
				(@AGuID, @ParentID, @Name)
		END
		ELSE
		BEGIN -- update
			UPDATE pbl.Brand
			SET [Name] = @Name
			WHERE ID = @ID

		END

		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH
	
END