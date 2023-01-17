CREATE VIEW [dbo].[ParkingTransView]
	AS 
	select pt.*,
DATEDIFF(HOUR,pt.DateTimeIn,pt.DateTimeOut) AS TotalTime,
DATEDIFF(HOUR,pt.DateTimeIn,pt.DateTimeOut) * 5000 AS Amount,
CASE WHEN DATEDIFF(HOUR,pt.DateTimeIn,pt.DateTimeOut)>1 THEN 'TOTALTIME *PRICE' ELSE '1*PRICE' END AS AmountFormula
FROM ParkingTranslogs pt;
