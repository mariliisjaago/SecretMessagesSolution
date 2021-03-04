CREATE TABLE [dbo].[Messages]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Message] NVARCHAR(300) NOT NULL, 
    [FromUserId] INT NOT NULL, 
    [ToUserId] INT NOT NULL, 
    [IsRead] BIT NOT NULL, 
    CONSTRAINT [FK_Messages_FromUserId_Users] FOREIGN KEY (FromUserId) REFERENCES Users(Id), 
    CONSTRAINT [FK_Messages_ToUserId_Users] FOREIGN KEY (ToUserId) REFERENCES Users(Id)
)
