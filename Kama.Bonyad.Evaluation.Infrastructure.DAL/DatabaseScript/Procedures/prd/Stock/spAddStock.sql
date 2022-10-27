USE [Kama.Sm]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('prd.spAddStock'))
	DROP PROCEDURE prd.spAddStock
GO

CREATE PROCEDURE prd.spAddStock
	@AID BIGINT,
	@ACreatorID UNIQUEIDENTIFIER,
	@AGuIDS NVARCHAR(MAX),
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
		@IsEXECspIndexCountStock BIT = @AIsEXECspIndexCountStock,
		@Date DATETIME = GETDATE(),
		@LastID  BIGINT

	BEGIN TRY
		BEGIN TRAN
	
		SET @LastID =(SELECT MAX(ID) FROM prd.Document)
		INSERT INTO [prd].[Document](GuID, Type, CreatorID, CreationDate)
		SELECT 
			VALUE, @ID, @CreatorID, @Date
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