using System;
using System.Collections.Generic;
using System.Text;
using WorkshopDataSimulator.Types;

namespace WorkshopDataSimulator.Models
{
    public class CoaterResult
    {
        public int Id { get; set; }
        public string SubId { get; set; }
        public int Thickness { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
