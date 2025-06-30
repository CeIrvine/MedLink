CREATE TABLE [dbo].[biometrics]
(
	[biometrics_id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [patient_id] INT NOT NULL, 
    [fingerprint_bio] VARBINARY(MAX) NOT NULL, 
    [face_bio] NCHAR(10) NOT NULL, 
    [created_at] DATETIME NOT NULL, 
    [last_modified] DATETIME NOT NULL,
    FOREIGN KEY (patient_id) REFERENCES patient(patient_id)
)
