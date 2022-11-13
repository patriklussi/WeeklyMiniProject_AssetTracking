using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeklyMiniProject_AssetTracking
{
    internal class Asset
    {
        public string AssetType { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int PurchasePrice { get; set; }
        public string Office { get; set; }
        public string Currency { get; set; }    
        public double ConvertedCurrency { get; set; }
    }
  
}
