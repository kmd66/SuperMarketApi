USE [Kama.Sm]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('pbl.spGetAttachments'))
	DROP PROCEDURE pbl.spGetAttachments
GO

CREATE PROCEDURE pbl.spGetAttachments
	@AParentIDs NVARCHAR(MAX)
WITH ENCRYPTION--, RECOMPILE
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE 
		@ParentIDs NVARCHAR(MAX) = TRIM(@AParentIDs)

	;WITH ParentIDs AS
	(
		SELECT value ID
		FROM OPENJSON(@ParentIDs)
	)
	SELECT 
		attch.ID,
		attch.[GuID],
		attch.ParentID,
		attch.[Type],
		attch.[FileName],
		attch.Comment,
		[Url]
	FROM pbl.Attachment attch
		INNER JOIN ParentIDs ON ParentIDs.ID = attch.ParentID
	WHERE Removed = 0
	ORDER BY CreateDate

END