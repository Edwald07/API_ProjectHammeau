CREATE TABLE [dbo].[Messages]
(
	[MessageID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserID] INT NOT NULL, 
    [GameID] INT NOT NULL, 
    [ChatID] INT NOT NULL, 
    [Content] NVARCHAR(MAX) NOT NULL, 
    [TimesTamp] DATETIME NOT NULL
    CONSTRAINT [FK_Messages_User_DB] FOREIGN KEY ([UserID]) REFERENCES [User_DB] ([Userid])
    CONSTRAINT [FK_Messages_Games] FOREIGN KEY ([GameID]) REFERENCES [Games] ([Gameid])
)
