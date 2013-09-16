USE [SMS]
GO

ALTER TABLE [Core].[Student] ADD DepartmentId INT NOT NULL 
CONSTRAINT DF_Student_DepartmentId DEFAULT(1)
GO

ALTER TABLE [Core].[Student]
	ADD CONSTRAINT FK_Student_DepartmentId
	FOREIGN KEY (DepartmentId)
	REFERENCES [Core].[Department](Id);

ALTER TABLE [Core].[Student] DROP CONSTRAINT DF_Student_DepartmentId 
GO