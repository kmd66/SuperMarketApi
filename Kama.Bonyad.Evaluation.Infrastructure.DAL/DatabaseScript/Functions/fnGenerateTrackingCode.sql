USE [Kama.SuperMarket]
GO

IF OBJECT_ID('prd.fnGenerateTrackingCode') IS NOT NULL
    DROP FUNCTION prd.fnGenerateTrackingCode
GO

CREATE FUNCTION prd.fnGenerateTrackingCode(@ACollectionID UNIQUEIDENTIFIER, @AFeed INT)
RETURNS NVARCHAR(100)
AS
BEGIN
	DECLARE 
		@CollectionID UNIQUEIDENTIFIER,
		@Feed INT = COALESCE(@AFeed, 0),
		@TrackingCode NVARCHAR(MAX),
		@DateToday NVARCHAR(MAX),
		@Count INT
	
	
	SET @Count = (SELECT COUNT(*)
		FROM (
			SELECT DISTINCT col.ID
			FROM cmp.ComplaintCollections as col
				inner join cmp.Complaints as comp on comp.CollectionID = col.ID
				inner join pbl.DocumentFlows as flow on flow.DocumentID = comp.ID
			WHERE CAST(flow.[Date] as DATE) = CAST(GETDATE() as DATE)
			AND flow.FromDocState = 1
			AND flow.ToDocState in (5, 150)
		)tbl
	)

	SET @DateToday = 	REVERSE(
		SUBSTRING(dbo.fnGregorianToJalali(GETDATE()),3,2)
		+ SUBSTRING(dbo.fnGregorianToJalali(GETDATE()),6,2)
		+ SUBSTRING(dbo.fnGregorianToJalali(GETDATE()),9,2)
	)
	SET @TrackingCode = 
	(SELECT
		@DateToday
		+ RIGHT(
			'0000' 
			+ RTRIM(
				CAST((@Count + 1000) AS varchar(10))
			)
		, 4)
		+ RIGHT('0' + RTRIM(1), 2)
	)
			
				
	IF EXISTS(SELECT TOP 1 1 FROM cmp.ComplaintCollections WHERE TrackingCode = @TrackingCode)
	BEGIN
		SET @TrackingCode = (SELECT Top 1 TrackingCode FROM cmp.ComplaintCollections 
			WHERE TrackingCode  LIKE @DateToday + '%' ORDER BY TrackingCode DESC)
		
		SET @TrackingCode = @DateToday
			+RIGHT('000000'+ RTRIM(  
				(CAST(SUBSTRING(@TrackingCode, 7, 12) AS BIGINT) + 10)
			), 6)
	END
		
	RETURN @TrackingCode
END