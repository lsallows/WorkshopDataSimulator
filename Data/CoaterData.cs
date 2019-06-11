using Dapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using WorkshopDataSimulator.Models;
using WorkshopDataSimulator.Types;

namespace WorkshopDataSimulator.Data
{
    public class CoaterData
    {
        private static string connectString = Config.GetConfig().WorkshopConnectString;

        public static void InsertCoaterData(CoaterResult coaterResult)
        {            
            var sqlInsert = "INSERT INTO dbo.CoaterData ([SubId], [CoaterData], [TimeStamp]) VALUES (@SubId, @CoaterData, @TimeStamp)";

            try
            {
                using (var connection = new System.Data.SqlClient.SqlConnection(connectString))
                {
                    var result = connection.Execute(sqlInsert, new { SubId = coaterResult.SubId, CoaterData = JsonConvert.SerializeObject(coaterResult), TimeStamp = coaterResult.TimeStamp });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
}
    }
}
