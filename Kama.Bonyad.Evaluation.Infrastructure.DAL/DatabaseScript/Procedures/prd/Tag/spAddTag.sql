USE [Kama.SuperMarket]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('prd.spAddTag'))
	DROP PROCEDURE prd.spAddTag
GO

CREATE PROCEDURE prd.spAddTag
	@AProductID BIGINT,
	@ATag NVARCHAR(MAX)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE 
		@ProductID  BIGINT = @AProductID ,
		@Tag NVARCHAR(MAX) = TRIM(@ATag),
		@TAGID  INT ,
		@SelectID  BIGINT 


	BEGIN TRY
		BEGIN TRAN
		SET @TAGID  =(SELECT TOP 1 ID FROM [prd].[Tags] WHERE Tag  = @Tag)
		
		IF @TAGID IS NULL 
		BEGIN
			INSERT [prd].[Tags] (Tag) VALUES (@Tag)
			SET @TAGID  =(SELECT TOP 1 ID FROM [prd].[Tags] WHERE Tag  = @Tag)
		END

		SET @SelectID  =(SELECT TOP 1 TAGID FROM [prd].[ProductTags] WHERE TagID = @TAGID AND ProductID = @ProductID)
		
		IF @SelectID IS NULL 
		BEGIN
			INSERT [prd].[ProductTags](TagID, ProductID)
			VALUES (@TagID, @ProductID)
		END

		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH
	
END