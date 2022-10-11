USE [Kama.SuperMarket]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('pbl.spGetAttachment'))
	DROP PROCEDURE pbl.spGetAttachment
GO

CREATE PROCEDURE pbl.spGetAttachment
	@AID BIGINT
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE @ID BIGINT = @AID
		
	SELECT 
		ID, [GuID], ParentID, [Type], [FileName], Comment, [Url], CreateDate
	FROM pbl.Attachment		
	WHERE ID = @ID 
		AND Removed = 0

END