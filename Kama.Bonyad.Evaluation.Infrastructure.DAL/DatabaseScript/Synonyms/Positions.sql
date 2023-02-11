USE [Kama.Sm]
GO

IF EXISTS(SELECT 1 FROM sys.synonyms WHERE [object_id] = OBJECT_ID('org.Positions'))
	DROP SYNONYM org.Position

CREATE SYNONYM org.Positions
	FOR [Kama.Bonyad.Organization].[org].[Position]
GO