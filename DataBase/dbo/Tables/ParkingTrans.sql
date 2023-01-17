CREATE TABLE [dbo].[ParkingTrans]
(
	[Id] BIGINT NOT NULL IDENTITY(1,1) , 
    [Slot] INT NULL, 
    [VehicleNo] NVARCHAR(10) NOT NULL, 
    [VehicleType] NVARCHAR(10) NULL, 
    [VehicleColor] NVARCHAR(10) NULL, 
    [Status] NVARCHAR(1) NULL, 
    [DateTimeIn] DATETIME NULL, 
    [DateTimeOut] DATETIME NULL, 
    CONSTRAINT [PK_ParkingTrans] PRIMARY KEY ([Id]) 
)
