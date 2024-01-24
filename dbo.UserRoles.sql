CREATE TABLE [dbo].[UserRoles]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [UserId] INT NOT NULL, 
    [RoleId] INT NOT NULL
)
