﻿CREATE TABLE [dbo].[User_Games_Roles]
(
	[UGRID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserID] INT NOT NULL, 
    [GameID] INT NOT NULL, 
    [RoleID] INT NOT NULL
    CONSTRAINT [FK_UGR_User_DB] FOREIGN KEY ([UserID]) REFERENCES [User_DB]([Userid])
    CONSTRAINT [FK_UGR_Games] FOREIGN KEY ([GameID]) REFERENCES [Games]([GameID])
    CONSTRAINT [FK_UGR_Roles] FOREIGN KEY ([RoleID]) REFERENCES [Roles]([RoleID])
)
