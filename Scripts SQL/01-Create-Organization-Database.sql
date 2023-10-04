USE master
GO

IF DB_ID('Company') IS NULL
	CREATE DATABASE Company
GO

USE Company
GO