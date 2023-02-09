using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JFT_Project.ViewModel
{
    public class BranddtoModel
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public IFormFile BrandImage { get; set; }
    }
}
