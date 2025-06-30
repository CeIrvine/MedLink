CREATE TABLE [dbo].[insurance]
(
	[insurance_id] INT NOT NULL PRIMARY KEY IDENTITY,
	[patient_id] INT NOT NULL,
	[insurance_num] VARCHAR(100) NOT NULL,
	[created_at] DATETIME NOT NULL,
	[last_modified] DATETIME NOT NULL,
	FOREIGN KEY (patient_id) REFERENCES patient(patient_id)
)
