USE [Kama.Sm]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.fnGetLastDateOfJalaliMonth') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION dbo.fnGetLastDateOfJalaliMonth
GO

CREATE FUNCTION dbo.fnGetLastDateOfJalaliMonth (@AYear SMALLINT, @AMonth TINYINT)
RETURNS SMALLDATETIME
AS
BEGIN
	Declare 
		@Year SMALLINT = LTRIM(RTRIM(@AYear)),
		@Month TINYINT= COALESCE(@AMonth, 0),
		@JalaliDate VARCHAR(10),
		@Date SMALLDATETIME
		
	SET @JalaliDate = CAST(@Year AS VARCHAR(4))  
	IF @Month < 10
		SET @JalaliDate = @JalaliDate + '/0' + CAST(@Month AS VARCHAR(2))
	ELSE
		SET @JalaliDate = @JalaliDate + '/' + CAST(@Month AS VARCHAR(2))

	IF @Month < 7
		SET @JalaliDate = @JalaliDate + '/31'
	ELSE IF @Month < 12 OR dbo.fnIsJalaliLeapYear(@Year) = 1
		SET @JalaliDate = @JalaliDate + '/30'
	ELSE
		SET @JalaliDate = @JalaliDate + '/29'

	SET @Date = dbo.fnJalaliToGregorian(@JalaliDate)
	SET @Date = @Date + '23:58:59'

	RETURN @Date
End