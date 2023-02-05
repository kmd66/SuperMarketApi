USE [Kama.Sm]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('prd.spGetClassification'))
	DROP PROCEDURE prd.spGetClassification
GO

CREATE PROCEDURE prd.spGetClassification
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
		FROM prd.[Classification]
		WHERE [GuID] = @GuID
		AND  Removed = 0
	)
	SELECT
		MainSelect.ID, MainSelect.[GuID], MainSelect.[Name], MainSelect.Comment, MainSelect.NodeString,
		p.GuID ParentID,
		p.[Name] ParentName
	FROM MainSelect
	LEFT JOIN prd.[Classification] p on p.Node = MainSelect.Node.GetAncestor(1)


END