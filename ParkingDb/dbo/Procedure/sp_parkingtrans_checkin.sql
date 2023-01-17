CREATE PROCEDURE [dbo].[sp_parkingtrans_checkin]
	@slot int,
	@vehicleNo nvarchar(10),
	@vehicleType nvarchar(10),
	@vehicleColor nvarchar(20)
AS
	INSERT INTO ParkingTrans(Slot,VehicleNo,VehicleType,VehicleColor,[Status],DateTimeIn) 
	VALUES(@slot,@vehicleNo,@vehicleType,@vehicleColor,'I',GETDATE())
	
RETURN @@IDENTITY;
