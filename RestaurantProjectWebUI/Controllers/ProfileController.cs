using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantProject.DataAccessLayer.Concrete;
using RestaurantProject.EntityLayer.Entities;
using RestaurantProjectWebUI.Models;

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
            var orders = await _context.Orders.Where(x=>x.AppUserId == userId).ToListAsync();
            var bookings = await _context.Bookings.Where(x=>x.Mail== user.Email).ToListAsync();
            ProfileViewModel profileViewModel = new ProfileViewModel();
            profileViewModel.OrderList = orders;
            profileViewModel.BookingList= bookings;
            profileViewModel.Name = user.Name + " " + user.Surname;
            return View(profileViewModel);
        }
    }
}
