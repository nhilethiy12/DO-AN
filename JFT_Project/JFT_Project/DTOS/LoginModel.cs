using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JFT_Project.DTOS
{
    public class LoginModel
    {
        public int AdminId { get; set; }
        public string AdminName { get; set; }
        public string Password { get; set; }
    }
}
