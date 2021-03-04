CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserName] NVARCHAR(50) NOT NULL, 
    [Salt] INT NOT NULL, 
    [HashedPassword] NVARCHAR(250) NOT NULL
)
