using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantProject.DataAccessLayer.Concrete;
using RestaurantProject.EntityLayer.Entities;

namespace RestaurantProjectWebUI.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly RestaurantProjectContext _context;
        private readonly UserManager<AppUser> _userManager;
        public ProfileController(IHttpClientFactory httpClientFactory, RestaurantProjectContext context, UserManager<AppUser> userManager)
        {
            _httpClientFactory = httpClientFactory;
            _context = context;
            _userManager = userManager;
        }


        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userId = user.Id;
            var orders = await _context.Orders.FirstOrDefaultAsync(x=>x.AppUserId == userId);
            var bookings = await _context.Bookings.Where(x=>x.Mail== user.Email).ToListAsync();   

            return View();
        }
    }
}
