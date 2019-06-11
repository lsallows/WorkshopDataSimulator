using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using WorkshopDataSimulator.Models;
using WorkshopDataSimulator.Types;

namespace WorkshopDataSimulator.Data
{
    public class ScrapEventData
    {
        private static string connectString = Config.GetConfig().WorkshopConnectString;

        public static void InsertScrapData(ScrapEvent scrapEvent)
        {            
            var sqlInsert = "INSERT INTO dbo.ScrapEvent ([SubId], [TimeStamp], [Location], [ScrapCode]) VALUES (@SubId, @TimeStamp, @Location, @ScrapCode)";

            try
            {
                using (var connection = new System.Data.SqlClient.SqlConnection(connectString))
                {
                    var result = connection.Execute(sqlInsert, scrapEvent);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
