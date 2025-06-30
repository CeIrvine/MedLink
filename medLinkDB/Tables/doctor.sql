CREATE TABLE [dbo].[doctor]
(
	[doc_id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [first_name] NVARCHAR(50) NOT NULL, 
    [last_name] NVARCHAR(50) NOT NULL, 
    [role] NVARCHAR(50) NOT NULL, 
    [created_at] DATETIME NOT NULL, 
    [last_modified] DATETIME NOT NULL
)
