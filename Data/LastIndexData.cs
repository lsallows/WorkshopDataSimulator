using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkshopDataSimulator.Models;
using WorkshopDataSimulator.Types;

namespace WorkshopDataSimulator.Data
{
    public class LastIndexData
    {
        private static string connectString = Config.GetConfig().WorkshopConnectString;

        public static void AddOrUpdateLastIndex(LastIndex lastIndex)
        {           
            var sqlUpdate = "UPDATE dbo.LastIndex SET [Day] = @Day, [Index] = @Index";
            var sqlInsert = "INSERT INTO dbo.LastIndex ([Day], [Index]) VALUES (@Day, @Index)";
            try
            {
                using (var connection = new System.Data.SqlClient.SqlConnection(connectString))
                {
                    var last = GetLastIndex();
                    if (last == null)
                    {
                        connection.Execute(sqlInsert, lastIndex);
                    }
                    else
                    {
                        var result = connection.Execute(sqlUpdate, lastIndex);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static LastIndex GetLastIndex()
        {            
            var sqlSelect = "SELECT TOP 1 * from dbo.LastIndex";

            try
            {
                using (var connection = new System.Data.SqlClient.SqlConnection(connectString))
                {
                    return connection.Query<LastIndex>(sqlSelect).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}
