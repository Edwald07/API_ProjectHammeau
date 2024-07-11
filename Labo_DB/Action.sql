CREATE TABLE [dbo].[Action]
(
	[ActionID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserID] INT NOT NULL, 
    [GameID] INT NOT NULL, 
    [ActionType] NCHAR(10) NOT NULL
    CONSTRAINT [FK_Action_User] FOREIGN KEY ([UserID]) REFERENCES [User_DB] ([Userid])
    CONSTRAINT [FK_Action_Games] FOREIGN KEY ([GameID]) REFERENCES [Games] ([Gameid])
)
