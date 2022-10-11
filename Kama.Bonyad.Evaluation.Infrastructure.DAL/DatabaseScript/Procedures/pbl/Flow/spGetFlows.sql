USE [Kama.SuperMarket]
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
		    ,flow.[FromUserID]
		    ,flow.[FromDocState]
		    ,flow.[ToPositionID]
		    ,flow.[ToUserID]
		    ,flow.[ToDocState]
		    ,flow.[SendType]
		    ,flow.[Comment]
		    ,flow.[ReadDate]
		    ,flow.[IsRead]
		    ,flow.[ActionDate]
			,COALESCE(toUser.FirstName, '') + ' ' + COALESCE(toUser.LastName, '') ToUserFullName
			,COALESCE(fromUser.FirstName, '') + ' ' + COALESCE(fromUser.LastName, '') FromUserFullName
			,toPosition.[Type] ToUserPositionType
			,fromPosition.[Type] FromUserPositionType
		FROM [pbl].[DocumentFlow] flow
		LEFT JOIN org.Users fromUser ON fromUser.ID = flow.FromUserID
		LEFT JOIN org._Position fromPosition ON fromPosition.ID = flow.FromPositionID
		LEFT JOIN org.Users toUser ON toUser.ID = flow.ToUserID
		LEFT JOIN org._Position toPosition ON toPosition.ID = flow.ToPositionID
		WHERE flow.[DocumentID] = @DocumentID
	)
	,Total AS
	(
		SELECT COUNT(*) AS Total FROM MainSelect
	)
	SELECT * FROM MainSelect,Total
	ORDER BY [Date]

END
