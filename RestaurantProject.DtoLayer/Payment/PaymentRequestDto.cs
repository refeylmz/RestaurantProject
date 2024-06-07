using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantProject.DtoLayer.Payment
{
    public class PaymentRequestDto
    {
        public double Amount { get; set; }
        public int MenuTableID { get; set; }
        public string Name { get; set; }
        public string CardNumber { get; set; }
        public string ExairationYear { get; set; }
        public string ExairationMonth { get; set; }
        public string CVC { get; set; }
        public string Email { get; set; }
        public int AppUserID { get; set; }
    }
}
