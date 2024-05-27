using RestaurantProject.EntityLayer.Entities;

namespace RestaurantProjectWebUI.Models
{
    public class ProfileViewModel
    {
        public List<Order> OrderList { get; set; }
        public List<Booking> BookingList { get; set; }
        public string Name { get; set; }
    }
}
