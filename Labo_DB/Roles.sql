CREATE TABLE [dbo].[Roles]
(
	[RoleID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Role_Name] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [Pictures] VARCHAR(MAX), 
    [CategorieID] INT NOT NULL
    CONSTRAINT [FK_Roles_Categories] FOREIGN KEY ([CategorieID]) REFERENCES [Categories] ([CategorieID]), 
    [IsAlive] BIT NOT NULL DEFAULT 1
)
