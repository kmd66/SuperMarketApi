USE [Kama.Sm]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('pbl.spGetTags'))
	DROP PROCEDURE pbl.spGetTags
GO

CREATE PROCEDURE pbl.spGetTags
	@AItemID BIGINT
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;
	
	DECLARE 
		@ItemID BIGINT = @AItemID
	
	SELECT 
		itemTag.TagID,
		itemTag.itemID,
		[Tag] TagName
	FROM prd.[itemTags] itemTag
	INNER JOIN [pbl].[Tags] tag on itemTag.TagID = tag.ID
	WHERE itemTag.itemID = @ItemID
END

