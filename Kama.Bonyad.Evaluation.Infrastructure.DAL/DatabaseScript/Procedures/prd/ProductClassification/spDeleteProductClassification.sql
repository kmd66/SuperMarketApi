USE [Kama.Sm]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('prd.spDeleteProductClassification'))
	DROP PROCEDURE prd.spDeleteProductClassification
GO

CREATE PROCEDURE prd.spDeleteProductClassification
	@AGuID UNIQUEIDENTIFIER
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE @GuID UNIQUEIDENTIFIER = @AGuID
		
	UPDATE prd.ProductClassification SET Removed = 1 WHERE [GuID] =@GuID 

END