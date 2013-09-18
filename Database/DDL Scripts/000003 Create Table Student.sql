USE [SMS]
GO

CREATE TABLE [Core].[Student](
	[Id] [int] NOT NULL IDENTITY (1,1),
	[RollNumber] [nvarchar](50) NOT NULL,	
	[FirstName] [nvarchar](50) NOT NULL,
	[MiddleName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[JoinDate] Datetime
) ON [PRIMARY]

GO

ALTER TABLE [Core].[Student] ADD CONSTRAINT PK_Student_Id PRIMARY KEY (Id)
GO

ALTER TABLE [Core].[Student] ADD CONSTRAINT UK_Student_RollNumber UNIQUE (RollNumber)
GO

ALTER TABLE [Core].[Student] ADD CONSTRAINT UK_Student_JoinDate DEFAULT GETDATE() FOR [JoinDate]
GO


--//@UNDO

USE [SMS]
GO

DROP TABLE [Core].[Student]
GO