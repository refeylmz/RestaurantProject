using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RestaurantProject.DataAccessLayer.Concrete;
using RestaurantProject.DtoLayer.OrderDto;
using RestaurantProject.DtoLayer.Payment;
using RestaurantProject.EntityLayer.Entities;
using RestaurantProjectWebUI.Dtos.BasketDtos;
using Stripe;
using System.Net.Http;
using System.Text;

namespace RestaurantProjectWebUI.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly RestaurantProjectContext _context;
        private readonly UserManager<AppUser> _userManager;

        public PaymentController(IHttpClientFactory httpClientFactory, RestaurantProjectContext context, UserManager<AppUser> userManager)
        {
            _httpClientFactory = httpClientFactory;
            _context = context;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task< IActionResult> Index(PaymentRequestDto paymentRequestDto, string BasketData)
        {
            var basketItems = JsonConvert.DeserializeObject<List<ResultBasketDto>>(BasketData);
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userId = user.Id;
            using (var context = new RestaurantProjectContext())
            {
                var order = new Order
                {
                    MenuTableID = 1,
                    TableNumber = "1",
                    Description = "1 Ödeme Alındı.",
                    OrderDate = DateTime.Now,
                    TotalPrice = Convert.ToDecimal(paymentRequestDto.Amount),
                    AppUserId = userId
                };
                context.Orders.Add(order);

                foreach (var item in basketItems)
                {
                    if (item.MenuTableID == paymentRequestDto.MenuTableID)
                    {
                        var orderDetail = new OrderDetail
                        {
                            ProductID = item.ProductID,
                            UnitPrice = item.Price,
                            Count =Convert.ToInt32(item.Count),
                            TotalPrice = item.Price + (item.Price * 0.1M)

                        };
                        order.OrderDetails.Add(orderDetail);

                    }
                    

                }
                context.SaveChanges();

            }

            return View(paymentRequestDto);
        }
        [HttpPost]
        public async Task<IActionResult> Payment(PaymentRequestDto paymentRequestDto)
        {
            // Set Stripe Token options based on customer data
            TokenCreateOptions tokenOptions = new TokenCreateOptions
            {
                Card = new TokenCardOptions
                {
                    Name = paymentRequestDto.Name,
                    Number = paymentRequestDto.CardNumber,
                    ExpYear = paymentRequestDto.ExairationYear,
                    ExpMonth = paymentRequestDto.ExairationMonth,
                    Cvc = paymentRequestDto.CVC
                }
            };
            var _tokenService = new TokenService();
            var request = new RequestOptions
            {
                ApiKey = "sk_test_51NG6DNF33x2uIcWY3MHpXUCaA6Qb7jGiX9QvEewjmGEDRZlLqSs4lDkjyRhPNuqjKvQ2XY9xNTnhGGAWmN8O04M100xQTspond"
            };
            // Create new Stripe Token
            Token stripeToken = _tokenService.Create(tokenOptions, request);

            // Set Customer options using
            CustomerCreateOptions customerOptions = new CustomerCreateOptions
            {
                Name = paymentRequestDto.Name,
                Email = paymentRequestDto.Email,
                Source = stripeToken.Id
            };
            var _customerService = new CustomerService();
            // Create customer at Stripe
            Customer createdCustomer = _customerService.Create(customerOptions, request);

            ChargeCreateOptions paymentOptions = new ChargeCreateOptions
            {
                Customer = createdCustomer.Id,
                ReceiptEmail = "remziefeyilmaz@gmail.com",
                Description = createdCustomer.Description,
                Currency = "USD",
                Amount = (long)paymentRequestDto.Amount
            };
            var _chargeService = new ChargeService();
            var request2 = new RequestOptions
            {
                ApiKey = "sk_test_51NG6DNF33x2uIcWY3MHpXUCaA6Qb7jGiX9QvEewjmGEDRZlLqSs4lDkjyRhPNuqjKvQ2XY9xNTnhGGAWmN8O04M100xQTspond"
            };
            // Create the payment
            var createdPayment = _chargeService.Create(paymentOptions, request2);
            var user = await _userManager.FindByNameAsync(User.Identity.Name);//x
            var userId = user.Id;//x

            //var client = _httpClientFactory.CreateClient();
            //var jsonData = JsonConvert.SerializeObject(new CreateOrderDto { TotalPrice = (decimal)paymentRequestDto.Amount,MenuTableID = paymentRequestDto.MenuTableID,Description=$"{paymentRequestDto.MenuTableID} Ödeme Alındı.",AppUserId=userId,OrderDate=DateTime.Now,});//x
            //StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //var responseMessage = await client.PostAsync("https://localhost:7272/api/Orders", stringContent);
            //if (!responseMessage.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index");
            //}
            return RedirectToAction("Index", "Default");
        }

    }
}
