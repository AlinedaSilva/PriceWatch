using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PriceWatch.Models
{
    public class PriceWatchEntryViewModel
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public PriceIndicator PriceIndicator { get; set; }
        public string PriceIndicatorGlyphicon
        {
            get
            {
                return PriceWatchEntryViewModel.GetPriceIndicatorGlyphicon(PriceIndicator);

            }
        }
        public string PriceIndicatorBgColor
        {
            get
            {
                return PriceWatchEntryViewModel.GetPriceIndicatorBgColor(PriceIndicator);
            }
        }
        public static string GetPriceIndicatorGlyphicon(PriceIndicator? priceIndicator)
        {
            if (priceIndicator.HasValue)
            {
                switch (priceIndicator.Value)
                {
                    case PriceIndicator.Up:
                        return "glyphicon glyphicon-arrow-up";
                    case PriceIndicator.Down:
                        return "glyphicon glyphicon-arrow-down";
                    case PriceIndicator.Same:
                        return "glyphicon glyphicon-arrow-minus";
                }
            }
            return "";
        }
        public static string GetPriceIndicatorBgColor(PriceIndicator? priceIndicator)
        {
            if (priceIndicator.HasValue)
            {
                switch (priceIndicator.Value)
                {
                    case PriceIndicator.Up:
                        return "danger";
                    case PriceIndicator.Down:
                        return "sucess";
                    case PriceIndicator.Same:
                        return "";

                }
            }
            return "";
        }
    }
}