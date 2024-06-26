﻿using RestaurantProject.EntityLayer.Entities;

namespace RestaurantProject.DtoLayer.OrderDto
{
    public class ResultOrderDto
    {
        public int OrderID { get; set; }
        public string MenuTableID { get; set; }
        public string Description { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public int AppUserId { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
