using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JFT_Project.DTOS
{
    public class ApplicationSettings
    {
        public string JWT_Secret { get; set; }
        public string Client_URL { get; set; }
    }
}
