USE [Kama.Sm]
GO

IF EXISTS(SELECT 1 FROM sys.synonyms WHERE [object_id] = OBJECT_ID('org.Departments'))
	DROP SYNONYM org.Departments

CREATE SYNONYM org.Departments
	FOR [Kama.Bonyad.Organization].[org].[Department]
GO