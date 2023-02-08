USE [Kama.Sm]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('pbl.spAddTag'))
	DROP PROCEDURE pbl.spAddTag
GO

CREATE PROCEDURE pbl.spAddTag
	@AItemID BIGINT,
	@ATag NVARCHAR(MAX)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE 
		@ItemID BIGINT = @AItemID ,
		@Tag NVARCHAR(MAX) = TRIM(@ATag),
		@TAGID  INT ,
		@SelectID  BIGINT 


	BEGIN TRY
		BEGIN TRAN
		SET @TAGID  =(SELECT TOP 1 ID FROM [pbl].[Tags] WHERE Tag  = @Tag)
		
		IF @TAGID IS NULL 
		BEGIN
			INSERT [pbl].[Tags] (Tag) VALUES (@Tag)
			SET @TAGID  =(SELECT TOP 1 ID FROM [pbl].[Tags] WHERE Tag  = @Tag)
		END

		SET @SelectID  =(SELECT TOP 1 TAGID FROM [pbl].[ProductTags] WHERE TagID = @TAGID AND ProductID = @ItemID)
		
		IF @SelectID IS NULL 
		BEGIN
			INSERT [pbl].[ProductTags](TagID, ProductID)
			VALUES (@TagID, @ItemID)
		END

		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH
	
END