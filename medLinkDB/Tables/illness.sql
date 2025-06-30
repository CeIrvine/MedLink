CREATE TABLE [dbo].[illness]
(
	[illness_id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [name] NVARCHAR(50) NOT NULL, 
    [note] NVARCHAR(MAX) NOT NULL, 
    [created_at] DATETIME NOT NULL, 
    [last_modified] DATETIME NOT NULL
)
