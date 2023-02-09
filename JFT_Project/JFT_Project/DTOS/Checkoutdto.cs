using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JFT_Project.DTOS
{
    public partial class Checkoutdto
    {
        public int CusId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string AddressCus { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DayGet { get; set; }
        public string ProductImage { get; set; }
        public string CollectionImage { get; set; }
        public string CollectionImage2 { get; set; }

    }
}
