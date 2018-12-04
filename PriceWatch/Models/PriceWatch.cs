using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PriceWatch.Models
{
    public class PriceWatch
    {
        public long Id { get; set; }
        public string UserId { get; set; }
        public long ProductId { get; set; }
        public DateTime CreationDate { get; set; }
        public List<PriceWatchEntry> Entries { get; set; }// list of all entries to the database
        public bool Enabled { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ImageUrl { get; set; }

    }
}
