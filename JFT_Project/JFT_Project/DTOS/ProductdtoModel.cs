using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace JFT_Project.DTOS
{
    public partial class ProductdtoModel
    {
        public int ProductId { get; set; }
        public IFormFile ProductImage { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Qnt { get; set; }
        public int Qnt1 { get; set; }
        public string Detail { get; set; }
        public int BrandId { get; set; }

    }
}
