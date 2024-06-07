using Microsoft.EntityFrameworkCore;
using RestaurantProject.DataAccessLayer.Abstract;
using RestaurantProject.DataAccessLayer.Concrete;
using RestaurantProject.DataAccessLayer.Repositories;
using RestaurantProject.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantProject.DataAccessLayer.EntityFramework
{
    public class EfOrderDal : GenericRepository<Order>, IOrderDal
    {
        public EfOrderDal(RestaurantProjectContext context) : base(context)
        {
        }

        public int ActiveOrderCount()
        {
            using var context = new RestaurantProjectContext();
            return context.Orders.Where(x => x.Description == "1 Ödeme Alındı.").Count();
        }

        public List<Order> GetWithOrderDetails()
        {
            using var context = new RestaurantProjectContext();
            var value = context.Orders.Include(o => o.OrderDetails).ThenInclude(p=>p.Product).ToList();
            return value;
        }

        public decimal LastOrderPrice()
        {
            using var context = new RestaurantProjectContext();
            return context.Orders.OrderByDescending(x => x.OrderID).Take(1).Select(y => y.TotalPrice).FirstOrDefault();
        }

        public decimal TodayTotalPrice()
        {
            return 0;
        }

        public int TotalOrderCount()
        {
            using var context = new RestaurantProjectContext();
            return context.Orders.Count();
        }
    }

}
