CREATE TABLE [dbo].[user]
(
	[user_id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [username] VARCHAR(50) NOT NULL, 
    [password_hash] VARBINARY(256) NOT NULL, 
    [password_salt] VARBINARY(256) NOT NULL, 
    [role] VARCHAR(50) NOT NULL, 
    [created_at] DATETIME NOT NULL, 
    [last_modified] DATETIME NOT NULL
)
