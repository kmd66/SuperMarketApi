USE [Kama.Sm]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('pbl.spGetDepo'))
	DROP PROCEDURE pbl.spGetDepo
GO

CREATE PROCEDURE pbl.spGetDepo
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
		dep.[ID], 
		dep.[GuID], 
		dep.[ItemID], 
		dep.[Number], 
		dep.[PriceBuy], 
		dep.[PriceSale], 
		dep.[Type], 
		dep.[Comment], 
		dep.[CreateDate],
		itm.FaName FaName,
		itm.EnName EnName
	FROM pbl.Depo dep
	INNER JOIN prd.Item itm ON itm.ID = dep.ItemID
	WHERE  (@ID <> 0 AND dep.[ID] = @ID)
		OR (@GuID IS NOT NULL AND dep.[GuID] = @GuID)

END