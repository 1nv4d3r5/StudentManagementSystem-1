USE [SMS]
GO

CREATE TABLE [Core].[Department](
	[Id] [int] NOT NULL IDENTITY (1,1),
	[Code] [nvarchar](20) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
) ON [PRIMARY]

GO

ALTER TABLE [Core].[Department] ADD CONSTRAINT PK_Department_Id PRIMARY KEY (Id)
GO

ALTER TABLE [Core].[Department] ADD CONSTRAINT UK_Department_Code UNIQUE (Code)
GO

ALTER TABLE [Core].[Department] ADD CONSTRAINT UK_Department_Name UNIQUE (Name)
GO


--//@UNDO

USE [SMS]
GO

DROP TABLE [Core].[Department]
GO
