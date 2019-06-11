using System;
using System.Collections.Generic;
using System.Text;
using WorkshopDataSimulator.Types;

namespace WorkshopDataSimulator.Models
{
    public class ProducedEvent
    {        
        public int Id { get; set; }
        public string SubId { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Location { get; set; }
        public ProductStatus ProductStatus { get; set; }
    }
}
