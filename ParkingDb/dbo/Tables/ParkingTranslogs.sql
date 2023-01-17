CREATE TABLE [dbo].[ParkingTranslogs]
(
	[Id] BIGINT NOT NULL , 
    [Slot] INT NULL, 
    [VehicleNo] NVARCHAR(10) NOT NULL, 
    [VehicleType] NVARCHAR(10) NULL, 
    [VehicleColor] NVARCHAR(20) NULL, 
    [Status] NVARCHAR(1) NULL, 
    [DateTimeIn] DATETIME NULL, 
    [DateTimeOut] DATETIME NULL, 
    CONSTRAINT [PK_ParkingTranslogs] PRIMARY KEY ([Id]) 
)
