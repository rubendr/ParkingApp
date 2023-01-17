/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

/*
truncate table ParkingTrans;
truncate table ParkingTranslogs;

INSERT INTO ParkingTrans(Slot,VehicleNo,VehicleType,VehicleColor,[Status],DateTimeIn) VALUES(1,'B-1234-XYZ','Mobil','Putih','I',GETDATE());
INSERT INTO ParkingTrans(Slot,VehicleNo,VehicleType,VehicleColor,[Status],DateTimeIn) VALUES(2,'B-9999-XYZ','Motor','Putih','I',GETDATE());
INSERT INTO ParkingTrans(Slot,VehicleNo,VehicleType,VehicleColor,[Status],DateTimeIn) VALUES(3,'D-0001-HIJ','Mobil','Hitam','I',GETDATE());
INSERT INTO ParkingTrans(Slot,VehicleNo,VehicleType,VehicleColor,[Status],DateTimeIn) VALUES(4,'B-7777-DEF','Mobil','Merah','I',GETDATE());
INSERT INTO ParkingTrans(Slot,VehicleNo,VehicleType,VehicleColor,[Status],DateTimeIn) VALUES(5,'B-2701-XXX','Mobil','Biru','I',GETDATE());
INSERT INTO ParkingTrans(Slot,VehicleNo,VehicleType,VehicleColor,[Status],DateTimeIn) VALUES(6,'B-3141-ZZZ','Motor','Hitam','I',GETDATE());
*/


