USE [Kama.Sm]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('prd.spAddStock'))
	DROP PROCEDURE prd.spAddStock
GO

CREATE PROCEDURE prd.spAddStock
	@AID BIGINT,
	@ACreatorID UNIQUEIDENTIFIER,
	@AGuIDS NVARCHAR(MAX),
	@AExpired DATETIME,
	@AIsEXECspIndexCountStock BIT
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;
	
	DECLARE 
		@ID  BIGINT = @AID ,
		@CreatorID  UNIQUEIDENTIFIER = @ACreatorID ,
		@GuIDS NVARCHAR(MAX) = TRIM(@AGuIDS),
		@Expired DATETIME = @AExpired,
		@IsEXECspIndexCountStock BIT = @AIsEXECspIndexCountStock,
		@Date DATETIME = GETDATE()

	BEGIN TRY
		BEGIN TRAN
	
		INSERT INTO [prd].[Document](GuID, Type, CreatorID, CreationDate,Expired)
		SELECT 
			VALUE, @ID, @CreatorID, @Date, @Expired
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