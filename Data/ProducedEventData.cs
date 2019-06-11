using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using WorkshopDataSimulator.Models;
using WorkshopDataSimulator.Types;

namespace WorkshopDataSimulator.Data
{
    public class ProducedEventData
    {
        private static string connectString = Config.GetConfig().WorkshopConnectString;

        public static void InsertProducedData(ProducedEvent producedEvent)
        {            
            var sqlInsert = "INSERT INTO dbo.ProducedEvent ([SubId], [TimeStamp], [Location], [ProductStatus]) VALUES (@SubId, @TimeStamp, @Location, @ProductStatus)";

            try
            {
                using (var connection = new System.Data.SqlClient.SqlConnection(connectString))
                {
                    var result = connection.Execute(sqlInsert, producedEvent);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
