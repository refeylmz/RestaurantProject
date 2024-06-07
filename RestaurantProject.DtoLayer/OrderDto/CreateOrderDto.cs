using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantProject.DtoLayer.OrderDto
{
    public class CreateOrderDto
    {


        public string Description { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public int AppUserId { get; set; }
        public int MenuTableID { get; set; }
    }
}
