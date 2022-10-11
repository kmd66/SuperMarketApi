USE [Kama.SuperMarket]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('prd.spDeleteTag'))
	DROP PROCEDURE prd.spDeleteTag
GO

CREATE PROCEDURE prd.spDeleteTag
	@ATagID INT,
	@AProductID BIGINT
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE @TagID INT = @ATagID,
		@ProductID BIGINT = @AProductID
		
	DELETE [prd].[ProductTags] WHERE TagID = @TagID AND ProductID = @AProductID

END