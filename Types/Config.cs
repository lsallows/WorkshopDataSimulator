using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorkshopDataSimulator.Types
{
    public class Config
    {
        public string WorkshopConnectString { get; private set; }
        public int TimerPeriodMilliseconds { get; private set; }
        public string MarkerId { get; private set; }
        public bool ClearTablesOnStartup { get; private set; }

        private static Config _instance;        

        private static object _sync = new object();

        public static Config GetConfig()
        {
            lock (_sync)
            {
                if (_instance == null)
                {
                    _instance = new Config();
                }
                return _instance;
            }
        }

        private Config()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            WorkshopConnectString = config["WorkshopConnectString"];
            TimerPeriodMilliseconds = int.Parse(config["TimerPeriodMilliseconds"]);
            MarkerId = config["MarkerId"];
            ClearTablesOnStartup = bool.Parse(config["ClearTablesOnStartup"]);
        }
    }

}
