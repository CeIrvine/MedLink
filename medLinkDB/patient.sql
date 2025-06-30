CREATE TABLE [dbo].[patient]
(
	[patient_id] INT NOT NULL PRIMARY KEY IDENTITY,
	[first_name] NVARCHAR(100) NOT NULL,
	[last_name] NVARCHAR(100) NOT NULL,
	[created_at] DATETIME NOT NULL,
	[last_modified] DATETIME NOT NULL, 
    [patient_note] NVARCHAR(MAX) NULL
);
