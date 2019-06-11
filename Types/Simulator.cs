using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WorkshopDataSimulator.Data;

namespace WorkshopDataSimulator.Types
{
    public class Simulator : IDisposable
    {
        public List<ToolSim> Tools { get; }

        public int SubIdIndex { get; private set; }
        public string MarkerId { get; private set; }

        private int _timerPeriod;
        private object _sync = new object();
        private CancellationTokenSource _cancellationTokenSource;

        public Simulator(List<ToolSim> tools, int startingIndex, string markerId)
        {
            this.Tools = tools;
            this.SubIdIndex = startingIndex;
            this.MarkerId = markerId;
        }

        public void Start(int timerPeriodMilliseconds)
        {
            this._cancellationTokenSource = new CancellationTokenSource(Timeout.Infinite);
            this._timerPeriod = timerPeriodMilliseconds;           
            Task.Run(() => RunSimulate(this._cancellationTokenSource.Token));
        }

        public void Stop()
        {
            if (this._cancellationTokenSource != null)
            {
                this._cancellationTokenSource.Cancel();
            }          
        }

        private async Task RunSimulate(CancellationToken cancellationToken)
        {
            while (true)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    break;
                }

                await Task.Delay(this._timerPeriod);

                var module = GetIncoming();
                Tools.ForEach(t =>
                {
                    module = t.MoveModules(module);

                    // Save produced data if it's a "real" module
                    if (module != Module.NullModule)
                    {
                        SaveModuleProduced(module, t.Location);
                    }
                    // If module was scrap out of tool, assume it went to dumpster and replace with Null
                    if (module.ProductStatus == ProductStatus.Scrap)
                    {
                        module = Module.NullModule;
                    }
                });
            }
        }      

        private Module GetIncoming()
        {
            var subid = $"{DateTime.Now.ToString("yyMMdd")}{this.MarkerId}{this.SubIdIndex.ToString("000#")}";
            this.SubIdIndex++;
            return new Module(subid);
        }

        private void SaveModuleProduced(Module module, string location)
        {
            ProducedEventData.InsertProducedData(new Models.ProducedEvent() { SubId = module.SubId, Location = location, TimeStamp = DateTime.Now, ProductStatus = module.ProductStatus });
        }

        public void Dispose()
        {
            if (this._cancellationTokenSource != null)
            {
                if (!this._cancellationTokenSource.IsCancellationRequested)
                {
                    this._cancellationTokenSource.Cancel();
                }                
            }
        }
    }
}
