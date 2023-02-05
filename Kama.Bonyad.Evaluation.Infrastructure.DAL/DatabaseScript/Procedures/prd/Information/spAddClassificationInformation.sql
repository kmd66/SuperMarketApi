USE [Kama.Sm]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('prd.spAddClassificationInformation'))
	DROP PROCEDURE prd.spAddClassificationInformation
GO

CREATE PROCEDURE prd.spAddClassificationInformation
	@AClassificationID BIGINT,
	@AInformationID BIGINT
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE 
		@ClassificationID BIGINT = @AClassificationID,
		@InformationID BIGINT = @AInformationID,
		@ISClassificationInformation BIT,
		@IsClassification BIT,
		@IsInformation BIT

	BEGIN TRY
		
		SET @IsClassification = (SELECT TOP 1 1 FROM [prd].[Classification] WHERE ID =@ClassificationID)
		SET @IsInformation = (SELECT TOP 1 1 FROM [prd].[Information] WHERE ID =@InformationID)
		
		IF @IsClassification = 1 AND @IsInformation = 1
		BEGIN
			SET @ISClassificationInformation = (SELECT TOP 1 1 FROM [prd].[ClassificationInformation] WHERE [ClassificationID] =@ClassificationID AND [InformationID] = @InformationID)
			IF @ISClassificationInformation IS NULL
			BEGIN
				INSERT [prd].[ClassificationInformation]([ClassificationID], [InformationID])
				VALUES (@ClassificationID, @InformationID)
			END
		END

	END TRY
	BEGIN CATCH
		;THROW
	END CATCH
	
END