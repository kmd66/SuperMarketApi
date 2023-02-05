USE [Kama.Sm]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('prd.spGetClassificationInformations'))
	DROP PROCEDURE prd.spGetClassificationInformations
GO

CREATE PROCEDURE prd.spGetClassificationInformations
	@AClassificationID BIGINT
WITH ENCRYPTION
AS
BEGIN
	
	DECLARE @ClassificationID BIGINT = @AClassificationID
	
	SELECT 
		Count(ClassificationID) OVER() Total,
		clsf.ClassificationID,
		clsf.InformationID,
		info.[Text]
	FROM [prd].[ClassificationInformation] clsf
	INNER JOIN [prd].[Information] info ON clsf.InformationID = info.ID
	WHERE clsf.ClassificationID = @ClassificationID 
END

