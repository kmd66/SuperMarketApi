USE [Kama.Sm]
GO

IF EXISTS(SELECT 1 FROM sys.views WHERE [object_id] = OBJECT_ID('prd._Product'))
	DROP VIEW prd._Product
GO

CREATE VIEW prd._Product
WITH ENCRYPTION, SCHEMABINDING
AS
	
	SELECT 
			prd.ID, 
			prd.GuID, 
			prd.ParentID, 
			prd.Name, 
			prd.Comment, 
			prd.Price, 
			prd.Discount, 
			prd.Information,
			prd.CreateDate,
			prd.[UnitOfMeasure],
			prd.MinimumToAlert,
			prc.GuID ClassificationGuID,
			prc.ID ClassificationID,
			prc.Name ClassificationName,
			brand.ID BrandID,
			brand.Name BrandName
		FROM prd.Product prd
		INNER JOIN [prd].[ProductClassification] prc 
			ON prc.ID = prd.ParentID
		LEFT JOIN [pbl].[Brand] brand 
			ON brand.ID = prd.[BrandID]
		WHERE prc.Removed = 0
			AND  prd.Removed = 0