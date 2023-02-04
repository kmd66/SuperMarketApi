USE [Kama.Sm]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('prd.spAddInformation'))
	DROP PROCEDURE prd.spAddInformation
GO

CREATE PROCEDURE prd.spAddInformation
	@AText NVARCHAR(MAX)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE 
		@Text NVARCHAR(MAX) = TRIM(@AText),
		@SelectID  BIGINT 


	BEGIN TRY

		SET @SelectID = (SELECT ID FROM PRD.Information WHERE [Text] = @Text)
		IF @SelectID IS NULL
		BEGIN
			INSERT [prd].Information([Text])
			VALUES (@Text)
		END

	END TRY
	BEGIN CATCH
		;THROW
	END CATCH
	
END