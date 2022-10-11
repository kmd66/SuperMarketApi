﻿USE [Kama.SuperMarket]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('prd.spDeleteDocument'))
	DROP PROCEDURE prd.spDeleteDocument
GO

CREATE PROCEDURE prd.spDeleteDocument
	@AID BIGINT,
	@AUserID  UNIQUEIDENTIFIER
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE @ID BIGINT= @AID,
		@UserID  UNIQUEIDENTIFIER = @AUserID  
	UPDATE prd.Document SET RemoverUserID = @AUserID, RemoveDate= GETDATE() WHERE ID =@ID 

END