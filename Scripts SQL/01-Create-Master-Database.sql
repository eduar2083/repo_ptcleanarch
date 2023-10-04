USE master
GO

IF DB_ID('MasterDb') IS NULL
	CREATE DATABASE MasterDb
GO

USE MasterDb
GO