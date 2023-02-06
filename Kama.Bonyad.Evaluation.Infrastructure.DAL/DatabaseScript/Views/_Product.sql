USE [Kama.Sm]
GO

IF EXISTS(SELECT 1 FROM sys.views WHERE [object_id] = OBJECT_ID('prd._Product'))
	DROP VIEW prd._Product
GO

CREATE VIEW prd._Product
WITH ENCRYPTION, SCHEMABINDING
AS
	
	SELECT 
			prod.ID, 
			prod.GuID, 
			prod.FaName, 
			prod.EnName, 
			prod.Information,
			prod.CreateDate,
			cals.GuID ClassificationGuID,
			cals.ID ClassificationID,
			cals.Name ClassificationName,
			brnd.ID BrandID,
			brnd.GuID BrandGuID,
			brnd.FaName BrandFaName,
			brnd.EnName BrandEnName
		FROM prd.Product prod
		INNER JOIN [prd].[Classification] cals ON cals.ID = prod.ClassificationID
		INNER JOIN [pbl].[Brand] brnd ON brnd.ID = prod.BrandID
		WHERE prod.Removed = 0
			AND  cals.Removed = 0
			AND  brnd.Removed = 0