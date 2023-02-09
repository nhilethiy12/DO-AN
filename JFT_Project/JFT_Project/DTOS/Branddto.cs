using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace JFT_Project.DTOS
{
    public partial class Branddto
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string BrandImage { get; set; }
    }
}
