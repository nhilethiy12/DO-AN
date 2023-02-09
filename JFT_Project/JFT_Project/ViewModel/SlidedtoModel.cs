using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JFT_Project.ViewModel
{
    public class SlidedtoModel
    {
        public int SlideId { get; set; }
        public IFormFile SlideImage { get; set; }
    }
}
