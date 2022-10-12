USE [Kama.Sm]
GO

IF EXISTS(SELECT 1 FROM sys.synonyms WHERE [object_id] = OBJECT_ID('pbl.Attachment'))
	DROP SYNONYM pbl.Attachment

CREATE SYNONYM pbl.Attachment
	FOR [Kama.Bonyad.Evaluation.Extra].[pbl].[Attachment]
GO
