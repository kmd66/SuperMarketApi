USE [Kama.Sm]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.fnGetFirstDateOfJalaliMonth') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION dbo.fnGetFirstDateOfJalaliMonth
GO

CREATE FUNCTION dbo.fnGetFirstDateOfJalaliMonth (@AYear SMALLINT, @AMonth TINYINT)
RETURNS SMALLDATETIME
AS
BEGIN
	Declare 
		@Year SMALLINT = LTRIM(RTRIM(@AYear)),
		@Month TINYINT= COALESCE(@AMonth, 0),
		@JalaliDate VARCHAR(10)
		
	SET @JalaliDate = CAST(@Year AS VARCHAR(4))  
	IF @Month < 10
		SET @JalaliDate = @JalaliDate + + '/0' + CAST(@Month AS VARCHAR(2)) + '/01'
	ELSE
		SET @JalaliDate = @JalaliDate + + '/' + CAST(@Month AS VARCHAR(2)) + '/01'
	
	RETURN dbo.fnJalaliToGregorian(@JalaliDate)
End