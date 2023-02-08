USE [Kama.Sm]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('pbl.spDeleteTag'))
	DROP PROCEDURE pbl.spDeleteTag
GO

CREATE PROCEDURE pbl.spDeleteTag
	@ATagID INT,
	@AItemID BIGINT
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE @TagID INT = @ATagID,
		@ItemID BIGINT = @AItemID
		
	DELETE [pbl].[ProductTags] WHERE TagID = @TagID AND ProductID = @ItemID

END