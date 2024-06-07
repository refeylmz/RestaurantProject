using RestaurantProject.EntityLayer.Entities;

namespace RestaurantProjectWebUI.Dtos.OrderDtos
{
    public class ResultOrderDto
    {
        public int OrderID { get; set; }
        public string TableNumber { get; set; }
        public string Description { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public int AppUserId { get; set; }
        public int MenuTableID { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
