﻿USE [Kama.Sm]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('pbl.spGetBrand'))
	DROP PROCEDURE pbl.spGetBrand
GO

CREATE PROCEDURE pbl.spGetBrand
	@AID BIGINT,
	@AGuID UNIQUEIDENTIFIER
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE @ID BIGINT= @AID,
		@GuID UNIQUEIDENTIFIER = @AGuID
	
	
	SELECT 
		brand.*
		, parent.Name ParentName
	FROM pbl.Brand brand
	INNER JOIN [prd].[ProductClassification] parent
		ON brand.ParentID = parent.ID
	WHERE (@ID <> 0 AND brand.[ID] = @ID)
		OR (@GuID IS NOT NULL AND brand.[GuID] = @GuID)

END