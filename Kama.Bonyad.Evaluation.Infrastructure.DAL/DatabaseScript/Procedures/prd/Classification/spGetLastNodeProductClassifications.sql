USE [Kama.Sm]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('prd.spGetProductClassifications'))
	DROP PROCEDURE prd.spGetProductClassifications
GO

CREATE PROCEDURE prd.spGetProductClassifications
	@AParentID UNIQUEIDENTIFIER,
	@AName NVARCHAR(MAX),
	@AComment NVARCHAR(MAX),
	@APageSize INT,
	@APageIndex INT
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;
	
	DECLARE 
		@ParentID UNIQUEIDENTIFIER = @AParentID,
		@Name NVARCHAR(MAX) = TRIM(@AName),
		@Comment NVARCHAR(MAX) = TRIM(@AComment),
		@PageSize INT = COALESCE(@APageSize,1000),
		@PageIndex INT = COALESCE(@APageIndex, 1),
		@ParentNode HIERARCHYID,
		@RootLevel int
	
	
	
	
	IF @ParentID IS NOT NULL
	BEGIN
		SELECT @ParentNode = [Node], @RootLevel= [Node].GetLevel()
		FROM prd.ProductClassification	
		WHERE [GuID] =@ParentID
	END
	
	;WITH MainSelect AS
	(
		SELECT 
			Count(ID) OVER() Total,
			ID, [GuID], [Node], [Name], Comment,
			[Node].ToString() NodeString
		FROM prd.ProductClassification	
		WHERE Removed = 0
			AND(@Name IS NULL OR [Name] LIKE '%' + @Name + '%')
			AND(@Comment IS NULL OR Comment LIKE '%' + @Comment + '%')
			AND(@ParentNode IS NULL OR [Node].IsDescendantOf(@ParentNode) = 1)
			AND  [Node].GetDescendant(null, null) NOT IN (SELECT [Node] FROM  prd.ProductClassification) 
			AND [Node].GetLevel() <> 1
	)
	SELECT
		MainSelect.Total, MainSelect.ID, MainSelect.[GuID], MainSelect.[Name], MainSelect.Comment, MainSelect.NodeString, 
		p.GuID ParentID,
		p.[Name] ParentName
	FROM MainSelect
	LEFT JOIN prd.ProductClassification p on p.Node = MainSelect.Node.GetAncestor(1)
	ORDER BY MainSelect.[Node]
	OFFSET ((@PageIndex - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY;

END


		
--DECLARE @root hierarchyID;
--DECLARE @rootLevel int;
--SELECT @root = [Node], @rootLevel= [Node].GetLevel()
--FROM [org].[Department]
--where id ='B7D27FE8-DD6D-4CFF-ABB4-AA20EFA008CE'

--SELECT @root,@root.GetAncestor(0)
--,*
--, [Node].ToString()
--, [Node].GetLevel()
--FROM [org].[Department]
--WHERE [Node].IsDescendantOf(@root) = 1
--and [Node].GetLevel()= @rootLevel +1
--order by [Node]

--SELECT *
--, [Node].ToString()
--, [Node].GetLevel()
--FROM [org].[Department]
--where [Node].GetLevel() = 1
--order by [Node]

--SELECT [Node].ToString() FROM org.Department
--where id ='562F5BDF-D657-44ED-B4B1-720DF20F681C'

--	DECLARE 
--		@ParentNode HIERARCHYID = 0x,
--		@LastChildNode HIERARCHYID,
--		@NewNode HIERARCHYID
--		SET @LastChildNode = ( SELECT MAX([Node]) FROM org.Department
--			where [Node].GetLevel() = 1)
--		SET @NewNode = @ParentNode.GetDescendant(@LastChildNode, NULL)
--		select @NewNode,@NewNode.ToString()
