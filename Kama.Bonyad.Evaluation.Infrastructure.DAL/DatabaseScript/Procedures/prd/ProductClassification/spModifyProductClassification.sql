USE [Kama.SuperMarket]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('prd.spModifyProductClassification'))
	DROP PROCEDURE prd.spModifyProductClassification
GO

CREATE PROCEDURE prd.spModifyProductClassification
	@AIsNewRecord BIT,
	@AGuID UNIQUEIDENTIFIER,
	@AParentID UNIQUEIDENTIFIER,
	@AName NVARCHAR(MAX),
	@AComment NVARCHAR(MAX)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE 
		@IsNewRecord BIT = ISNULL(@AIsNewRecord, 0),
		@GuID  UNIQUEIDENTIFIER = @AGuID ,
		@ParentID UNIQUEIDENTIFIER = @AParentID,
		@Name NVARCHAR(MAX) = TRIM(@AName),
		@Comment NVARCHAR(MAX) = TRIM(@AComment),
		@ParentNode HIERARCHYID = 0x,
		@ParentNodeLevel INT = 1,
		@LastChildNode HIERARCHYID,
		@NewNode HIERARCHYID


	BEGIN TRY
		BEGIN TRAN

		IF @ParentID IS NOT NULL
		BEGIN
			SET @ParentNode = COALESCE((SELECT TOP 1 [Node] FROM prd.ProductClassification WHERE [GuID] = @ParentID AND Removed = 0), 0x)
			SET @ParentNodeLevel = COALESCE((SELECT TOP 1 [Node].GetLevel() + 1 FROM prd.ProductClassification WHERE [GuID] = @ParentID AND Removed = 0), 1)
		END

		IF @IsNewRecord = 1 -- insert
		BEGIN
	
			SET @LastChildNode = (
				SELECT MAX([Node]) FROM prd.ProductClassification 
					where [Node].GetLevel() = @ParentNodeLevel
					AND ([Node].IsDescendantOf(@ParentNode) = 1)
			)
			SET @NewNode = @ParentNode.GetDescendant(@LastChildNode, NULL)
			
			INSERT INTO prd.ProductClassification
				([GuID], [Node], [Name], Comment)
			VALUES
				(@GuID, @NewNode, @Name, @Comment)
		END
		ELSE
		BEGIN -- update
			UPDATE prd.ProductClassification
			SET [Name] = @Name, Comment = @Comment
			WHERE [GuID] = @GuID 

		END

		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH
	
END