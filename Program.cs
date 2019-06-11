using Dapper;
using DbUp;
using System;
using System.Collections.Generic;
using WorkshopDataSimulator.Data;
using WorkshopDataSimulator.Models;
using WorkshopDataSimulator.Types;

namespace WorkshopDataSimulator
{
    class Program
    {

        static int Main(string[] args)
        {
            var config = Config.GetConfig();

            var upgrader = DeployChanges.To
                .SqlDatabase(config.WorkshopConnectString)
                .WithScriptsAndCodeEmbeddedInAssembly(System.Reflection.Assembly.GetExecutingAssembly())
                .LogToConsole()
                .Build();

            var upgradeResult = upgrader.PerformUpgrade();

            if (!upgradeResult.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(upgradeResult.Error);
                Console.ResetColor();
#if DEBUG
                Console.ReadLine();
#endif
                return -1;
            }

            if (config.ClearTablesOnStartup)
            {
                ClearTables();
            }
            var tools = new List<ToolSim>()
            {
                new ToolSim("Marker", 5, 1),
                new ToolSim("Coater", 5, 5) { ModuleProducedAction = (m => GenerateCoaterData(m)) },
                new ToolSim("JunctionBox", 5, 10),
                new ToolSim("Simulator", 5, 0) { ModuleProducedAction = (m => GenerateSimData(m)) },
                new ToolSim("Frame", 5, 0),
                new ToolSim("Packout", 5, 0) { ModuleEnteredAction = (m =>  RequestBinClass(m)) }
            };

            var lastIndex = LastIndexData.GetLastIndex();
            var nextIndex = lastIndex != null ? lastIndex.Index++ : 1;
            using (var sim = new Simulator(tools, nextIndex, config.MarkerId))
            {
                sim.Start(config.TimerPeriodMilliseconds);
                Console.WriteLine("Press ENTER to quit");
                Console.ReadLine();
                sim.Stop();
            }

            return 0;
        }


        private static Random _random = new Random();
        private static void GenerateSimData(Module module)
        {
            var simResult = new SimResult() { SubId = module.SubId, Efficiency = _random.Next(0,20) / 100f, TimeStamp = DateTime.Now };
            SimData.InsertSimData(simResult);
        }

        private static void GenerateCoaterData(Module module)
        {
            var coaterResult = new CoaterResult() { SubId = module.SubId, Thickness = _random.Next(45, 75), TimeStamp = DateTime.Now };
            CoaterData.InsertCoaterData(coaterResult);
        }

        private static void RequestBinClass(Module module)
        {
            var binClassRequest = new BinClassRequest() { SubId = module.SubId, TimeStamp = DateTime.Now };
            BinClassRequestData.InsertBinClassRequestData(binClassRequest);
        }

        private static void ClearTables()
        {
            var sql = "truncate table dbo.ProducedEvent truncate table dbo.ScrapEvent truncate table dbo.LastIndex truncate table dbo.SimData truncate table dbo.BinClassRequest truncate table dbo.CoaterData";
            using (var connection = new System.Data.SqlClient.SqlConnection(Config.GetConfig().WorkshopConnectString))
            {
                connection.Execute(sql);
            }
        }
    }
}
