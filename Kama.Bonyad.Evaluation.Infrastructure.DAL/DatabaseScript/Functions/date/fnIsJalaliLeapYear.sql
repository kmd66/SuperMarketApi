USE [Kama.SuperMarket]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.fnIsJalaliLeapYear') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION dbo.fnIsJalaliLeapYear
GO

CREATE FUNCTION dbo.fnIsJalaliLeapYear( @Year int )
RETURNS bit
AS
 
BEGIN
 
    DECLARE @B int,
            @isLeap bit
 
    SET @B = @Year % 33
 
    IF @B IN (1, 5, 9, 13, 17, 22, 26, 30)
        SET @isLeap = 1
    ELSE
        SET @isLeap = 0
     
    RETURN @isLeap
 
END