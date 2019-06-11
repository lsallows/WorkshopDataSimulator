using System;
using System.Collections.Generic;
using System.Text;
using WorkshopDataSimulator.Types;

namespace WorkshopDataSimulator.Models
{
    public class BinClassRequest
    {        
        public int Id { get; set; }
        public string SubId { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
