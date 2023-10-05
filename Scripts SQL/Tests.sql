USE MasterDb
GO

SELECT * FROM [dbo].[Organizations]
SELECT * FROM [dbo].[Users]

DELETE [dbo].[Organizations] WHERE Name NOT IN ('Organization 01', 'Organization 02');