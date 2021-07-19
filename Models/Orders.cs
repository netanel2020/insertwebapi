using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace insertwebapi.Models
{
    public class Orders
    {
        public int ORDID { get; set; }
        public int NumberOfProdacts { get; set; }
        public string ProdactsNames { get; set; }
        public string ORDAmount { get; set; }
        public string ORDDastenyAddress { get; set; }
        public int TotalCost { get; set; }
        public int USRIID { get; set; }
        public string USRPaymentDDeatals { get; set; }


    

    }
}