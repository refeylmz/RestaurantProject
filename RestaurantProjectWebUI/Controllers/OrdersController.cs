using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestaurantProjectWebUI.Dtos.OrderDtos;
using System.Text;

namespace RestaurantProjectWebUI.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public OrdersController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7272/api/Orders");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultOrderDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
