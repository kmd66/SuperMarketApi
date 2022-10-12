USE [Kama.Sm]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('prd.spGetProductClassification'))
	DROP PROCEDURE prd.spGetProductClassification
GO

CREATE PROCEDURE prd.spGetProductClassification
	@AGuID UNIQUEIDENTIFIER
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE @GuID UNIQUEIDENTIFIER = @AGuID
	
	;WITH MainSelect AS
	(
		SELECT 
			ID, [GuID], [Node], [Name], Comment,
			[Node].ToString() NodeString
		FROM prd.ProductClassification	
		WHERE [GuID] = @GuID
		AND  Removed = 0
	)
	SELECT
		MainSelect.ID, MainSelect.[GuID], MainSelect.[Name], MainSelect.Comment, MainSelect.NodeString,
		p.GuID ParentID,
		p.[Name] ParentName
	FROM MainSelect
	LEFT JOIN prd.ProductClassification p on p.Node = MainSelect.Node.GetAncestor(1)


END