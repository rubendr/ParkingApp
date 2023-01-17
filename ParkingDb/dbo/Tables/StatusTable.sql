CREATE TABLE [dbo].[StatusTable]
(
	[Id] INT NOT NULL IDENTITY(1,1) , 
    [Status] NVARCHAR(1) NOT NULL, 
    [StatusDesc] NVARCHAR(10) NULL, 
    PRIMARY KEY ([Status])
)
