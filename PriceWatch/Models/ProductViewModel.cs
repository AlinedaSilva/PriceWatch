using System;
using System.Collections.Generic;
using System.Text; // string builder
using Newtonsoft.Json;

namespace PriceWatch.Models
{
    public class ProductViewModel
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("tpnb")]
        public long Tpnb { get; set; }
        [JsonProperty("image")]
        public string ImageUrl { get; set; }
        [JsonProperty("superDepartment")]
        public string SuperDepartment { get; set; }
        [JsonProperty("ContentsMeasureType")]
        public string ContentsMeasureType { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("UnitOfSale")]
        public int UnitOfSale { get; set; }
        [JsonProperty("description")]
        public List<string> LstDescription { get; set; }
        [JsonProperty("AverageSellingUnitWeight")]
        public decimal AverageSellingUnitWeight { get; set; }
        [JsonProperty("UnitQuantity")]
        public string UnitQuantity { get; set; }
        [JsonProperty("ContentsQuantity")]
        public int ContentsQuantity { get; set; }
        [JsonProperty("department")]
        public string Department { get; set; }
        [JsonProperty("price")]
        public decimal Price { get; set; }
        [JsonProperty("unitprice")]
        public decimal UnitPrice { get; set; }
        public bool HasPriceWatch { get; set; }
        public string Description
        {
            get
            {
                var sb = new StringBuilder(); // using System.Text;

                if (LstDescription != null)
                {
                    foreach (var str in LstDescription)
                    {
                        sb.AppendLine(str);
                    }
                }

                return sb.ToString();
            }
        }
    }
}
