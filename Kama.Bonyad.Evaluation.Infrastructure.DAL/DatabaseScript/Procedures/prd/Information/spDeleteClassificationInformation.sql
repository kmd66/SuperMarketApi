USE [Kama.Sm]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('prd.spDeleteClassificationInformation'))
	DROP PROCEDURE prd.spDeleteClassificationInformation
GO

CREATE PROCEDURE prd.spDeleteClassificationInformation
	@AClassificationID BIGINT,
	@AInformationID BIGINT
WITH ENCRYPTION
AS
BEGIN
	
	DECLARE 
		@ClassificationID BIGINT = @AClassificationID,
		@InformationID BIGINT = @AInformationID
	
	DELETE prd.ClassificationInformation WHERE @ClassificationID =ClassificationID  AND InformationID = @InformationID
END

