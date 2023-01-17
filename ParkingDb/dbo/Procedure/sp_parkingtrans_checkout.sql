CREATE PROCEDURE [dbo].[sp_parkingtrans_checkout]
	@Id int
AS
	UPDATE ParkingTrans SET  Status='O',DateTimeOut=GETDATE() WHERE Status='I' AND Id=@Id;
RETURN 0;
