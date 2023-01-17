CREATE TABLE [dbo].[VehicleTable]
(
	[Id] INT NOT NULL IDENTITY(1,1) , 
    [VehicleNo] NVARCHAR(10) NOT NULL, 
    [VehicleType] NVARCHAR(10) NULL, 
    [VehicleColor] NVARCHAR(10) NULL, 
    PRIMARY KEY ([VehicleNo])
)
