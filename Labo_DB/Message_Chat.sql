CREATE TABLE [dbo].[Message_Chat]
(
	[MChatID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [MessageID] INT NOT NULL, 
    [ChatID] INT NOT NULL
    CONSTRAINT [FK_Message_Chat_Messages] FOREIGN KEY ([MessageID]) REFERENCES [Messages]([MessageID])
    CONSTRAINT [FK_Message_Chat_Chats] FOREIGN KEY ([ChatID]) REFERENCES [Chats]([ChatID])
)
