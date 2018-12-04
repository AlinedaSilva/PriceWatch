using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PriceWatch.Models
{
    public enum PriceIndicator
    {
        Up, Down, Same
    }
    public class PriceWatchEntry
    {
        public long Id { get; set; } // id for PriceWatchEntry
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public PriceIndicator PriceIndicator { get; set; }
    }
}