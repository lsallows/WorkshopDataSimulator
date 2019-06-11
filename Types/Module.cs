using System;
using System.Collections.Generic;
using System.Text;

namespace WorkshopDataSimulator.Types
{
    public class Module
    {
        public static Module NullModule = new Module("") { ProductStatus = ProductStatus.Unknown };

        public Module(string subId)
        {
            this.SubId = subId;
            this.ProductStatus = ProductStatus.Good;
        }

        public string SubId { get; }
        public ProductStatus ProductStatus { get; set; }
    }
}
