USE [Kama.Sm]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'prd.fnNewClassNumber') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION prd.fnNewClassNumber
GO

CREATE FUNCTION prd.fnNewClassNumber()
RETURNS VARCHAR(10)
WITH ENCRYPTION
AS
BEGIN

	DECLARE @MaxRealUser INT = COALESCE(CAST((SELECT MAX(ClassNumber) FROM usr.RealUsers) AS INT), 40000)
			,@MaxLegalUser INT = COALESCE(CAST((SELECT MAX(ClassNumber) FROM usr.LegalUsers) AS INT), 40000)
			,@MaxDeceased INT = COALESCE(CAST((SELECT MAX(ClassNumber) FROM req.Deceaseds) AS INT), 40000)
			,@Result INT
			
	SET @Result = (SELECT MAX(VALUE) 
					FROM (SELECT @MaxRealUser AS VALUE UNION 
						SELECT @MaxLegalUser AS VALUE  UNION 
						SELECT @MaxDeceased AS VALUE) AS T1) 
					+ 1

	RETURN CAST(@Result AS VARCHAR(10))
END

