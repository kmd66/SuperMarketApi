USE [Kama.SuperMarket]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'prd.fnGetLastOpinionByPositionType') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION prd.fnGetLastOpinionByPositionType
GO

CREATE FUNCTION prd.fnGetLastOpinionByPositionType (@ACollectionID UNIQUEIDENTIFIER,@AUserPositionType TINYINT)
RETURNS TINYINT 
WITH ENCRYPTION
AS
BEGIN

	DECLARE @CollectionID UNIQUEIDENTIFIER = @ACollectionID
			, @UserPositionType INT = COALESCE(@AUserPositionType, 0)
			, @Result TINYINT

	SET @Result = (SELECT TOP(1) MagistrateOpinionType FROM prdOpinions
				   WHERE CollectionID = @CollectionID
				   AND UserPositionType = @UserPositionType
				   ORDER BY [Date], ID DESC)

	RETURN @Result
END