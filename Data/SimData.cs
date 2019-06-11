using Dapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using WorkshopDataSimulator.Models;
using WorkshopDataSimulator.Types;

namespace WorkshopDataSimulator.Data
{
    public class SimData
    {
        private static string connectString = Config.GetConfig().WorkshopConnectString;

        public static void InsertSimData(SimResult simResult)
        {            
            var sqlInsert = "INSERT INTO dbo.SimData ([SubId], [SimData], [TimeStamp]) VALUES (@SubId, @SimData, @TimeStamp)";

            try
            {
                using (var connection = new System.Data.SqlClient.SqlConnection(connectString))
                {
                    var result = connection.Execute(sqlInsert, new { SubId = simResult.SubId, SimData = JsonConvert.SerializeObject(simResult), TimeStamp = simResult.TimeStamp });
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
}
    }
}
