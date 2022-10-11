USE [Kama.SuperMarket]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('pbl.spModifyAttachment'))
	DROP PROCEDURE pbl.spModifyAttachment
GO

CREATE PROCEDURE pbl.spModifyAttachment
	@AIsNewRecord BIT,
	@AID BIGINT,
	@AParentID UNIQUEIDENTIFIER,
	@AType TINYINT,
	@AFileName NVARCHAR(MAX),
	@AComment NVARCHAR(MAX),
	@AUrL NVARCHAR(MAX)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE 
		@IsNewRecord BIT = ISNULL(@AIsNewRecord, 0),
		@ID BIGINT = @AID,
		@ParentID UNIQUEIDENTIFIER = @AParentID,
		@Type TINYINT = COALESCE(@AType, 0),
		@FileName NVARCHAR(MAX) = LTRIM(RTRIM(@AFileName)),
		@Comment NVARCHAR(MAX) = LTRIM(RTRIM(@AComment)),
		@UrL NVARCHAR(MAX) = @AUrL

	BEGIN TRY
		BEGIN TRAN
			
			IF @IsNewRecord = 1     -- insert
			BEGIN
			
				INSERT INTO pbl.Attachment
				([GuID], ParentID, [Type], [FileName], Comment, [Url], CreateDate)
				VALUES
				(NEWID(), @ParentID, @Type, @FileName, @Comment, @UrL, GETDATE())
				SET @ID = (SELECT MAX(ID) FROM  pbl.Attachment)
			END
			ELSE
			BEGIN
				SET @ParentID = (SELECT ParentID FROM pbl.Attachment  WHERE ID = @ID)

				UPDATE pbl.Attachment
				SET [FileName] = @FileName, [Url] = @UrL
				WHERE ID = @ID

			END

	EXEC pbl.spGetAttachment @AID = @ID

		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH
END