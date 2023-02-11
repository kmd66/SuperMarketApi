USE [Kama.Sm]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('pbl.spDepoIndex'))
	DROP PROCEDURE pbl.spDepoIndex
GO

CREATE PROCEDURE pbl.spDepoIndex
WITH ENCRYPTION
AS
BEGIN
	

	DECLARE @T1 TABLE(
		ItemID [bigint] NOT NULL,
		FaName [nvarchar](255) NOT NULL,
		Number [bigint] NOT NULL,
		PriceBuy [bigint] NOT NULL,
		PriceSale [bigint] NOT NULL,
		Count [int] NOT NULL,
		[Type] [tinyint] NOT NULL
	);
	DECLARE @StorageEnter TABLE(
		ItemID [bigint] NOT NULL,
		FaName [nvarchar](255) NOT NULL,
		Number [bigint] NOT NULL,
		PriceBuy [bigint] NOT NULL,
		PriceSale [bigint] NOT NULL,
		Count [int] NOT NULL
	);
	DECLARE @StorageLeave TABLE(
		ItemID [bigint] NOT NULL,
		Number [bigint] NOT NULL,
		Count [int] NOT NULL
	);
	
	INSERT INTO @T1
	SELECT 
		[ItemID], 
		itm.FaName, 
		SUM(Number) Number,
		SUM(PriceBuy)PriceBuy,
		SUM(PriceSale)PriceSale,
		COUNT([ItemID])Count,
		[Type]
	FROM [pbl].[Depo] dep
	INNER JOIN prd.Item itm ON dep.ItemID = itm.ID
	GROUP BY
	[ItemID], [Type], itm.FaName
	
	INSERT INTO @StorageEnter
	SELECT ItemID,FaName,Number,PriceBuy, PriceSale,Count  FROM @T1 WHERE [Type] = 1
	
	INSERT INTO @StorageLeave
	SELECT ItemID,Number,Count FROM @T1 WHERE [Type] = 10
	
	DELETE [pbl].[DepoIndex]
	INSERT INTO [pbl].[DepoIndex]
	SELECT 
		e.[ItemID], 
		e.[FaName], 
		e.Number - COALESCE(l.Number, 0) [Number], 
		e.[Number] [NumberEnter], 
		COALESCE(l.Number, 0) [NumberLeave],
		a.[PriceBuy] [LastPriceBuy], 
		e.[PriceBuy] / e.Count PriceBuy, 
		0[LastPriceSale], 
		0[AverageLastPriceSale], 
		1[Type]
	FROM @StorageEnter e
	LEFT JOIN @StorageLeave l on l.ItemID = e.ItemID
	CROSS APPLY ( SELECT TOP 1 [PriceBuy] from [pbl].[Depo] a1 WHERE a1.ItemID = e.ItemID ) a

END