using System;
using System.Collections.Generic;
using System.Text;
using WorkshopDataSimulator.Types;

namespace WorkshopDataSimulator.Models
{
    public class ScrapEvent
    {        
        public int Id { get; set; }
        public string SubId { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Location { get; set; }
        public int ScrapCode { get; set; }
    }
}
