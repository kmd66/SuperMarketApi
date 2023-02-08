USE [Kama.Sm]
GO

IF EXISTS(SELECT 1 FROM sys.views WHERE [object_id] = OBJECT_ID('prd._Item'))
	DROP VIEW prd._Item
GO

CREATE VIEW prd._Item
WITH ENCRYPTION, SCHEMABINDING
AS
	
	SELECT 
			item.ID, 
			item.GuID, 
			item.FaName, 
			item.EnName, 
			item.Information,
			item.CreateDate,
			cals.GuID ClassificationGuID,
			cals.ID ClassificationID,
			cals.Name ClassificationName,
			brnd.ID BrandID,
			brnd.GuID BrandGuID,
			brnd.FaName BrandFaName,
			brnd.EnName BrandEnName
		FROM prd.Item item
		INNER JOIN [prd].[Classification] cals ON cals.ID = item.ClassificationID
		INNER JOIN [pbl].[Brand] brnd ON brnd.ID = item.BrandID
		WHERE item.Removed = 0
			AND  cals.Removed = 0
			AND  brnd.Removed = 0