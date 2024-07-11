CREATE TABLE [dbo].[Categories]
(
	[CategorieID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CT_Name] NVARCHAR(50) NOT NULL, 
    [CT_Description] NVARCHAR(MAX) NOT NULL
)
