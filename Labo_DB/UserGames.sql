CREATE TABLE [dbo].[UserGames]
(
	[UserGameID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserID] INT NOT NULL, 
    [GameID] INT NOT NULL,
    [RoleID] INT NULL,
    CONSTRAINT [FK_UserGames_User_DB] FOREIGN KEY ([UserID]) REFERENCES [User_DB]([UserID]),
    CONSTRAINT [FK_UserGames_Games] FOREIGN KEY ([GameID]) REFERENCES [Games]([GameID]), 
    CONSTRAINT [FK_UserGames_Roles] FOREIGN KEY ([RoleID]) REFERENCES [Roles]([RoleID]),
    
)
