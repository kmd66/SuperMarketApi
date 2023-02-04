USE [Kama.Sm]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('prd.spSaleInPerson'))
	DROP PROCEDURE prd.spSaleInPerson
GO

CREATE PROCEDURE prd.spSaleInPerson
	@ACreatorID UNIQUEIDENTIFIER,
	@AModel NVARCHAR(MAX),
	@AIsEXECspIndexCountStock BIT
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;
	
	DECLARE 
		@CreatorID  UNIQUEIDENTIFIER = @ACreatorID ,
		@IsEXECspIndexCountStock BIT = @AIsEXECspIndexCountStock,
		@Model NVARCHAR(MAX) = TRIM(@AModel),
		@Count INT = 0,
		@Date DATETIME = GETDATE()

	BEGIN TRY
		BEGIN TRAN
	
		DECLARE @TABLEJSON TABLE([Count] INT, ID BIGINT)


		INSERT INTO @TABLEJSON
		SELECT * FROM OPENJSON(@GuIDS)
		WITH ([Count] INT, ID BIGINT)

		SET @Count = (
			SELECT COUNT(stock.ID) from @TABLEJSON t
			INNER JOIN [prd].[IndexCountStock] stock ON t.ID = stock.ID
			WHERE t.[Count] > stock.[Count]
		)

		IF @Count > 0
			THROW 50000, N'اجناس در انبار کمتر از میزان تایین شده است', 1

		INSERT INTO [prd].[Document](GuID, Type, CreatorID, CreationDate,Expired)
		SELECT VALUE, @ID, @CreatorID, @Date, @Expired
		FROM OPENJSON(@GuIDS)

		
		INSERT INTO [prd].Flow (DocumentID, Date, FromPositionID, FromState, ToPositionID, ToState, SendType)
		SELECT 
			ID, @Date, @CreatorID, 1, @CreatorID, 1, 1
		FROM OPENJSON(@GuIDS) jsn
		INNER JOIN [prd].[Document] doc ON doc.GuID = jsn.VALUE

		IF @IsEXECspIndexCountStock = 1
		BEGIN
			EXEC prd.spIndexCountStock
		END


		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH
	
END