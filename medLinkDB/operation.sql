CREATE TABLE [dbo].[operation]
(
	[operation_id] INT NOT NULL PRIMARY KEY IDENTITY,
	[operation_name] NVARCHAR(100) NOT NULL,
	[doc_note] NVARCHAR(MAX) NULL, 
    [doc_id] INT NOT NULL,
	[patient_id] INT NOT NULL,
	[created_at] DATETIME NOT NULL, 
    [last_modified] DATETIME NOT NULL, 
    FOREIGN KEY (doc_id) REFERENCES doctor(doc_id),
	FOREIGN KEY (patient_id) REFERENCES patient(patient_id)
)
