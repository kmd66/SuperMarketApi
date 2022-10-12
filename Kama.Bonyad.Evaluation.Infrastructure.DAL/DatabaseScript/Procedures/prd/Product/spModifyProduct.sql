USE [Kama.Sm]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('prd.spModifyProduct'))
	DROP PROCEDURE prd.spModifyProduct
GO

CREATE PROCEDURE prd.spModifyProduct
	@AIsNewRecord BIT,
	@AID BIGINT,
	@AGuID UNIQUEIDENTIFIER,
	@AParentID BIGINT,
	@AName NVARCHAR(MAX),
	@AComment NVARCHAR(MAX),
	@APrice BIGINT,
	@ADiscount BIGINT,
	@AInformation NVARCHAR(MAX)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE 
		@IsNewRecord BIT = ISNULL(@AIsNewRecord, 0),
		@ID  BIGINT = @AID ,
		@GuID  UNIQUEIDENTIFIER = @AGuID ,
		@ParentID BIGINT = @AParentID,
		@Name NVARCHAR(MAX) = TRIM(@AName),
		@Comment NVARCHAR(MAX) = TRIM(@AComment),
		@Price BIGINT = @APrice,
		@Discount BIGINT = @ADiscount,
		@Information NVARCHAR(MAX) = TRIM(@AInformation)

	BEGIN TRY
		BEGIN TRAN

		IF @IsNewRecord = 1 -- insert
		BEGIN
			INSERT INTO prd.Product
				([GuID], ParentID, [Name], Comment, Price, Discount, Information, CreateDate)
			VALUES
				(@AGuID, @ParentID, @Name, @Comment, @Price, @Discount, @Information, GETDATE())
		END
		ELSE
		BEGIN -- update
			UPDATE prd.Product
			SET ParentID=@ParentID,[Name] = @Name, Comment = @Comment, Price = @Price, Discount = @Discount, Information = @AInformation
			WHERE ID = @ID

		END

		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH
	
END