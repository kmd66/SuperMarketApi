﻿--USE [Kama.Sm]
--GO

--IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('prd.spGetProduct'))
--	DROP PROCEDURE prd.spGetProduct
--GO

--CREATE PROCEDURE prd.spGetProduct
--	@AID BIGINT,
--	@AGuID UNIQUEIDENTIFIER
--WITH ENCRYPTION
--AS
--BEGIN
--	SET NOCOUNT ON;
--	SET XACT_ABORT ON;

--	DECLARE @ID BIGINT= @AID,
--		@GuID UNIQUEIDENTIFIER = @AGuID
	
	
--	SELECT *
--	FROM prd._Product
--	WHERE (@ID <> 0 AND [ID] = @ID)
--		OR (@GuID IS NOT NULL AND [GuID] = @GuID)

--END