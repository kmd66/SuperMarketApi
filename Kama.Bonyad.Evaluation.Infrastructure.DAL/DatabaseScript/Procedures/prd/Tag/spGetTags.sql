USE [Kama.Sm]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('prd.spGetTags'))
	DROP PROCEDURE prd.spGetTags
GO

CREATE PROCEDURE prd.spGetTags
	@AProductID BIGINT
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;
	
	DECLARE 
		@ProductID BIGINT = @AProductID
	
	SELECT 
		prdTag.TagID,
		prdTag.ProductID,
		[Tag] TagName
	FROM [prd].[ProductTags] prdTag
	INNER JOIN [prd].[Tags] tag on prdTag.TagID = tag.ID
	WHERE prdTag.ProductID = @ProductID
END

