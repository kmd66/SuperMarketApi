USE [Kama.Sm]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('pbl.spDeleteAttachment'))
	DROP PROCEDURE pbl.spDeleteAttachment
GO

CREATE PROCEDURE pbl.spDeleteAttachment
	@AID BIGINT
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE @ID BIGINT = @AID
				
	IF @ID IS NULL
		RETURN -2 -- شناسه اپلیکیشن نامعتبر است

	BEGIN TRY
		BEGIN TRAN
		UPDATE pbl.Attachment
		SET Removed = 1
			WHERE ID = @ID

		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH
	
END