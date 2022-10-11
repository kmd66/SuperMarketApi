USE [Kama.SuperMarket]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.fnJalaliToGregorian') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION dbo.fnJalaliToGregorian
GO

CREATE FUNCTION dbo.fnJalaliToGregorian (@AJalaliDate VARCHAR(10))
RETURNS NVARCHAR(11)
AS
BEGIN
	Declare 
		@Year int = LEFT(@AJalaliDate, 4),
		@Month int = LEFT(RIGHT(@AJalaliDate, 5), 2),
		@Day int = LEFT(RIGHT(@AJalaliDate, 2), 2),
		@Jofst as Numeric(18,2),
		@PERSIAN_EPOCH INT, 
		@epbase BIGINT, 
		@epyear BIGINT, 
		@mdays BIGINT, 
		@joulianDate BIGINT

    Set @PERSIAN_EPOCH = 1948321
	Set @Jofst = 2415020.5

	If @Year>=0 
		Begin
			Set @epbase = @Year - 474 
		End
	Else
		Begin
			Set @epbase = @Year - 473 
		End
		set @epyear=474 + (@epbase%2820) 
	If @Month<=7
		Begin
			Set @mdays=(Convert(bigint, (@Month) - 1) * 31)
		End
	Else
		Begin
			Set @mdays=(Convert(bigint, (@Month) - 1) * 30+6)
		End
	Set @joulianDate =Convert(int, @Day) + @mdays+ Cast(((@epyear * 682) - 110) / 2816 as int)  + (@epyear - 1) * 365 + Cast(@epbase / 2820 as int) * 1029983 + (@PERSIAN_EPOCH - 1) 
		
    Return Convert(nvarchar(11),Convert(datetime,(@joulianDate - @Jofst),113),110)

End