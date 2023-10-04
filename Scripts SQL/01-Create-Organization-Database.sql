USE master
GO

IF DB_ID('Organization') IS NULL
	CREATE DATABASE Organization
GO

USE Organization
GO