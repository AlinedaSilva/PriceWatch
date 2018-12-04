using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PriceWatch.Models
{
    public class PriceWatchViewModel
    {
        public long Id { get; set; }
        public string ImageUrl { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LastUpdate { get; set; }
        public decimal? LastPrice { get; set; }
        public string PriceIndicatorGlyphicon { get; set; }
        public string PriceIndicatorBgColor { get; set; }
        public List<PriceWatchEntryViewModel> Entries { get; set; }
    }
}