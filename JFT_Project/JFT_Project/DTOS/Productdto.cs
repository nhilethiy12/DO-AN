using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace JFT_Project.DTOS
{
    public partial class Productdto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public double Price { get; set; }
        public int Qnt { get; set; }
        public int Qnt1 { get; set; }
        public string Detail { get; set; }
        public int BrandId { get; set; }
        [NotMapped]
        public IFormFile ImageUpload { get; set; }
    }
}
