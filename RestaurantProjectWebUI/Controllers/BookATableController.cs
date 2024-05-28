using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Newtonsoft.Json;
using RestaurantProjectWebUI.Dtos.BookingDtos;
using System.Text;

namespace RestaurantProjectWebUI.Controllers
{
    public class BookATableController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BookATableController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateBookingDto createBookingDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBookingDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7272/api/Booking", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                if (createBookingDto.IsMailInfo == "true")
                {
                    MimeMessage mimeMessage = new MimeMessage();

                    MailboxAddress mailboxAddressFrom = new MailboxAddress("Efe Restaurant", "eferestaurantt@gmail.com");
                    mimeMessage.From.Add(mailboxAddressFrom);

                    MailboxAddress mailboxAddressTo = new MailboxAddress("User", createBookingDto.Mail);
                    mimeMessage.To.Add(mailboxAddressTo);

                    var bodyBuilder = new BodyBuilder();
                    bodyBuilder.TextBody = $"Merhaba {createBookingDto.Name}, \n{createBookingDto.Date.ToShortDateString()} tarihine {createBookingDto.PersonCount} kişilik rezervasyonunuz bulunmaktadır.\nBizi tercih ettiğiniz için teşekkür ederiz." ;
                    mimeMessage.Body = bodyBuilder.ToMessageBody();

                    mimeMessage.Subject = "Efe's Restaurant Rezervasyon Bilgilendirme";

                    SmtpClient client2 = new SmtpClient();
                    client2.Connect("smtp.gmail.com", 587, false);
                    client2.Authenticate("eferestaurantt@gmail.com", "wpqv mcew stma ovqm");

                    client2.Send(mimeMessage);
                    client2.Disconnect(true);
                }
                return RedirectToAction("Index","Default");
            }
            return View();
        }
    }
}
