namespace RestaurantProjectWebUI.Dtos.BasketDtos
{
    public class CreateBasketDto
    {
        public int ProductID { get; set; }
        public int TableID { get; set; }

        public decimal Price { get; set; } // İndirimli fiyat için
    }
}
