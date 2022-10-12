USE [Kama.Sm]
GO

IF EXISTS(SELECT 1 FROM sys.synonyms WHERE [object_id] = OBJECT_ID('org._Position'))
	DROP SYNONYM org._Position

CREATE SYNONYM org._Position
	FOR [Kama.Bonyad.Organization].[org]._Position
GO