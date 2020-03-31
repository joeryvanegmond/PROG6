using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOEF.Models.ViewModels
{
    public class BoekingVM
    {
        public Boeking Boeking { get; set; }

        public DateTime Date { get; set; }

        public Dictionary<Beest, String> Beesten = new Dictionary<Beest, String>();
        public Dictionary<Beest, String> SelectedBeests = new Dictionary<Beest, String>();

        public Dictionary<Accessoires, String> Accessoires = new Dictionary<Accessoires, String>();
        public Dictionary<Accessoires, String> SelectedAccessoires = new Dictionary<Accessoires, String>();

        public Customer Customer { get; set; }

        public int[] BeestIds { get; set; }
        public int[] AccessoireIds { get; set; }

        public Dictionary<string, int> Discounts = new Dictionary<string, int>();
        public decimal TotalPrice { get; set; }
        public decimal TotalDiscount { get; set; }
        
    }
}