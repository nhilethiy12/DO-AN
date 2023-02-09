using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace JFT_Project.DTOS
{
    public partial class ProductdtoRecord
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Qnt { get; set; }
        public int Qnt1 { get; set; }
        public string Detail { get; set; }
        public int BrandId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
    }
}
