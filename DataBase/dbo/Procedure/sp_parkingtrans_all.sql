CREATE PROCEDURE [dbo].[sp_parkingtrans_all]
@skip int=0,
@take int=0
AS
if @skip=0 and @take=0 begin
	select * from ParkingTrans;
end
else
begin
	SELECT * from ParkingTrans
	ORDER BY Id
	OFFSET @skip ROWS
	FETCH NEXT @take ROWS ONLY;
end
