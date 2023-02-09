using System;
using System.Collections.Generic;

namespace JFT_Project.DTOS
{
    public partial class Collectionsdto
    {
        public int CollectionId { get; set; }
        public string CollectionName { get; set; }
        public int BrandId { get; set; }
        public int ProductId { get; set; }
        public int ProductId2 { get; set; }
        public string ProductName1 { get; set; }
        public string ProductName2 { get; set; }
        public double PricePro1 { get; set; }
        public double PricePro2 { get; set; }
        public double Price { get; set; }
        public string Detail { get; set; }
        public string CollectionImage { get; set; }
        public string CollectionImage2 { get; set; }
    }
}
