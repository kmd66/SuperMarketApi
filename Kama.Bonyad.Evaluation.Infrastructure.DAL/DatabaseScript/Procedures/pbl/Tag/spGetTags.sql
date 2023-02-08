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
		pblTag.TagID,
		pblTag.ProductID,
		[Tag] TagName
	FROM [pbl].[ProductTags] pblTag
	INNER JOIN [pbl].[Tags] tag on pblTag.TagID = tag.ID
	WHERE pblTag.ProductID = @ItemID
END

