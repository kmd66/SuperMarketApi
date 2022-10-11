USE [Kama.SuperMarket]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'prd.fnGetLastMagistrateMinisterListType') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION prd.fnGetLastMagistrateMinisterListType
GO

CREATE FUNCTION prd.fnGetLastMagistrateMinisterListType (@ACollectionID UNIQUEIDENTIFIER)
RETURNS TINYINT 
WITH ENCRYPTION
AS
BEGIN

	DECLARE @CollectionID UNIQUEIDENTIFIER= @ACollectionID
			,@Result TINYINT

	SET @Result = (SELECT TOP(1) MinisterListType FROM prdOpinions
				   WHERE CollectionID = @CollectionID
				   AND MinisterListType = 3    -- نظر رئیس مرکز
				   ORDER BY [Date] DESC)

	RETURN COALESCE(@Result, 0)
END
