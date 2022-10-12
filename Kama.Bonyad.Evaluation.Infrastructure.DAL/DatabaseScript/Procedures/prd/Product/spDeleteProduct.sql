USE [Kama.Sm]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('prd.spDeleteProduct'))
	DROP PROCEDURE prd.spDeleteProduct
GO

CREATE PROCEDURE prd.spDeleteProduct
	@AID BIGINT
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE @ID BIGINT= @AID
		
	UPDATE prd.Product SET Removed = 1 WHERE ID =@ID 

END