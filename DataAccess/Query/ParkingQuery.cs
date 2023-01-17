using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Query
{
    public static class ParkingQuery
    {
        public static string Insert => @"INSERT INTO [dbo].[ParkingTrans]
           ([Slot]
           ,[VehicleNo]
           ,[VehicleType]
           ,[VehicleColor]
           ,[Status]
           ,[DateTimeIn])
     VALUES
           (@Slot
           ,@VehicleNo
           ,@VehicleType
           ,@VehicleColor
           ,'I'
           ,GETDATE())";

        /// <summary>
        /// update by id and status
        /// </summary>
        public static string Update => @"UPDATE [dbo].[ParkingTrans]
            SET [Status]='O',[DateTimeOut] = GETDATE()
            WHERE Id=@Id and Status='I'";

        public static string Delete => "";

        public static string Select => "";

    }
}
