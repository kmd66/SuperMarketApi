USE [Kama.Sm]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('prd.spDeleteClassification'))
	DROP PROCEDURE prd.spDeleteClassification
GO

CREATE PROCEDURE prd.spDeleteClassification
	@AGuID UNIQUEIDENTIFIER
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE @GuID UNIQUEIDENTIFIER = @AGuID
		
	UPDATE prd.[Classification] SET Removed = 1 WHERE [GuID] = @GuID 

END