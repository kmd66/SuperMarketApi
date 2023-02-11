USE [Kama.Sm]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('pbl.spGetFlows'))
	DROP PROCEDURE pbl.spGetFlows
GO

CREATE PROCEDURE pbl.spGetFlows
	@ADocumentID INT
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE 
		@DocumentID INT = @ADocumentID
		
	;WITH MainSelect AS
	(
		SELECT TOP (1000) flow.[ID]
		    ,flow.[DocumentID]
		    ,flow.[Date]
		    ,flow.[FromPositionID]
		    ,flow.[ToPositionID]
		    ,flow.[SendType]
		    ,flow.[Comment]
		    ,flow.[ReadDate]
		    ,flow.[ActionDate]
			,COALESCE(frPo.FirstName, '') + ' ' + COALESCE(frPo.LastName, '') ToUserFullName
			,COALESCE(toPo.FirstName, '') + ' ' + COALESCE(toPo.LastName, '') FromUserFullName
			,frPo.[Type] ToUserPositionType
			,toPo.[Type] FromUserPositionType
		FROM prd.Flow flow
		LEFT JOIN org._Position frPo ON frPo.ID = flow.FromPositionID
		LEFT JOIN org._Position toPo ON toPo.ID = flow.ToPositionID
		WHERE flow.[DocumentID] = @DocumentID
	)
	,Total AS
	(
		SELECT COUNT(*) AS Total FROM MainSelect
	)
	SELECT * FROM MainSelect,Total
	ORDER BY [Date]

END
