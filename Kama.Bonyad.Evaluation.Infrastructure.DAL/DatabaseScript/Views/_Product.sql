USE [Kama.Sm]
GO

IF EXISTS(SELECT 1 FROM sys.views WHERE [object_id] = OBJECT_ID('prd._Product'))
	DROP VIEW prd._Product
GO

CREATE VIEW prd._Product
WITH ENCRYPTION, SCHEMABINDING
AS
	SELECT 
		doc.[ID], 
		doc.[ItemID], 
		doc.[StorageID],
		doc.[SaleID],
		doc.[OrderID],
		doc.[LastState],
		doc.[Expired],
		doc.CreatorID, 
		doc.CreationDate,
		itm.FaName FaName,
		itm.EnName EnName,
		cals.ID ClassificationID,
		cals.[Name] ClassificationName,
		brnd.ID brandID,
		brnd.[FaName] brandName,
		flw.ToPositionID
	FROM prd.Document doc
	INNER JOIN prd.Flow flw ON flw.DocumentID = doc.ID AND flw.ActionDate IS NULL
	--INNER JOIN org._Position toPo ON toPo.ID = flw.ToPositionID
	INNER JOIN prd.Item itm ON itm.ID = doc.ItemID
	INNER JOIN prd.[Classification] cals On cals.ID = itm.ClassificationID
	INNER JOIN pbl.Brand brnd ON brnd.ID = itm.BrandID
	WHERE itm.Removed = 0
			AND  cals.Removed = 0
			AND  brnd.Removed = 0
