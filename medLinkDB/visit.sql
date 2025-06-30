CREATE TABLE [dbo].[visit]
(
	[visit_id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [patient_id] INT NOT NULL, 
    [operation_id] INT NOT NULL,
    [doc_id] INT NOT NULL,
    [illness_id] INT NOT NULL,
    [note] NVARCHAR(MAX),
    [created_at] DATETIME NOT NULL,
    [last_modified] DATETIME NOT NULL,
    FOREIGN KEY (patient_id) REFERENCES patient(patient_id),
    FOREIGN KEY (illness_id) REFERENCES illness(illness_id),
    FOREIGN KEY (operation_id) REFERENCES operation(operation_id),
    FOREIGN KEY (doc_id) REFERENCES doctor(doc_id)
)
