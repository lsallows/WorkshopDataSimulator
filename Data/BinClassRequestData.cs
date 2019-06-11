using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using WorkshopDataSimulator.Models;
using WorkshopDataSimulator.Types;

namespace WorkshopDataSimulator.Data
{
    public class BinClassRequestData
    {
        private static string connectString = Config.GetConfig().WorkshopConnectString;

        public static void InsertBinClassRequestData(BinClassRequest binClassRequest)
        {            
            var sqlInsert = "INSERT INTO dbo.BinClassRequest ([SubId], [TimeStamp]) VALUES (@SubId, @TimeStamp)";

            try
            {
                using (var connection = new System.Data.SqlClient.SqlConnection(connectString))
                {
                    var result = connection.Execute(sqlInsert, binClassRequest);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
