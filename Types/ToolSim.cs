using System;
using System.Collections.Generic;
using System.Text;
using WorkshopDataSimulator.Data;

namespace WorkshopDataSimulator.Types
{
    public class ToolSim
    {
        public const int SCRAPCODE = 1022;

        public Action<Module> ModuleProducedAction { get; set; }
        public Action<Module> ModuleEnteredAction { get; set; }

        public ToolSim(string location, int positionCount, int scrapPercent)
        {
            if (positionCount <= 0)
            {
                throw new ArgumentException("Must have at least one position", nameof(positionCount));
            }

            if (scrapPercent < 0 || scrapPercent > 100)
            {
                throw new ArgumentException("Must be between 0 and 100", nameof(scrapPercent));
            }

            this.Location = location;
            this.PositionCount = positionCount;
            this.ScrapPercent = scrapPercent;

            _random = new Random();

            InitializeQueue();
        }

        private Queue<Module> _modules;
        private Random _random;

        public string Location { get; }
        public int PositionCount { get; }
        public int ScrapPercent { get;  }

        public Module MoveModules(Module incoming)
        {
            if (incoming != Module.NullModule)
            {
                if (this.ModuleEnteredAction != null)
                {
                    this.ModuleEnteredAction(incoming);
                }
            }
            this._modules.Enqueue(incoming);
            var outgoing = this._modules.Dequeue();
            if (outgoing != Module.NullModule)
            {
                if (IsScrapModule())
                {
                    SaveScrapEvent(outgoing);
                    outgoing.ProductStatus = ProductStatus.Scrap;
                }
                if (this.ModuleProducedAction != null)
                {
                    this.ModuleProducedAction(outgoing);
                }
            }
            return outgoing;
        }

        private void InitializeQueue()
        {
            this._modules = new Queue<Module>();

            for (var i =0; i< this.PositionCount; i++)
            {
                this._modules.Enqueue(Module.NullModule);
            }           
        }

        private bool IsScrapModule()
        {
            var random = this._random.Next(100);
            return random <= this.ScrapPercent;                
        }

        private void SaveScrapEvent(Module module)
        {
            ScrapEventData.InsertScrapData(new Models.ScrapEvent(){ Location = this.Location,
                                                                    ScrapCode = SCRAPCODE,
                                                                    SubId = module.SubId,
                                                                    TimeStamp = DateTime.Now });
        }
    }
}
