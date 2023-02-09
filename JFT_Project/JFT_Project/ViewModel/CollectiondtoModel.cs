using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JFT_Project.ViewModel
{
    public class CollectiondtoModel
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
        public IFormFile CollectionImage { get; set; }
        public IFormFile CollectionImage2 { get; set; }
    }
}
